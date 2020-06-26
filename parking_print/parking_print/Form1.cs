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


    }
}
