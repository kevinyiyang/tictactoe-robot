namespace tictactoe_robot
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.byte7Box = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.byte6Box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.COMComboBox = new System.Windows.Forms.ComboBox();
            this.sendDataButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.byte5Box = new System.Windows.Forms.TextBox();
            this.byte4Box = new System.Windows.Forms.TextBox();
            this.byte3Box = new System.Windows.Forms.TextBox();
            this.byte2Box = new System.Windows.Forms.TextBox();
            this.byte1Box = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.fullByteBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.revRateBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rotCountBox = new System.Windows.Forms.TextBox();
            this.encBox5 = new System.Windows.Forms.TextBox();
            this.encBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pwmBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.encBox2 = new System.Windows.Forms.TextBox();
            this.encBox1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.encBox3 = new System.Windows.Forms.TextBox();
            this.runStepperNegativeButton = new System.Windows.Forms.Button();
            this.runStepperPositive = new System.Windows.Forms.Button();
            this.stopStepperButton = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.moveButton = new System.Windows.Forms.Button();
            this.moveYButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.deltaYBox = new System.Windows.Forms.TextBox();
            this.deltaXBox = new System.Windows.Forms.TextBox();
            this.moveXButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.OriginButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // byte7Box
            // 
            this.byte7Box.Location = new System.Drawing.Point(327, 86);
            this.byte7Box.Name = "byte7Box";
            this.byte7Box.Size = new System.Drawing.Size(44, 20);
            this.byte7Box.TabIndex = 159;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(329, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 158;
            this.label18.Text = "Delta Y";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(277, 67);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 13);
            this.label20.TabIndex = 157;
            this.label20.Text = "Delta X";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // byte6Box
            // 
            this.byte6Box.Location = new System.Drawing.Point(277, 86);
            this.byte6Box.Name = "byte6Box";
            this.byte6Box.Size = new System.Drawing.Size(44, 20);
            this.byte6Box.TabIndex = 156;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 155;
            this.label5.Text = "Data Bytes";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(234, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(131, 23);
            this.connectButton.TabIndex = 154;
            this.connectButton.Text = "Connect Serial";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.Connect_Click);
            // 
            // COMComboBox
            // 
            this.COMComboBox.FormattingEnabled = true;
            this.COMComboBox.Location = new System.Drawing.Point(12, 12);
            this.COMComboBox.Name = "COMComboBox";
            this.COMComboBox.Size = new System.Drawing.Size(196, 21);
            this.COMComboBox.TabIndex = 153;
            // 
            // sendDataButton
            // 
            this.sendDataButton.Location = new System.Drawing.Point(390, 83);
            this.sendDataButton.Name = "sendDataButton";
            this.sendDataButton.Size = new System.Drawing.Size(75, 23);
            this.sendDataButton.TabIndex = 152;
            this.sendDataButton.Text = "Send Bytes";
            this.sendDataButton.UseVisualStyleBackColor = true;
            this.sendDataButton.Click += new System.EventHandler(this.SendDataButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 151;
            this.label4.Text = "Replacement";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 150;
            this.label3.Text = "PWM Control";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 149;
            this.label2.Text = "Command";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 148;
            this.label1.Text = "Start";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // byte5Box
            // 
            this.byte5Box.Location = new System.Drawing.Point(211, 86);
            this.byte5Box.Name = "byte5Box";
            this.byte5Box.Size = new System.Drawing.Size(44, 20);
            this.byte5Box.TabIndex = 147;
            // 
            // byte4Box
            // 
            this.byte4Box.Location = new System.Drawing.Point(161, 86);
            this.byte4Box.Name = "byte4Box";
            this.byte4Box.Size = new System.Drawing.Size(44, 20);
            this.byte4Box.TabIndex = 146;
            // 
            // byte3Box
            // 
            this.byte3Box.Location = new System.Drawing.Point(111, 86);
            this.byte3Box.Name = "byte3Box";
            this.byte3Box.Size = new System.Drawing.Size(44, 20);
            this.byte3Box.TabIndex = 145;
            // 
            // byte2Box
            // 
            this.byte2Box.Location = new System.Drawing.Point(61, 86);
            this.byte2Box.Name = "byte2Box";
            this.byte2Box.Size = new System.Drawing.Size(44, 20);
            this.byte2Box.TabIndex = 144;
            // 
            // byte1Box
            // 
            this.byte1Box.Location = new System.Drawing.Point(11, 86);
            this.byte1Box.Name = "byte1Box";
            this.byte1Box.Size = new System.Drawing.Size(44, 20);
            this.byte1Box.TabIndex = 143;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(163, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 13);
            this.label15.TabIndex = 166;
            this.label15.Text = "DC Motor (X Axis)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fullByteBox
            // 
            this.fullByteBox.Location = new System.Drawing.Point(11, 220);
            this.fullByteBox.Name = "fullByteBox";
            this.fullByteBox.Size = new System.Drawing.Size(44, 20);
            this.fullByteBox.TabIndex = 164;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 163;
            this.label8.Text = "0";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 162;
            this.label7.Text = "Max CCW Speed";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 161;
            this.label6.Text = "Max CW Speed";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(40, 153);
            this.trackBar1.Maximum = 65535;
            this.trackBar1.Minimum = -65535;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(343, 45);
            this.trackBar1.TabIndex = 160;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // revRateBox
            // 
            this.revRateBox.Location = new System.Drawing.Point(131, 395);
            this.revRateBox.Name = "revRateBox";
            this.revRateBox.Size = new System.Drawing.Size(96, 20);
            this.revRateBox.TabIndex = 179;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(128, 375);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 178;
            this.label13.Text = "Rev/Sec";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 375);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 13);
            this.label12.TabIndex = 177;
            this.label12.Text = "Position (in revolutions)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(126, 310);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 176;
            this.label11.Text = "Overflow Count";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rotCountBox
            // 
            this.rotCountBox.Location = new System.Drawing.Point(126, 326);
            this.rotCountBox.Name = "rotCountBox";
            this.rotCountBox.Size = new System.Drawing.Size(44, 20);
            this.rotCountBox.TabIndex = 175;
            // 
            // encBox5
            // 
            this.encBox5.Location = new System.Drawing.Point(9, 352);
            this.encBox5.Name = "encBox5";
            this.encBox5.Size = new System.Drawing.Size(96, 20);
            this.encBox5.TabIndex = 174;
            // 
            // encBox4
            // 
            this.encBox4.Location = new System.Drawing.Point(9, 326);
            this.encBox4.Name = "encBox4";
            this.encBox4.Size = new System.Drawing.Size(96, 20);
            this.encBox4.TabIndex = 173;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(123, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 171;
            this.label10.Text = "PWM Slider Value";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pwmBox
            // 
            this.pwmBox.Location = new System.Drawing.Point(126, 279);
            this.pwmBox.Name = "pwmBox";
            this.pwmBox.Size = new System.Drawing.Size(90, 20);
            this.pwmBox.TabIndex = 170;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 169;
            this.label9.Text = "Encoder Bytes";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // encBox2
            // 
            this.encBox2.Location = new System.Drawing.Point(59, 279);
            this.encBox2.Name = "encBox2";
            this.encBox2.Size = new System.Drawing.Size(44, 20);
            this.encBox2.TabIndex = 168;
            // 
            // encBox1
            // 
            this.encBox1.Location = new System.Drawing.Point(9, 279);
            this.encBox1.Name = "encBox1";
            this.encBox1.Size = new System.Drawing.Size(44, 20);
            this.encBox1.TabIndex = 167;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 462);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 185;
            this.label17.Text = "Current X";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 439);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 184;
            this.label16.Text = "Position Control";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // encBox3
            // 
            this.encBox3.Location = new System.Drawing.Point(9, 478);
            this.encBox3.Name = "encBox3";
            this.encBox3.Size = new System.Drawing.Size(49, 20);
            this.encBox3.TabIndex = 183;
            // 
            // runStepperNegativeButton
            // 
            this.runStepperNegativeButton.Location = new System.Drawing.Point(496, 83);
            this.runStepperNegativeButton.Name = "runStepperNegativeButton";
            this.runStepperNegativeButton.Size = new System.Drawing.Size(150, 23);
            this.runStepperNegativeButton.TabIndex = 189;
            this.runStepperNegativeButton.Text = "Run in Negative Direction";
            this.runStepperNegativeButton.UseVisualStyleBackColor = true;
            this.runStepperNegativeButton.Click += new System.EventHandler(this.RunStepperNegativeButton_Click);
            // 
            // runStepperPositive
            // 
            this.runStepperPositive.Location = new System.Drawing.Point(840, 83);
            this.runStepperPositive.Name = "runStepperPositive";
            this.runStepperPositive.Size = new System.Drawing.Size(131, 23);
            this.runStepperPositive.TabIndex = 188;
            this.runStepperPositive.Text = "Run in Positive Direction";
            this.runStepperPositive.UseVisualStyleBackColor = true;
            this.runStepperPositive.Click += new System.EventHandler(this.RunStepperPositive_Click);
            // 
            // stopStepperButton
            // 
            this.stopStepperButton.Location = new System.Drawing.Point(676, 83);
            this.stopStepperButton.Name = "stopStepperButton";
            this.stopStepperButton.Size = new System.Drawing.Size(131, 23);
            this.stopStepperButton.TabIndex = 187;
            this.stopStepperButton.Text = "Stop Motor";
            this.stopStepperButton.UseVisualStyleBackColor = true;
            this.stopStepperButton.Click += new System.EventHandler(this.StopStepperButton_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(695, 50);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 13);
            this.label21.TabIndex = 186;
            this.label21.Text = "Stepper Motor (Y Axis)";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(828, 142);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(131, 61);
            this.moveButton.TabIndex = 197;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // moveYButton
            // 
            this.moveYButton.Location = new System.Drawing.Point(676, 179);
            this.moveYButton.Name = "moveYButton";
            this.moveYButton.Size = new System.Drawing.Size(131, 23);
            this.moveYButton.TabIndex = 196;
            this.moveYButton.Text = "Move Y";
            this.moveYButton.UseVisualStyleBackColor = true;
            this.moveYButton.Click += new System.EventHandler(this.MoveYButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(516, 235);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 20);
            this.textBox1.TabIndex = 195;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(569, 185);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 13);
            this.label22.TabIndex = 194;
            this.label22.Text = "Delta Y";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deltaYBox
            // 
            this.deltaYBox.Location = new System.Drawing.Point(617, 182);
            this.deltaYBox.Name = "deltaYBox";
            this.deltaYBox.Size = new System.Drawing.Size(44, 20);
            this.deltaYBox.TabIndex = 193;
            // 
            // deltaXBox
            // 
            this.deltaXBox.Location = new System.Drawing.Point(617, 147);
            this.deltaXBox.Name = "deltaXBox";
            this.deltaXBox.Size = new System.Drawing.Size(44, 20);
            this.deltaXBox.TabIndex = 192;
            // 
            // moveXButton
            // 
            this.moveXButton.Location = new System.Drawing.Point(676, 145);
            this.moveXButton.Name = "moveXButton";
            this.moveXButton.Size = new System.Drawing.Size(131, 23);
            this.moveXButton.TabIndex = 191;
            this.moveXButton.Text = "Move X";
            this.moveXButton.UseVisualStyleBackColor = true;
            this.moveXButton.Click += new System.EventHandler(this.MoveXButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(569, 150);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 13);
            this.label19.TabIndex = 190;
            this.label19.Text = "Delta X";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // OriginButton
            // 
            this.OriginButton.Location = new System.Drawing.Point(828, 217);
            this.OriginButton.Name = "OriginButton";
            this.OriginButton.Size = new System.Drawing.Size(131, 23);
            this.OriginButton.TabIndex = 198;
            this.OriginButton.Text = "Return to Origin";
            this.OriginButton.UseVisualStyleBackColor = true;
            this.OriginButton.Click += new System.EventHandler(this.OriginButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 571);
            this.Controls.Add(this.OriginButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.moveYButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.deltaYBox);
            this.Controls.Add(this.deltaXBox);
            this.Controls.Add(this.moveXButton);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.runStepperNegativeButton);
            this.Controls.Add(this.runStepperPositive);
            this.Controls.Add(this.stopStepperButton);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.encBox3);
            this.Controls.Add(this.revRateBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.rotCountBox);
            this.Controls.Add(this.encBox5);
            this.Controls.Add(this.encBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pwmBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.encBox2);
            this.Controls.Add(this.encBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.fullByteBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.byte7Box);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.byte6Box);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.COMComboBox);
            this.Controls.Add(this.sendDataButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.byte5Box);
            this.Controls.Add(this.byte4Box);
            this.Controls.Add(this.byte3Box);
            this.Controls.Add(this.byte2Box);
            this.Controls.Add(this.byte1Box);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox byte7Box;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox byte6Box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox COMComboBox;
        private System.Windows.Forms.Button sendDataButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox byte5Box;
        private System.Windows.Forms.TextBox byte4Box;
        private System.Windows.Forms.TextBox byte3Box;
        private System.Windows.Forms.TextBox byte2Box;
        private System.Windows.Forms.TextBox byte1Box;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox fullByteBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox revRateBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox rotCountBox;
        private System.Windows.Forms.TextBox encBox5;
        private System.Windows.Forms.TextBox encBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox pwmBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox encBox2;
        private System.Windows.Forms.TextBox encBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox encBox3;
        private System.Windows.Forms.Button runStepperNegativeButton;
        private System.Windows.Forms.Button runStepperPositive;
        private System.Windows.Forms.Button stopStepperButton;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button moveYButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox deltaYBox;
        private System.Windows.Forms.TextBox deltaXBox;
        private System.Windows.Forms.Button moveXButton;
        private System.Windows.Forms.Label label19;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button OriginButton;
    }
}

