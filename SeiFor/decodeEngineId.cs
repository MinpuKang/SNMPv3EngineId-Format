using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SeiFor
{
    public partial class decodeEngineId : Form
    {
        public decodeEngineId()
        {
            InitializeComponent();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form f = Application.OpenForms["main"];  //查找是否打开过main窗体  
            if ((f == null) || (f.IsDisposed)) //没打开过  
            {
                main fa = new();
                fa.Show();   //重新new一个Show出来
            }
            else
            {
                f.Activate();   //打开过就让其获得焦点  
                f.WindowState = FormWindowState.Normal;
            }
        }

        static bool is_ipv4(string ip_v4)
        {
            //Regex reg = new Regex(@"(?n)^\s*(([1-9]?[0-9]|1[0-9]{2}|2([0-4][0-9]|5[0-5]))\.){3}([1-9]?[0-9]|1[0-9]{2}|2([0-4][0-9]|5[0-5]))\s*$");
            Regex reg = new(@"^(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))$");
            if (reg.IsMatch(ip_v4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //验证IPv6
        static bool is_ipv6(string ip_v6)
        {
            Regex reg = new(@"^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))(%.+)?\s*$");
            if (reg.IsMatch(ip_v6))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //验证mac address
        static bool is_mac_addr(string mac_addr)
        {
            Regex reg = new(@"((^(?:[0-9A-Fa-f]{2}[:]){5})|(^(?:[0-9A-Fa-f]{2}[-]){5})|^(?:[0-9A-Fa-f]{10}))(?:[0-9A-Fa-f]{2})$");
            if (reg.IsMatch(mac_addr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static byte[] HexStringToByteArray(string hexString)
        {
            int byteCount = hexString.Length / 2;
            byte[] byteArray = new byte[byteCount];

            for (int i = 0; i < byteCount; i++)
            {
                string byteString = hexString.Substring(i * 2, 2);
                byteArray[i] = byte.Parse(byteString, System.Globalization.NumberStyles.HexNumber);
            }

            return byteArray;
        }

        private void textBox_engineid_KeyUp(object sender, KeyEventArgs e)
        {
            textBox_dataformat.Text = "";
            textBox_conformance.Text = "";
            textBox_pen.Text = "";
            textBox_engineIDData.Text = "";

            string engineid = textBox_engineid.Text.Trim();
            if (engineid != "" && (engineid.Length >= 10 && engineid.Length <= 64) && (Regex.IsMatch(engineid, "^[a-fA-F0-9]{0,}$")))
            {
                //string extracted = s[startIndex..(endIndex + 1)];
                string hex_pen = engineid[0..8]; //get the letters from 0 to 7 
                string hex_dataformat = engineid[8..10]; //get the letters from 8 to 9
                string hex_engineiddata = engineid[10..]; //get the letters from 10 until end

                string bin_pen = Convert.ToString(Int64.Parse(hex_pen, System.Globalization.NumberStyles.HexNumber), 2);

                if (bin_pen[0..1] == "1") //get the first letter
                {
                    textBox_conformance.Text = "RFC3411(SNMPv3)";

                    string replaced_bin_pen = bin_pen.Remove(0, 1).Insert(0, "0");
                    string pen = Convert.ToInt32(replaced_bin_pen, 2).ToString();

                    textBox_pen.Text = pen;

                    string dataformat = Convert.ToInt32(hex_dataformat, 16).ToString();

                    textBox_dataformat.Text = dataformat;

                    switch (dataformat)
                    {
                        case "1": //for IPv4 format
                            textBox_dataformat.Text = "1 - IPv4 address";
                            if (hex_engineiddata.Length == 8)
                            {
                                string ipv4Address = "";
                                MatchCollection matchCollection = Regex.Matches(hex_engineiddata, @"\w{" + 2 + "}");
                                string[] data_arrary = matchCollection.Cast<Match>().Select(m => m.Groups[0].Value).ToArray();

                                for (int dataIndex = 0; dataIndex < data_arrary.Length; dataIndex++)
                                {
                                    if (dataIndex != data_arrary.Length - 1)
                                    {
                                        ipv4Address += Convert.ToInt32(data_arrary[dataIndex], 16).ToString() + ".";
                                    }
                                    else
                                    {
                                        ipv4Address += Convert.ToInt32(data_arrary[dataIndex], 16).ToString();
                                    }
                                }
                                if (is_ipv4(ipv4Address))
                                {
                                    textBox_engineIDData.Text = ipv4Address;
                                }
                                else
                                {
                                    textBox_engineIDData.Text = "Format is IPv4, but data is not a validated IPv4!";
                                }
                            }
                            else
                            {
                                textBox_engineIDData.Text = "Format is IPv4, but data is not a validated IPv4!";
                            }
                            break;
                        case "2": //for IPv6 format
                            textBox_dataformat.Text = "2 - IPv6 address";
                            if (hex_engineiddata.Length == 32)
                            {
                                string ipv6Address = "";
                                MatchCollection matchCollection = Regex.Matches(hex_engineiddata, @"\w{" + 4 + "}");
                                string[] data_arrary = matchCollection.Cast<Match>().Select(m => m.Groups[0].Value).ToArray();

                                for (int dataIndex = 0; dataIndex < data_arrary.Length; dataIndex++)
                                {
                                    if (dataIndex != data_arrary.Length - 1)
                                    {
                                        ipv6Address += data_arrary[dataIndex] + ":";
                                    }
                                    else
                                    {
                                        ipv6Address += data_arrary[dataIndex];
                                    }
                                }
                                if (is_ipv6(ipv6Address))
                                {
                                    textBox_engineIDData.Text = IPAddress.Parse(ipv6Address).ToString();
                                }
                                else
                                {
                                    textBox_engineIDData.Text = "Format is IPv6, but data is not a validated IPv6!";
                                }
                            }
                            else
                            {
                                textBox_engineIDData.Text = "Format is IPv6, but data is not a validated IPv6!";
                            }
                            break;
                        case "3":  //for MAC format
                            textBox_dataformat.Text = "3 - MAC address";
                            if (hex_engineiddata.Length == 12)
                            {
                                string macAddress = "";
                                MatchCollection matchCollection = Regex.Matches(hex_engineiddata, @"\w{" + 2 + "}");
                                string[] data_arrary = matchCollection.Cast<Match>().Select(m => m.Groups[0].Value).ToArray();

                                for (int dataIndex = 0; dataIndex < data_arrary.Length; dataIndex++)
                                {
                                    if (dataIndex != data_arrary.Length - 1)
                                    {
                                        macAddress += data_arrary[dataIndex] + ":";
                                    }
                                    else
                                    {
                                        macAddress += data_arrary[dataIndex];
                                    }
                                }
                                if (is_mac_addr(macAddress))
                                {
                                    textBox_engineIDData.Text = macAddress;
                                }
                                else
                                {
                                    textBox_engineIDData.Text = "Format is MAC, but data is not a validated MAC!";
                                }
                            }
                            else
                            {
                                textBox_engineIDData.Text = "Format is MAC, but data is not a validated MAC!";
                            }
                            break;
                        case "4":  //for Text, administratively assigned Maximum remaining length 27
                            textBox_dataformat.Text = "4 - Text, administratively assigned";
                            byte[] hexBytes = HexStringToByteArray(hex_engineiddata); // convert the hexadecimal string to a byte array
                            string textdecodedString = Encoding.UTF8.GetString(hexBytes); // decode the byte array into a string using UTF8 encoding
                            textBox_engineIDData.Text = textdecodedString;
                            break;
                        default:
                            textBox_dataformat.Text = dataformat + " as format is not in ofen used!";
                            textBox_engineIDData.Text = hex_engineiddata;
                            break;
                    }
                }
                else
                {
                    textBox_conformance.Text = "Note: engineID is not for SNMPv3";
                }
            }
            else
            {
                textBox_engineIDData.Text = "Note: engineID is not correct, hexadecimal required and length is from 10 to 64!";
            }
        }

        private void linkLabel_iana_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox_pen.Text != "")
            {
                var enterpriseNumber = textBox_pen.Text;

                // construct the search URL
                var searchUrl = "https://www.iana.org/assignments/enterprise-numbers/";
                searchUrl += "?q=" + enterpriseNumber;

                // open the search URL in the default web browser
                Process.Start(new ProcessStartInfo(searchUrl) { UseShellExecute = true });
            }
            else
            {
                Process.Start(new ProcessStartInfo("https://www.iana.org/assignments/enterprise-numbers/") { UseShellExecute = true });
            }
        }
    }
}