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
using System.Threading;

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
        bool print = false;

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
            print = true;
            disable_units();
            Print_papers();
           

        }

        private void button2_Click(object sender, EventArgs e) //멈춤
        {
            print = false;
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
            button1.Enabled = false;
            button2.Enabled = true;

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
            button1.Enabled = true;
            button2.Enabled = false;

        }
        private void Print_papers()
        {
            Global.sikcode = sikcode.Text;
            serialNum = Int32.Parse(StartNum.Text);
            All_Printed.Text = serialNum.ToString();
            serialNo = serialNum.ToString("00000");
            int printN = Int32.Parse(Print_Num.Text);
            setCC();

            for(int i=1;i<=printN;i++)
            {
                Initialize_Print(); //출력기초선언
                Print_Part1(); // part1 출력
                Print_barcode(); //바코드 출력
                Print_Part3();  // part3 출력
                Print_box();
                Finish_Print(); //출력 주기 종료
                log.AppendText(serialNo + "번째 종이가 출력되었습니다."); //로그출력
                serialNum++; //시리얼 넘버 상승
                serialNo = serialNum.ToString("00000"); //시리얼 넘버를 문자열로
                Thread.Sleep(5000); // 5초간 정지
                if (!print)
                    break;
            }
            enabled_units();
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
        private void Finish_Print()
        {
            this.bufSerialSND = Form1._Mechatro.Mecha_Quantity("1", "1");
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
            this.bufSerialSND = Form1._Mechatro.Mecha_Clear();
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
        }
        private void Print_box()
        {
            this.bufSerialSND = Form1._Mechatro.Mecha_Box("130", "1", "525", "714", "2");
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
        }
       private void Print_Part1()
        {
            if (checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked)
            {
                Line1_w1();
                Line1_w2(130);
            }
            else
            {
                if (checkBox1.Checked)
                    Line1_w1();

                if (checkBox2.Checked)
                    Line1_w2(100);

                if (checkBox3.Checked)
                    Line1_w3();
            }

        }
        private void Print_Part3()
        {
            if (checkBox4.Checked)
                Line2_w1();
            if (checkBox5.Checked)
                Line2_w2();
            if (checkBox6.Checked)
                Line2_w3();
        }
        private void Line1_w1()
        {
            int Length = cpn_w1.Text.Length;
            int space_num = 315 - 30 * (Length - 1);
            this.bufSerialSND = Form1._Mechatro.Mecha_Text(space_num.ToString(), "30", "K", "0", "2", "2", cpn_w1.Text); //635
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
        }
        private void Line1_w2(int y)
        {
            int Length = cpn_w2.Text.Length;
            int space_num = 315 - 13* (Length - 1);
            this.bufSerialSND = Form1._Mechatro.Mecha_Text(space_num.ToString(), y.ToString(), "K", "0", "1.2", "1.2", cpn_w2.Text); //635
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
        }
        private void Line1_w3()
        {
            int Length = cpn_w3.Text.Length;
            int space_num = 315 - 13 * (Length - 1);
            this.bufSerialSND = Form1._Mechatro.Mecha_Text(space_num.ToString(), "165", "K", "0", "1.2", "1.2", cpn_w3.Text); //635 y위치 수정할것!
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
        }
        private void Line2_w1()
        {
            int Length = cpn_w4.Text.Length;
            int space_num = 315 - 13 * (Length - 1);
            this.bufSerialSND = Form1._Mechatro.Mecha_Text(space_num.ToString(), "525", "K", "0", "1.2", "1.2", cpn_w4.Text); //635
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
        }
        private void Line2_w2()
        {
            int Length = cpn_w5.Text.Length;
            int space_num = 315 - 13 * (Length - 1);
            this.bufSerialSND = Form1._Mechatro.Mecha_Text(space_num.ToString(), "575", "K", "0", "1.2", "1.2", cpn_w5.Text); //635
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
        }
        private void Line2_w3()
        {
            int Length = cpn_w6.Text.Length;
            int space_num = 315 - 13 * (Length - 1);
            this.bufSerialSND = Form1._Mechatro.Mecha_Text(space_num.ToString(), "625", "K", "0", "1.2", "1.2", cpn_w6.Text); //635
            this.MechatroPort.Write(this.bufSerialSND, 0, this.bufSerialSND.Length);
        }
        private void Print_barcode()
        {
            switch (parksale.SelectedItem.ToString())
            {
                case "주차권":
                    this.bufSerialSND = Form1._Mechatro.Mecha_Barcode("205", "250", "128A", "180", "1", "0", "2", "9", Global.yy + Global.sikcode + Form1.serialNo + companyCod + "0" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd"));
                    break;

                case "할인권":
                    switch (SelectSale.SelectedItem.ToString())
                    {
                        case "30분":
                            this.bufSerialSND = Form1._Mechatro.Mecha_Barcode("205", "250", "128A", "180", "1", "0", "2", "8", Global.yy + DateTime.Now.ToString("MM") + Global.dd + Form1.serialNo + companyCod + Global.Half);
                            break;
                        case "1시간":
                            this.bufSerialSND = Form1._Mechatro.Mecha_Barcode("205", "250", "128A", "180", "1", "0", "2", "8", Global.yy + DateTime.Now.ToString("MM") + Global.dd + Form1.serialNo + companyCod + Global.OneHour);
                            break;
                        case "2시간":
                            this.bufSerialSND = Form1._Mechatro.Mecha_Barcode("205", "250", "128A", "180", "1", "0", "2", "8", Global.yy + DateTime.Now.ToString("MM") + Global.dd + Form1.serialNo + companyCod + Global.TwoHours); //Global.MM
                            break;
                        case "전액무료":
                            this.bufSerialSND = Form1._Mechatro.Mecha_Barcode("205", "250", "128A", "180", "1", "0", "2", "9", Global.yy + DateTime.Now.ToString("MM") + Global.dd + Form1.serialNo + companyCod + Global.AllFree);
                            break;
                    }break;
            }

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

        private void parksale_SelectedIndexChanged(object sender, EventArgs e)
        {
           switch(parksale.SelectedItem.ToString())
            {
                case "주차권":
                    SelectSale.Enabled = false;
                    break;
                case "할인권":
                    SelectSale.Enabled = true;
                    break;

            }
        }
    }
}
