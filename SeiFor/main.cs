using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace SeiFor
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            comboBox_engineIDFormat.SelectedIndex = 0;
            textBox_pen.Text = "193";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["about"];  //查找是否打开过about窗体  
            if ((f == null) || (f.IsDisposed)) //没打开过  
            {
                about fa = new();
                fa.Show();   //重新new一个Show出来
            }
            else
            {
                f.Activate();   //打开过就让其获得焦点  
                f.WindowState = FormWindowState.Normal;
            }
        }

        //验证输入的数据是不是正整数,传入字符串,返回true或者false
        static bool is_integer(string str)
        {
            Regex reg = new(@"^[0-9]\d*$");
            return reg.IsMatch(str);
        }

        //验证IPv4
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

        static string to_hex_pen(string pen)
        {
            string bin_pen = Convert.ToString(Convert.ToInt32(pen), 2);

            //检查二进制位数，补齐到32位，且最高位为1
            while (bin_pen.Length <= 31)
            {
                if (bin_pen.Length < 31)
                {
                    bin_pen = '0' + bin_pen;
                }
                else if (bin_pen.Length == 31)
                {
                    bin_pen = '1' + bin_pen;
                }
            }
            string hex_pen = string.Format("{0:x}", Convert.ToInt64(bin_pen, 2));
            return hex_pen;
        }

        static string to_hex_engineIDformat(string engineIDFormat)
        {
            string hex_engineIDformat = Convert.ToString(Convert.ToInt32(engineIDFormat), 16);
            //检查十六进制，补齐到两位
            while (hex_engineIDformat.Length < 2)
            {
                hex_engineIDformat = '0' + hex_engineIDformat;
            }
            return hex_engineIDformat;
        }

        private void engineID_result(string pen, string engineIDFormat, string[] engineIDData)
        {
            if (pen != "" && engineIDFormat != "" && engineIDData.Length != 0)
            {
                if (pen != "" && !is_integer(pen.ToString()))
                {
                    textBox_engineIDresult.Text = "The Private Enterprise Number must be an integer as assigned by the Internet Assigned Numbers Authority (IANA)";
                    textBox_engineIDresult.ForeColor = Color.Red;
                }
                else if (pen == "")
                {
                    pen = "The Private Enterprise Number cannot be empty";
                    textBox_engineIDresult.ForeColor = Color.Red;
                }

                if (engineIDFormat != "")
                {
                    engineIDFormat = engineIDFormat.Split("(")[0];
                }
                else
                {
                    textBox_engineIDresult.Text = " Engine ID Format is not selected!";
                }

                if (pen.Length < 6 && (Convert.ToInt32(pen) >= 0) && (Convert.ToInt32(pen) <= 99999))
                {
                    if (engineIDData.Length > 0)
                    {
                        switch (engineIDFormat)
                        {
                            case "1": //for IPv4 format
                                textBox_engineIDresult.Text = "";
                                for (int ipv4Index = 0; ipv4Index < engineIDData.Length; ipv4Index++)
                                {
                                    string ipv4Addess = engineIDData[ipv4Index].Trim();
                                    if (is_ipv4(ipv4Addess))
                                    {
                                        string hex_pen = to_hex_pen(pen);

                                        string hex_engineIDformat = to_hex_engineIDformat(engineIDFormat);

                                        string[] ipv4Array = ipv4Addess.ToString().Split(".");
                                        string hex_ipv4 = "";
                                        for (int ipv4ArrIndex = 0; ipv4ArrIndex < ipv4Array.Length; ipv4ArrIndex++)
                                        {
                                            string hex_ipv4Arr = Convert.ToString(Convert.ToInt32(ipv4Array[ipv4ArrIndex]), 16);
                                            //检查十六进制，补齐到两位
                                            while (hex_ipv4Arr.Length < 2)
                                            {
                                                hex_ipv4Arr = '0' + hex_ipv4Arr;
                                            }
                                            hex_ipv4 += hex_ipv4Arr;
                                        }

                                        textBox_engineIDresult.Text += "IPv4:" + ipv4Addess + ", Engine ID: " + hex_pen.ToLower() + hex_engineIDformat.ToLower() + hex_ipv4.ToLower() + "\r\n";
                                    }
                                    else if (ipv4Addess != "")
                                    {
                                        textBox_engineIDresult.Text += "Note: " + ipv4Addess + " is not a validated IPv4. \r\n";
                                    }
                                }
                                break;
                            case "2": //for IPv6 format
                                textBox_engineIDresult.Text = "";
                                for (int ipv6Index = 0; ipv6Index < engineIDData.Length; ipv6Index++)
                                {
                                    string org_ipv6Address = engineIDData[ipv6Index].Trim();
                                    if (is_ipv6(org_ipv6Address))
                                    {
                                        string hex_pen = to_hex_pen(pen);

                                        string hex_engineIDformat = to_hex_engineIDformat(engineIDFormat);

                                        //补全ipv6，去掉冒号
                                        IPAddress ipv6address = IPAddress.Parse(org_ipv6Address);
                                        byte[] ipv6_octets = ipv6address.GetAddressBytes();
                                        string ipv6_hex_string = String.Join("", ipv6_octets.Select(x => string.Format("{0:X2}", x)));

                                        textBox_engineIDresult.Text += "IPv6: " + org_ipv6Address + ", Engine ID: " + hex_pen.ToLower() + hex_engineIDformat.ToLower() + ipv6_hex_string.ToLower() + "\r\n";
                                    }
                                    else if (org_ipv6Address != "")
                                    {
                                        textBox_engineIDresult.Text += "Note: " + org_ipv6Address + " is not a validated IPv6. \r\n";
                                    }
                                }
                                break;
                            case "3":  //for MAC format
                                textBox_engineIDresult.Text = "";
                                for (int macIndex = 0; macIndex < engineIDData.Length; macIndex++)
                                {
                                    string macAddress = engineIDData[macIndex].Trim();
                                    if (is_mac_addr(macAddress))
                                    {
                                        string hex_pen = to_hex_pen(pen);

                                        string hex_engineIDformat = to_hex_engineIDformat(engineIDFormat);

                                        string mac_add_replaced = "";

                                        var colon = ":";
                                        var hyphen = "-";
                                        if (macAddress.Contains(colon))
                                        {
                                            mac_add_replaced = macAddress.Replace(colon, "");
                                        }
                                        else if (macAddress.Contains(hyphen))
                                        {
                                            mac_add_replaced = macAddress.Replace(hyphen, "");
                                        }
                                        else
                                        {
                                            mac_add_replaced = macAddress;
                                        }

                                        textBox_engineIDresult.Text += "MAC Address: " + macAddress + ", Engine ID: " + hex_pen.ToLower() + hex_engineIDformat.ToLower() + mac_add_replaced.ToLower() + "\r\n";
                                    }
                                    else if (macAddress != "")
                                    {
                                        textBox_engineIDresult.Text += "Note: " + macAddress + " is not a validated MAC Address. \r\n";
                                    }
                                }
                                break;
                            case "4":  //for Text, administratively assigned Maximum remaining length 27
                                textBox_engineIDresult.Text = "";
                                for (int textIndex = 0; textIndex < engineIDData.Length; textIndex++)
                                {
                                    if (engineIDData[textIndex].Length <= 27)
                                    {

                                        string hex_pen = to_hex_pen(pen);

                                        string hex_engineIDformat = to_hex_engineIDformat(engineIDFormat);

                                        byte[] text_bytes = Encoding.UTF8.GetBytes(engineIDData[textIndex]);
                                        string text_hex = Convert.ToHexString(text_bytes).ToLower();

                                        textBox_engineIDresult.Text += "Admin assigned Text: " + engineIDData[textIndex] + ", Engine ID: " + hex_pen.ToLower() + hex_engineIDformat.ToLower() + text_hex.ToLower() + "\r\n";
                                    }
                                    else
                                    {
                                        textBox_engineIDresult.Text = " Note: " + engineIDData[textIndex] + " length should not exceed 27";
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        textBox_engineIDresult.Text = "No validated data for Engined ID Data";
                    }
                }
                else
                {
                    textBox_engineIDresult.Text = "The Private Enterprise Number is to large(0-99999)";
                }
            }
            else
            {
                textBox_engineIDresult.Text = "Not All mandatory parameters filled.";
            }
        }

        private void textBox_pen_KeyUp(object sender, KeyEventArgs e)
        {
            engineID_result(textBox_pen.Text, comboBox_engineIDFormat.Text, textBox_engineIDData.Lines);
        }

        private void textBox_engineIDData_KeyUp(object sender, KeyEventArgs e)
        {
            engineID_result(textBox_pen.Text, comboBox_engineIDFormat.Text, textBox_engineIDData.Lines);
        }

        private void comboBox_engineIDFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            engineID_result(textBox_pen.Text.Trim(), comboBox_engineIDFormat.Text.Trim(), textBox_engineIDData.Lines);
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

        private void decodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["decodeEngineId"];  //查找是否打开过about窗体  
            if ((f == null) || (f.IsDisposed)) //没打开过  
            {
                decodeEngineId fa = new();
                fa.Show();   //重新new一个Show出来
            }
            else
            {
                f.Activate();   //打开过就让其获得焦点  
                f.WindowState = FormWindowState.Normal;
            }
        }
    }
}