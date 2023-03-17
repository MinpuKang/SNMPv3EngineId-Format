#!/usr/bin/env python3
#_*_ coding:utf-8 _*_
#Version: 1.0
#Author: Minpu Kang
#Create Date: 2023-03-10
#Options: This is a common version in Linux/Unix Server with Python 3.0 or above, it is used to generate SNMPEngineID based on the input.
#         Version 1.0: 2023-03-10, first vesion.
import sys
import os
import getopt
import re
import ipaddress
import requests
import socket
from html. parser import HTMLParser

class Parser(HTMLParser):
  def handle_data(self, data):
    global all_data
    all_data.append(data)
all_data = []

def usage(toolname):
    print ("This is used for generate snmpEngineID for SNMPv3")
    print ("Usage: %s [-p PEN -f FORMAT -d DATA] [-h] [-e ENGINEID]"%toolname)
    print ("Options:")
    print ("  -h      HELP        Show the help\n")  
    print ("  -p      PEN         Set the private enterprise number based on IANA(https://www.iana.org/assignments/enterprise-numbers)")
    print ("  -f      Format      Set the format of the engine ID Data, value as below:")
    print ("                      1 - IPv4 address")
    print ("                      2 - IPv6 address")
    print ("                      3 - MAC address")
    print ("                      4 - Text, admin assgined with maximum length 27")
    print ("  -d      Data        EngineID data based on the formart\n")
    print ("  -e      EngineID    An EngineID to be decoded\n")
    print ("Example:")
    print ("-----------------------------------\n")
    print ("  Generte a snmpEngineID with IPv4:")
    print ("  user@host> %s -p 193 -f 1 -d 11.12.13.14\n"%toolname)
    print ("  Generte a snmpEngineID with IPv6:")
    print ("  user@host> %s -p 193 -f 2 -d f1:dd:1\n"%toolname)
    print ("  Generte a snmpEngineID with MAC Address:")
    print ("  user@host> %s -p 193 -f 3 -d 52:54:00:7d:31:a3\n"%toolname)
    print ("  Generte a snmpEngineID with Text:")
    print ("  user@host> %s -p 193 -f 4 -d \"this is snmpv3\"\n"%toolname)
    print ("  Decode an engineID:")
    print ("  user@host> %s -e 800000c10101020304"%toolname)
    print ("-----------------------------------\n")

def decode_print(decode_pen,org_for_pen,decode_format,decode_data):
    print("Engine ID Conformance: RFC3411 (SNMPv3)")
    if org_for_pen=="":
        print("Engine Enterprise ID: "+decode_pen)
    else:
        print("Engine Enterprise ID: "+org_for_pen+" ("+decode_pen+")")
    print("Engine ID Format: "+decode_format)
    print("Engine ID Data: "+decode_data+"\n")

def internet_check(host1="8.8.8.8", host2="114.114.114.114", port=53, timeout=3):
    try:
        socket.setdefaulttimeout(timeout)
        if str(socket.socket(socket.AF_INET, socket.SOCK_STREAM).connect((host1, port)))=="None":
            return True
        elif str(socket.socket(socket.AF_INET, socket.SOCK_STREAM).connect((host2, port)))=="None":
            return True
    except socket.error as ex:
        return False

def decode_engineid(engineid):
    engineid_octet_reg=re.compile("^[a-fA-F0-9]{0,}$")
    is_engineid=engineid_octet_reg.match(engineid)
    if len(engineid)<10 or len(engineid)>64 or not is_engineid:
        print("ERROR: Engined id "+engineid+" is not an available one according to RFC3411!\n")
    else:
        decode_pen_hex=engineid[0:8]
        decode_dataformat_hex=engineid[8:10]
        decode_engineiddata_hex=engineid[10:]
        snmp_version=str(bin(int(decode_pen_hex, 16))[2:].zfill(32))[0:1]
        if snmp_version not in "1":
            print("ERROR: The engineID "+engineid+" is not for SNMPv3 according RFC3411!\n")
            sys.exit(1)
        else: 
            decode_pen_dec=str(int(bin(int(decode_pen_hex, 16))[2:].replace("1","0",1),2))
            org_for_pen=""
            if internet_check():
                pen_to_org_response = requests.get('http://www.iana.org/assignments/enterprise-numbers/?q='+decode_pen_dec)
                iana_parser = Parser()
                iana_parser.feed(str(pen_to_org_response.content).replace("\\n","").replace("b'","",2))
                org_for_pen=all_data[105].strip()
            decode_dataformat_dec=str(int(decode_dataformat_hex, 16))
            if decode_dataformat_dec in "1":
                if len(decode_engineiddata_hex) == 8:
                    x=2
                    ipv4_octet_arr=[decode_engineiddata_hex[y-x:y] for y in range(x, len(decode_engineiddata_hex)+x,x)]
                    decode_ipv4_addr=""
                    for i in ipv4_octet_arr:
                        decode_ipv4_addr=decode_ipv4_addr+(str(int(i, 16)))+"."
                    decode_print(decode_pen_dec,org_for_pen,decode_dataformat_dec+" - IPv4 address", decode_ipv4_addr[:-1])
                else:
                    decode_print(decode_pen_dec,org_for_pen,decode_dataformat_dec+" - IPv4 address", "ERROR: Data "+decode_engineiddata_hex+" is not a validated IPv4!")
            elif decode_dataformat_dec in "2":
                if len(decode_engineiddata_hex) == 32:
                    x=4
                    ipv6_octet_arr=[decode_engineiddata_hex[y-x:y] for y in range(x, len(decode_engineiddata_hex)+x,x)]
                    decode_ipv6_addr=""
                    for i in ipv6_octet_arr:
                        decode_ipv6_addr=decode_ipv6_addr+i+":"
                    decode_print(decode_pen_dec,org_for_pen,decode_dataformat_dec+" - IPv6 address",  ipaddress.ip_address(decode_ipv6_addr[:-1]).compressed+" ("+decode_ipv6_addr[:-1]+")")
                else:
                    decode_print(decode_pen_dec,org_for_pen,decode_dataformat_dec+" - IPv6 address", "ERROR: Data "+decode_engineiddata_hex+" is not a validated IPv6!")
            elif decode_dataformat_dec in "3":
                if len(decode_engineiddata_hex) == 12:
                    x=2
                    mac_addr_octet_arr=[decode_engineiddata_hex[y-x:y] for y in range(x, len(decode_engineiddata_hex)+x,x)]
                    decode_mac_addr=""
                    for i in mac_addr_octet_arr:
                        decode_mac_addr=decode_mac_addr+i+":"
                    decode_print(decode_pen_dec,org_for_pen,decode_dataformat_dec+" - MAC address",  decode_mac_addr[:-1])
                else:
                    decode_print(decode_pen_dec,org_for_pen,decode_dataformat_dec+" - MAC address", "ERROR: Data "+decode_engineiddata_hex+" is not a validated MAC address!")
            elif decode_dataformat_dec in "4":
                if len(decode_engineiddata_hex) <= 54:
                    try:
                        x=2
                        text_octet_arr=[decode_engineiddata_hex[y-x:y] for y in range(x, len(decode_engineiddata_hex)+x,x)]
                        decode_text=""
                        decode_failed_octed=""
                        for i in text_octet_arr:
                            if len(i) == 2:
                                decode_text=decode_text+bytearray.fromhex(i).decode()
                            else:
                                decode_failed_octed=decode_failed_octed+i
                        decode_print(decode_pen_dec,org_for_pen,decode_dataformat_dec+" - Text, administratively assigned",decode_text)
                        if decode_failed_octed!="":
                            print("The worked engineID should be "+engineid[:-len(decode_failed_octed)]+"\n")
                    except:
                        decode_print(decode_pen_dec,org_for_pen,decode_dataformat_dec+" - Text, administratively assigned", "ERROR: Data "+decode_engineiddata_hex+" is not a validated UTF-8 format!")               
                else:
                    decode_print(decode_pen_dec,org_for_pen,decode_dataformat_dec+" - Text, administratively assigned", "ERROR: Engined id "+engineid+" is not an available one according to RFC3411!\n")
            else:
                decode_print(decode_pen_dec,org_for_pen,"Note: "+decode_dataformat_dec+" is not a common format", decode_engineiddata_hex)

def to_hex_pen(pen):
    pen_bin = "{0:b}".format(int(pen))
    while len(pen_bin) <=31:
        if len(pen_bin) < 31:
            pen_bin = "0" + pen_bin
        elif len(pen_bin) == 31:
            pen_bin ="1"+ pen_bin 
    pen_hex=hex(int(pen_bin, 2)).split('0x')[1] 
    return pen_hex

def to_hex_format(dataformat):
    dataformat_hex=hex(int(dataformat)).split('0x')[1] 
    while len(dataformat_hex) < 2:
        dataformat_hex = "0" + dataformat_hex
    return dataformat_hex 

def format_data_unmatch_error():
    print("ERROR: engine ID Data is not matched with the data format!")
    print ("    1 - IPv4 address")
    print ("    2 - IPv6 address")
    print ("    3 - MAC address")
    print ("    4 - Text, admin assgined with maximum length 27")
    sys.exit(1)

def format(pen, dataformat, engineiddata):
    if int(pen) not in range(0,100000):
        print("ERROR: pen is not an integer or not in range 0 to 99999 ")
        sys.exit(1)
    if int(dataformat) not in range(1,5):
        print("ERROR: Engine ID format is not an integer or not in range 1 to 4 ")
        sys.exit(1)  
    
    if int(dataformat) == 1:
        ipv4_reg = re.compile("^(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))$")
        is_ipv4 = ipv4_reg.match(engineiddata)
        if is_ipv4:
            pen_hex=to_hex_pen(pen)
            dataformat_hex=to_hex_format(dataformat)
            ipv4_arr=engineiddata.split(".")
            ipv4_hex = ""
            for ipv4Index in ipv4_arr:
                ipv4Index_hex=hex(int(ipv4Index)).split('0x')[1] 
                while len(ipv4Index_hex) < 2:
                    ipv4Index_hex = "0" + ipv4Index_hex
                ipv4_hex +=ipv4Index_hex
            engineid=pen_hex+dataformat_hex+ipv4_hex
            print("\nIPv4: "+engineiddata+", EngineID: "+engineid+"\n")           
        else:
            format_data_unmatch_error()
    elif int(dataformat) == 2:
        ipv6_reg=re.compile("^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))(%.+)?\s*$")
        is_ipv6=ipv6_reg.match(engineiddata)
        if is_ipv6:
            pen_hex=to_hex_pen(pen)
            dataformat_hex=to_hex_format(dataformat)
            ipv6_addr_full=ipaddress.ip_address(engineiddata).exploded
            ipv6_arr=ipv6_addr_full.split(":")
            ipv6_hex = ""
            for ipv6 in ipv6_arr:
                ipv6_hex = ipv6_hex + ipv6
            engineid=pen_hex+dataformat_hex+ipv6_hex
            print("\nIPv6: "+engineiddata+", EngineID: "+engineid+"\n")  
        else:
            format_data_unmatch_error()
    elif int(dataformat) == 3:
        mac_addr_reg=re.compile("((^(?:[0-9A-Fa-f]{2}[:]){5})|(^(?:[0-9A-Fa-f]{2}[-]){5})|^(?:[0-9A-Fa-f]{10}))(?:[0-9A-Fa-f]{2})$")
        is_mac=mac_addr_reg.match(engineiddata)
        if is_mac:
            pen_hex=to_hex_pen(pen)
            dataformat_hex=to_hex_format(dataformat)
            mac_addr_arr=[]
            if ":" in engineiddata:
                mac_addr_arr=engineiddata.split(":")
            elif "-" in engineiddata:
                mac_addr_arr=engineiddata.split("-")
            mac_add_hex = ""
            for mac in mac_addr_arr:
                mac_add_hex = mac_add_hex + mac
            engineid=pen_hex+dataformat_hex+mac_add_hex
            print("\nMAC Address: "+engineiddata+", EngineID: "+engineid+"\n")  
        else:
            format_data_unmatch_error()
    elif int(dataformat) == 4:
        pen_hex=to_hex_pen(pen)
        dataformat_hex=to_hex_format(dataformat)

        if len(engineiddata) >27:
            print("ERROR: The length for admin assgined text should not exceed 27!")
            sys.exit(1)
        else:
            text_byte_arr=bytes(engineiddata, 'ascii')
            text_hex=""
            for text_byte in text_byte_arr:
                text_byte_to_hex=hex(int(text_byte)).split('0x')[1]  
                while len(text_byte_to_hex) < 2:
                    text_byte_to_hex = "0" + text_byte_to_hex
                text_hex = text_hex + text_byte_to_hex
            engineid=pen_hex+dataformat_hex+text_hex
            print("\nText assigned: "+engineiddata+", EngineID: "+engineid+"\n") 
    else:
        print("ERROR: Format not in the scope of this tool!")

if __name__ == '__main__':
    toolname=(str(sys.argv[0][sys.argv[0].rfind(os.sep) + 1:]).split("/")[-1])
    if len(sys.argv) < 2:
        print ("ERROR: missing mandatory parameters")
        usage(toolname)
    else:
        #args = sys.argv[1:]
        try:
            opts,args=getopt.getopt(sys.argv[1:],'p:f:d:e:h')
            pen = ""
            dataformat = ""
            engineiddata = ""
            for opt_name,opt_value in opts:
                if opt_name in ('-h'):
                    usage(toolname)
                    sys.exit(1)
                elif opt_name in ('-e'):
                    if opt_value != "":
                        decode_engineid(opt_value)
                    else:
                        print("ERROR: Engine ID cannot be empty!")
                    sys.exit(1)
                elif opt_name in ('-p','-f','-d'):
                    if opt_name in ('-p'):
                        pen=opt_value
                    elif opt_name in ('-f'):
                        dataformat=opt_value
                    elif opt_name in ('-d'):
                        engineiddata=opt_value
                else:
                    print("ERROR: Not available parameters")
                    usage(toolname)
            if pen!="" and dataformat!="" and engineiddata!="":
                format(pen,dataformat,engineiddata)
            else:
                print("ERROR: Not all mandatory parameters have value!")
                usage(toolname)
        except getopt.GetoptError as err:
            print("ERROR: %s \n"%err)
            usage(toolname)
    sys.exit(1)
#finished

