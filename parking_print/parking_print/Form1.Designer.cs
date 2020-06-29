namespace ParkingPrint
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MechatroPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.parksale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SelectSale = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.sikcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cpn_w6 = new System.Windows.Forms.TextBox();
            this.cpn_w5 = new System.Windows.Forms.TextBox();
            this.cpn_w4 = new System.Windows.Forms.TextBox();
            this.cpn_w3 = new System.Windows.Forms.TextBox();
            this.cpn_w2 = new System.Windows.Forms.TextBox();
            this.cpn_w1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.All_Printed = new System.Windows.Forms.Label();
            this.Print_Num = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.StartNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.parksale);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(41, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "주차권 및 할인권 구분";
            // 
            // parksale
            // 
            this.parksale.FormattingEnabled = true;
            this.parksale.Items.AddRange(new object[] {
            "주차권",
            "할인권"});
            this.parksale.Location = new System.Drawing.Point(118, 40);
            this.parksale.Name = "parksale";
            this.parksale.Size = new System.Drawing.Size(156, 26);
            this.parksale.TabIndex = 1;
            this.parksale.SelectedIndexChanged += new System.EventHandler(this.parksale_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "구   분";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SelectSale);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(41, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 99);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "할인권 설정";
            // 
            // SelectSale
            // 
            this.SelectSale.FormattingEnabled = true;
            this.SelectSale.Items.AddRange(new object[] {
            "30분",
            "1시간",
            "2시간",
            "전액무료"});
            this.SelectSale.Location = new System.Drawing.Point(118, 40);
            this.SelectSale.Name = "SelectSale";
            this.SelectSale.Size = new System.Drawing.Size(156, 26);
            this.SelectSale.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "할인권 선택";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox4);
            this.groupBox3.Controls.Add(this.checkBox5);
            this.groupBox3.Controls.Add(this.checkBox6);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.sikcode);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cpn_w6);
            this.groupBox3.Controls.Add(this.cpn_w5);
            this.groupBox3.Controls.Add(this.cpn_w4);
            this.groupBox3.Controls.Add(this.cpn_w3);
            this.groupBox3.Controls.Add(this.cpn_w2);
            this.groupBox3.Controls.Add(this.cpn_w1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(434, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 247);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "현장명 및 식별코드";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(274, 36);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(22, 21);
            this.checkBox4.TabIndex = 20;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(274, 74);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(22, 21);
            this.checkBox5.TabIndex = 19;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(274, 112);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(22, 21);
            this.checkBox6.TabIndex = 18;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(92, 112);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(22, 21);
            this.checkBox3.TabIndex = 17;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(92, 74);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(22, 21);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(92, 39);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(22, 21);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // sikcode
            // 
            this.sikcode.Location = new System.Drawing.Point(139, 184);
            this.sikcode.Name = "sikcode";
            this.sikcode.Size = new System.Drawing.Size(127, 28);
            this.sikcode.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "식별코드";
            // 
            // cpn_w6
            // 
            this.cpn_w6.Location = new System.Drawing.Point(312, 105);
            this.cpn_w6.Name = "cpn_w6";
            this.cpn_w6.Size = new System.Drawing.Size(113, 28);
            this.cpn_w6.TabIndex = 12;
            // 
            // cpn_w5
            // 
            this.cpn_w5.Location = new System.Drawing.Point(312, 71);
            this.cpn_w5.Name = "cpn_w5";
            this.cpn_w5.Size = new System.Drawing.Size(113, 28);
            this.cpn_w5.TabIndex = 10;
            // 
            // cpn_w4
            // 
            this.cpn_w4.Location = new System.Drawing.Point(312, 36);
            this.cpn_w4.Name = "cpn_w4";
            this.cpn_w4.Size = new System.Drawing.Size(113, 28);
            this.cpn_w4.TabIndex = 9;
            // 
            // cpn_w3
            // 
            this.cpn_w3.Location = new System.Drawing.Point(138, 105);
            this.cpn_w3.Name = "cpn_w3";
            this.cpn_w3.Size = new System.Drawing.Size(113, 28);
            this.cpn_w3.TabIndex = 6;
            // 
            // cpn_w2
            // 
            this.cpn_w2.Location = new System.Drawing.Point(138, 71);
            this.cpn_w2.Name = "cpn_w2";
            this.cpn_w2.Size = new System.Drawing.Size(113, 28);
            this.cpn_w2.TabIndex = 4;
            // 
            // cpn_w1
            // 
            this.cpn_w1.Location = new System.Drawing.Point(138, 36);
            this.cpn_w1.Name = "cpn_w1";
            this.cpn_w1.Size = new System.Drawing.Size(113, 28);
            this.cpn_w1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "업체명";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.Print_Num);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.StartNum);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(41, 387);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(793, 133);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "출력설정";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(301, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 37);
            this.button2.TabIndex = 6;
            this.button2.Text = "멈춤";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.All_Printed);
            this.groupBox5.Location = new System.Drawing.Point(681, 41);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(94, 65);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "총 매수";
            // 
            // All_Printed
            // 
            this.All_Printed.AutoSize = true;
            this.All_Printed.Location = new System.Drawing.Point(33, 33);
            this.All_Printed.Name = "All_Printed";
            this.All_Printed.Size = new System.Drawing.Size(18, 18);
            this.All_Printed.TabIndex = 0;
            this.All_Printed.Text = "0";
            // 
            // Print_Num
            // 
            this.Print_Num.Location = new System.Drawing.Point(553, 52);
            this.Print_Num.Name = "Print_Num";
            this.Print_Num.Size = new System.Drawing.Size(100, 28);
            this.Print_Num.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "출력 개수";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "출력";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartNum
            // 
            this.StartNum.Location = new System.Drawing.Point(160, 49);
            this.StartNum.Name = "StartNum";
            this.StartNum.Size = new System.Drawing.Size(100, 28);
            this.StartNum.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "시작 번호";
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(45, 542);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(788, 108);
            this.log.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 670);
            this.Controls.Add(this.log);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "주차권 출력 프로그램 ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort MechatroPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox parksale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox SelectSale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sikcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cpn_w6;
        private System.Windows.Forms.TextBox cpn_w5;
        private System.Windows.Forms.TextBox cpn_w4;
        private System.Windows.Forms.TextBox cpn_w3;
        private System.Windows.Forms.TextBox cpn_w2;
        private System.Windows.Forms.TextBox cpn_w1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox StartNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label All_Printed;
        private System.Windows.Forms.TextBox Print_Num;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

