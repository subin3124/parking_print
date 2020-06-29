using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
namespace ParkingPrint
{

    public partial class Form1 : Form
    {
        string companyCod = "";  
        private static Mechatro _Mechatro = new Mechatro();
        public static int serial = 0;
        private SerialPort Mechatro_Port;
        public static int Print_CNT = 0;
        public static string code = "";
        public static string value = "";
        private byte[] recvBuf = new byte[24];
        private byte[] bufSerialSND;
        private byte[] Mechatro_Array = new byte[24];
        public static string serialNo = "";
        public static int serialNum = 0;
        

    public Form1()
        {
            InitializeComponent();
        }





        private void Form1_Load(object sender, EventArgs e)
        {
            this.MechatroPort_Open();
            

        }
        private void MechatroPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string str1 = "";
            byte[] numArray = new byte[1024];
            try
            {
                int count = this.MechatroPort.Read(numArray, 0, 1024);
                string str2 = str1 + Encoding.ASCII.GetString(numArray, 0, count);
                for (int index = 0; index < count; ++index)
                {
                    if (Convert.ToByte(str2[index]) == (byte)13 || Convert.ToByte(str2[index]) == (byte)10)
                    {
                        Mechatro.Mecha_i = 0;
                        Mechatro.Mecha_Str = "";
                    }
                    if (Mechatro.Mecha_i >= 23)
                        Mechatro.Mecha_i = 23;
                    if (Convert.ToByte(str2[index]) == (byte)3)
                    {
                        Mechatro.Mecha_i = 23;
                        Mechatro.Mecha_Str = "";
                    }
                    this.Mechatro_Array[Mechatro.Mecha_i] = Convert.ToByte(str2[index]);
                    ++Mechatro.Mecha_i;
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
            }
        }
        private void MechatroPort_Open()
        {
            this.MechatroPort.BaudRate = 9600;
            this.MechatroPort.DataBits = 8;
            this.MechatroPort.Parity = Parity.None;
            this.MechatroPort.StopBits = StopBits.One;
            this.MechatroPort.PortName = Global.BarcodePrint;
            try
            {
                this.MechatroPort.Close();
                this.MechatroPort.Open();
            }
            catch
            {
                int num = (int)MessageBox.Show("Mechatro 포트가 이미 사용 중입니다..!!");
            }
            if (this.MechatroPort.IsOpen)
                return;
            int num1 = (int)MessageBox.Show("Mechatro 포트를 연결하지 못했습니다....!!");
        }

        private void button1_Click(object sender, EventArgs e) //출력
        {
            Print_papers();
            disable_units();

        }

        private void button2_Click(object sender, EventArgs e) //멈춤
        {
            enabled_units();
        }
        private void disable_units()
        {
            parksale.Enabled = false;
            SelectSale.Enabled = false;
            cpn_w1.Enabled = false;
            cpn_w2.Enabled = false;
            cpn_w3.Enabled = false;
            cpn_w4.Enabled = false;
            cpn_w5.Enabled = false;
            cpn_w6.Enabled = false;
            sikcode.Enabled = false;
            StartNum.Enabled = false;
            Print_Num.Enabled = false;

        }
        private void enabled_units()
        {
            parksale.Enabled = true;
            SelectSale.Enabled = true;
            cpn_w1.Enabled = true;
            cpn_w2.Enabled = true;
            cpn_w3.Enabled = true;
            cpn_w4.Enabled = true;
            cpn_w5.Enabled = true;
            cpn_w6.Enabled = true;
            sikcode.Enabled = true;
            StartNum.Enabled = true;
            Print_Num.Enabled = true;

        }
        private void Print_papers()
        {

            int printN = Int32.Parse(Print_Num.Text);
            setCC();

            for(int i=0;i<=printN;i++)
            {
                Initialize_Print(); //출력기초선언
                // part1 출력
                Print_barcode();
                // part3 출력
            }
        } 
        private void Initialize_Print()
        {
            this.bufSerialSND = Form1._Mechatro.Mecha_Clear();
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
            this.bufSerialSND = Form1._Mechatro.Mecha_Density();
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
            this.bufSerialSND = Form1._Mechatro.Mecha_Size();
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
        }
       private void Print_Part1()
        {

        }
        private void Print_barcode()
        {
            this.bufSerialSND = Form1._Mechatro.Mecha_Barcode("195", "300", "128A", "180", "1", "0", "2", "8", DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + Form1.serialNo + companyCod + Global.OneHour);
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
        }
        private void setCC()
        {
            if (HangulHelper.IsHangul(cpn_w2.Text.Substring(0, 1).ToString()))
            {
                char[] tt = cpn_w2.Text.Substring(0, 1).ToCharArray();
                char[] elementArray = HangulHelper.DivideHangul(tt[0]);
                String comp = elementArray[0].ToString();
                companyCod = Compa(comp);
            }
            else
            {
                char[] ascii = cpn_w2.Text.Substring(0, 1).ToUpper().ToCharArray();
                companyCod = Convert.ToInt32(ascii[0]).ToString();
                Debug.WriteLine(companyCod);
                
            }
        }
        private String Compa(String comp)
        {
            char[] g = HangulHelper.DivideHangul('가');
            char[] n = HangulHelper.DivideHangul('나');
            char[] m = HangulHelper.DivideHangul('마');
            char[] b = HangulHelper.DivideHangul('바');
            char[] s = HangulHelper.DivideHangul('사');
            char[] o = HangulHelper.DivideHangul('아');
            char[] j = HangulHelper.DivideHangul('자');
            char[] c = HangulHelper.DivideHangul('차');
            char[] k = HangulHelper.DivideHangul('카');
            char[] t = HangulHelper.DivideHangul('타');
            char[] p = HangulHelper.DivideHangul('파');
            char[] h = HangulHelper.DivideHangul('하');
            char[] d = HangulHelper.DivideHangul('다');
            char[] L = HangulHelper.DivideHangul('라');
            if (comp == g[0].ToString())
                return "71";
            else if (comp == n[0].ToString())
                return "78";
            else if (comp == d[0].ToString())
                return "68";
            else if (comp == L[0].ToString())
                return "76";
            else if (comp == m[0].ToString())
                return "77";
            else if (comp == b[0].ToString())
                return "66";
            else if (comp == s[0].ToString())
                return "83";
            else if (comp == o[0].ToString())
                return "79";
            else if (comp == j[0].ToString())
                return "74";
            else if (comp == c[0].ToString())
                return "67";
            else if (comp == k[0].ToString())
                return "75";
            else if (comp == t[0].ToString())
                return "84";
            else if (comp == p[0].ToString())
                return "80";
            else if (comp == h[0].ToString())
                return "72";
            else
                return "00";
        }
    }
}
