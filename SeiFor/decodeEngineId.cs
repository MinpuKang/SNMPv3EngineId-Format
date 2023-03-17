using System.Data;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net.Sockets;

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

        static string internet_check(string hostname, int port)
        {
            try
            {
                Socket socket = new(SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(hostname, port);
                string result = socket.Connected.ToString();
                return result;
            }
            catch (SocketException e)
            {
                return e.ToString();
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

        private void save_result(string result, SaveFileDialog saveFileDialog_result)
        {
            if (result != "")
            {
                //设置保存文件的格式
                saveFileDialog_result.Filter = "All files (*.*)|*.*|Normal txt files (*.txt)|*.txt";
                //设置默认文件类型显示顺序  
                saveFileDialog_result.FilterIndex = 2;
                //保存对话框是否记忆上次打开的目录  
                saveFileDialog_result.RestoreDirectory = true;
                saveFileDialog_result.FileName = DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + textBox_engineid.Text + "_decodeResult.txt";
                if (saveFileDialog_result.ShowDialog() == DialogResult.OK)
                {
                    //使用“另存为”对话框中输入的文件名实例化StreamWriter对象
                    StreamWriter sw = new(saveFileDialog_result.FileName, true);
                    //向创建的文件中写入内容
                    sw.WriteLine(textBox_result.Text);
                    //关闭当前文件写入流
                    sw.Close();
                    //获得文件路径
                    string savedFilePath = saveFileDialog_result.FileName.ToString();
                    if (MessageBox.Show("Config saved as: " + savedFilePath + "\r\n\r\nOpen or not?", "Decode Result", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //if (checkNodepadplus() == true)
                        //{
                        //    MessageBox.Show("Installed");
                        //    System.Diagnostics.Process.Start("notepad++.exe", savedFilePath);
                        //}
                        //else
                        //{
                        System.Diagnostics.Process.Start("notepad.exe", savedFilePath);
                        //}
                    }
                }
            }
            else
            {
                MessageBox.Show("No Result is decoded!", "Decode Result");
            }
        }

        private async void textBox_engineid_KeyUp(object sender, KeyEventArgs e)
        {
            string version = "";
            string pen_organization = "";
            string dataformat = "";
            string engineIdData = "";

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
                    version = "Engine ID Conformance: RFC3411(SNMPv3)";

                    string replaced_bin_pen = bin_pen.Remove(0, 1).Insert(0, "0");
                    string pen = Convert.ToInt32(replaced_bin_pen, 2).ToString();

                    string is_internet_connected = internet_check("8.8.8.8", 53);
                    if (is_internet_connected == "True")
                    {
                        string iana_url_pen = "http://www.iana.org/assignments/enterprise-numbers/?q=" + pen;
                        HttpClient client = new();
                        client.DefaultRequestHeaders.Add("User-Agent", "SeiFor");
                        HttpResponseMessage response = await client.GetAsync(iana_url_pen);
                        string responseBody = await response.Content.ReadAsStringAsync();
                        string[] responseBody_arr = responseBody.Split("\n");
                        pen_organization = responseBody_arr[178].Trim() + " (" + pen + ")";
                    }
                    else
                    {
                        //linkLabel_iana.Visible = true;
                        pen_organization = pen;
                    }

                    dataformat = Convert.ToInt32(hex_dataformat, 16).ToString();


                    switch (dataformat)
                    {
                        case "1": //for IPv4 format
                            dataformat = "1 - IPv4 address";
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
                                    engineIdData = ipv4Address;
                                }
                                else
                                {
                                    engineIdData = "Format is IPv4, but data is not a validated IPv4!";
                                }
                            }
                            else
                            {
                                engineIdData = "Format is IPv4, but data is not a validated IPv4!";
                            }
                            break;
                        case "2": //for IPv6 format
                            dataformat = "2 - IPv6 address";
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
                                    engineIdData = IPAddress.Parse(ipv6Address).ToString();
                                }
                                else
                                {
                                    engineIdData = "Format is IPv6, but data is not a validated IPv6!";
                                }
                            }
                            else
                            {
                                engineIdData = "Format is IPv6, but data is not a validated IPv6!";
                            }
                            break;
                        case "3":  //for MAC format
                            dataformat = "3 - MAC address";
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
                                    engineIdData = macAddress;
                                }
                                else
                                {
                                    engineIdData = "Format is MAC, but data is not a validated MAC!";
                                }
                            }
                            else
                            {
                                engineIdData = "Format is MAC, but data is not a validated MAC!";
                            }
                            break;
                        case "4":  //for Text, administratively assigned Maximum remaining length 27
                            dataformat = "4 - Text, administratively assigned";
                            byte[] hexBytes = HexStringToByteArray(hex_engineiddata); // convert the hexadecimal string to a byte array
                            string textdecodedString = Encoding.UTF8.GetString(hexBytes); // decode the byte array into a string using UTF8 encoding
                            engineIdData = textdecodedString;
                            break;
                        default:
                            dataformat += " as format is not in ofen used!";
                            engineIdData = hex_engineiddata;
                            break;
                    }

                    textBox_result.Text = "EngineID: " + engineid + "\r\nDecoded As Below: \r\n" + "    " + version + "\r\n" + "    Engine Enterprise ID: " + pen_organization + "\r\n" + "    Engine ID Format: " + dataformat + "\r\n" + "    Engine ID Data: " + engineIdData;

                }
                else
                {
                    textBox_result.Text = "Note: engineID is not for SNMPv3";
                }
            }
            else
            {
                textBox_result.Text = "Note: engineID is not correct, hexadecimal required and length is from 10 to 64!";
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            save_result(textBox_result.Text, saveFileDialog_result);
        }
    }
}