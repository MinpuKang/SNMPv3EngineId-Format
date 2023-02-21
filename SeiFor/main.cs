using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SeiFor
{
    public partial class main : Form
    {
        string initialResult;
        public main()
        {
            InitializeComponent();
            initialResult = textBox_engineIDresult.Text;
            comboBox_engineIDFormat.SelectedIndex = 0;
            textBox_pen.Text = "193";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["about"];  //查找是否打开过about窗体  
            if ((f == null) || (f.IsDisposed)) //没打开过  
            {
                about fa = new about();
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
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
            return reg1.IsMatch(str);
        }

        //验证IPv4
        public bool is_ipv4(string ip_v4)
        {
            //Regex reg = new Regex(@"(?n)^\s*(([1-9]?[0-9]|1[0-9]{2}|2([0-4][0-9]|5[0-5]))\.){3}([1-9]?[0-9]|1[0-9]{2}|2([0-4][0-9]|5[0-5]))\s*$");
            Regex reg = new Regex(@"^(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))$");
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
        public bool is_ipv6(string ip_v6)
        {
            Regex reg = new Regex(@"^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))(%.+)?\s*$");
            if (reg.IsMatch(ip_v6))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void engineID_result(string pen, string engineIDFormat, string[] engineIDData)
        {
            if (pen != "" && engineIDFormat != "" && engineIDData.Length != 0)
            {
                if (pen != "" && !is_integer(pen.ToString()))
                {
                    textBox_engineIDresult.Text = "The Private Enterprice Number must be an integer as assigned by the Internet Assigned Numbers Authority (IANA)";
                    textBox_engineIDresult.ForeColor = Color.Red;
                }
                else if (pen == "")
                {
                    pen = "The Private Enterprice Number cannot be empty";
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

                if (engineIDData.Length > 0)
                {
                    if (engineIDFormat == "1") //for IPv4 format
                    {
                        textBox_engineIDresult.Text = "";
                        for (int ipv4Index = 0; ipv4Index < engineIDData.Length; ipv4Index++)
                        {
                            if (is_ipv4(engineIDData[ipv4Index]))
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

                                string hex_engineIDformat = Convert.ToString(Convert.ToInt32(engineIDFormat), 16);
                                //检查十六进制，补齐到两位
                                while (hex_engineIDformat.Length < 2)
                                {
                                    hex_engineIDformat = '0' + hex_engineIDformat;
                                }

                                string[] ipv4Array = engineIDData[ipv4Index].ToString().Split(".");
                                string hex_ipv4 = "";
                                for (int ipv4ArrIndex = 0; ipv4ArrIndex < ipv4Array.Length; ipv4ArrIndex++)
                                {
                                    string hex_ipv4Arr = Convert.ToString(Convert.ToInt32(ipv4Array[ipv4ArrIndex]), 16);
                                    //检查十六进制，补齐到两位
                                    while (hex_ipv4Arr.Length < 2)
                                    {
                                        hex_ipv4Arr = '0' + hex_ipv4Arr;
                                    }
                                    hex_ipv4 = hex_ipv4 + hex_ipv4Arr;
                                }

                                textBox_engineIDresult.Text += "IPv4:" + engineIDData[ipv4Index] + ", Engine ID: " + hex_pen + hex_engineIDformat + hex_ipv4 + "\r\n";
                            }
                            else if (engineIDData[ipv4Index] != "")
                            {
                                textBox_engineIDresult.Text += "Note: " + engineIDData[ipv4Index] + " is not a validated IPv4. \r\n";
                            }
                        }
                    }
                }
                else
                {
                    textBox_engineIDresult.Text = "No validated data for Engined ID Data";
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
            engineID_result(textBox_pen.Text, comboBox_engineIDFormat.Text, textBox_engineIDData.Lines);
        }

        private void linkLabel_iana_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.iana.org/assignments/enterprise-numbers/") { UseShellExecute = true });
        }
    }
}