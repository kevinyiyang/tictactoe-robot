using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace tictactoe_robot
{
    public partial class Form1 : Form
    {
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();

        int dataState = 0;
        int encoderUpper = 0;
        int encoderLower = 0;

        int position = 0;

        int rotationCount = 0;
        int t = 0;

        int newByte = 0;

        public Form1()
        {
            InitializeComponent();
            // Queue for storing data


            // Set up COM ComboBox

            COMComboBox.Items.Clear();
            COMComboBox.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (COMComboBox.Items.Count == 0)
            {
                COMComboBox.Text = "No COM Ports";
            }
            else
                COMComboBox.SelectedIndex = 0;

            // Initialize bytes to default values
            byte1Box.Text = "255";
            byte2Box.Text = "2";
            byte3Box.Text = "0";
            byte4Box.Text = "0";
            byte5Box.Text = "0";
            byte6Box.Text = "0";
            byte7Box.Text = "0";

            deltaXBox.Text = "0";
            deltaYBox.Text = "0";
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            // Checks if port is open or closed
            if (serialPort1.IsOpen == false)
            {
                // Port is closed - assign PortName to the COM port selected in COMComboBox
                serialPort1.PortName = COMComboBox.SelectedItem.ToString();

                // Open port and change button text to "Disconnect"
                serialPort1.Open();
                connectButton.Text = "Disconnect Serial";
            }

            else
            {
                // Port is open - close port and change button text to "Connect"
                serialPort1.Close();
                connectButton.Text = "Connect Serial";
            }

            timer1.Enabled = true;
        }

        private void SendDataButton_Click(object sender, EventArgs e)
        {
            byte[] TxBytes = new Byte[5];

            try
            {
                if (serialPort1.IsOpen)
                {

                    TxBytes[0] = Convert.ToByte(byte1Box.Text);
                    serialPort1.Write(TxBytes, 0, 1);

                    TxBytes[1] = Convert.ToByte(byte2Box.Text);
                    serialPort1.Write(TxBytes, 1, 1);

                    TxBytes[2] = Convert.ToByte(byte3Box.Text);
                    serialPort1.Write(TxBytes, 2, 1);

                    TxBytes[3] = Convert.ToByte(byte4Box.Text);
                    serialPort1.Write(TxBytes, 3, 1);

                    TxBytes[4] = Convert.ToByte(byte5Box.Text);
                    serialPort1.Write(TxBytes, 4, 1);

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            // Convert trackbar1 value to binary

            bool reverse = false;

            int num = Convert.ToInt32(trackBar1.Value);
            if (num < 0)
            {
                reverse = true;
                num = -num;
                byte2Box.Text = "1";
            }

            else
            {
                byte2Box.Text = "0";
            }
            string result = string.Empty;
            int remainder;
            while (num > 1)
            {
                remainder = num % 2;
                result = remainder.ToString() + result;
                num = num / 2;
            }
            result = num.ToString() + result;


            string binaryVal = result;


            while (binaryVal.Length < 16)
            {
                binaryVal = "0" + binaryVal;
            }

            string upperBytes = binaryVal.Substring(0, 8);
            string lowerBytes = binaryVal.Substring(8, 8);

            byte3Box.Text = Convert.ToInt32(upperBytes, 2).ToString();
            byte4Box.Text = Convert.ToInt32(lowerBytes, 2).ToString();

            if (Convert.ToInt32(byte3Box.Text) != 255 && Convert.ToInt32(byte4Box.Text) != 255)
            {
                byte5Box.Text = "0";
            }

            else if (Convert.ToInt32(byte3Box.Text) != 255 && Convert.ToInt32(byte4Box.Text) == 255)
            {
                byte5Box.Text = "1";
                byte4Box.Text = "0";
            }

            else if (Convert.ToInt32(byte3Box.Text) == 255 && Convert.ToInt32(byte4Box.Text) != 255)
            {
                byte5Box.Text = "2";
                byte3Box.Text = "0";
            }

            else if (Convert.ToInt32(byte3Box.Text) == 255 && Convert.ToInt32(byte4Box.Text) == 255)
            {
                byte5Box.Text = "3";
                byte3Box.Text = "0";
                byte4Box.Text = "0";
            }

            int fullByteHigh = Convert.ToInt32(upperBytes) << 8;

            int fullByte = fullByteHigh |= Convert.ToInt32(lowerBytes);
            fullByteBox.Text = fullByte.ToString();

            byte6Box.Text = "0";
            byte7Box.Text = "0";

            SendBytes();
        }

        void SendBytes()
        {
            byte[] TxBytes = new Byte[7];

            try
            {
                if (serialPort1.IsOpen)
                {

                    TxBytes[0] = Convert.ToByte(byte1Box.Text);
                    serialPort1.Write(TxBytes, 0, 1);

                    TxBytes[1] = Convert.ToByte(byte2Box.Text);
                    serialPort1.Write(TxBytes, 1, 1);

                    TxBytes[2] = Convert.ToByte(byte3Box.Text);
                    serialPort1.Write(TxBytes, 2, 1);

                    TxBytes[3] = Convert.ToByte(byte4Box.Text);
                    serialPort1.Write(TxBytes, 3, 1);

                    TxBytes[4] = Convert.ToByte(byte5Box.Text);
                    serialPort1.Write(TxBytes, 4, 1);

                    TxBytes[5] = Convert.ToByte(byte6Box.Text);
                    serialPort1.Write(TxBytes, 5, 1);

                    TxBytes[6] = Convert.ToByte(byte7Box.Text);
                    serialPort1.Write(TxBytes, 6, 1);

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int bytesToRead = serialPort1.BytesToRead;

            while (bytesToRead != 0)
            {
                newByte = serialPort1.ReadByte();

                switch (dataState)
                {
                    case 0:
                        if (newByte == 255)
                        {
                            //encBox1.Text = newByte.ToString();
                            dataState = 1;
                        }
                        break;

                    case 1:
                        encoderUpper = newByte;
                        //encBox2.Text = encoderUpper.ToString();
                        dataState = 2;
                        break;

                    case 2:
                        encoderLower = newByte;
                        //encBox3.Text = encoderLower.ToString();
                        dataState = 3;
                        break;

                    case 3:
                        switch (newByte)
                        {
                            case 0:

                                break;

                            case 1:
                                encoderLower = 255;

                                break;

                            case 2:
                                encoderUpper = 255;

                                break;

                            case 3:
                                encoderLower = 255;
                                encoderUpper = 255;

                                break;

                        }

                        //encBox4.Text = newByte.ToString();
                        dataState = 4;
                        break;

                    case 4:
                        rotationCount = newByte;
                        dataState = 0;
                        break;


                    default:
                        break;

                }

                // Check if there are still bytes to read
                bytesToRead = serialPort1.BytesToRead;
            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int previousPosition = position;

            encBox1.Text = encoderUpper.ToString();
            encBox2.Text = encoderLower.ToString();

            int upperBinary = ConvertToBinary(encoderUpper);
            int lowerBinary = ConvertToBinary(encoderLower);

            string upperBinaryString = upperBinary.ToString();
            string lowerBinaryString = lowerBinary.ToString();

            if (upperBinaryString.Length < 8)
            {
                for (int s = upperBinaryString.Length; s < 8; s++)
                {
                    upperBinaryString = "0" + upperBinaryString;
                }
            }
            if (lowerBinaryString.Length < 8)
            {
                for (int s = lowerBinaryString.Length; s < 8; s++)
                {
                    lowerBinaryString = "0" + lowerBinaryString;
                }
            }

            position = Convert.ToInt32(upperBinaryString + lowerBinaryString, 2) + rotationCount * 50000;
            encBox3.Text = position.ToString();

            encBox4.Text = upperBinaryString;
            encBox5.Text = lowerBinaryString;

            pwmBox.Text = trackBar1.Value.ToString();
            rotCountBox.Text = rotationCount.ToString();

            int revRate = position - previousPosition;
            revRateBox.Text = revRate.ToString();


            //chart1.Series["Position"].Points.AddXY(t, position);
            //chart2.Series["Rotation Rate"].Points.AddXY(trackBar1.Value, revRate);

            t++;

        }

        private int ConvertToBinary(int num)
        {
            string result = string.Empty;
            int remainder;
            while (num > 1)
            {
                remainder = num % 2;
                result = remainder.ToString() + result;
                num = num / 2;
            }
            result = num.ToString() + result;

            return (Convert.ToInt32(result));
        }

        private void Pwm25Button_Click(object sender, EventArgs e)
        {
            byte1Box.Text = "255";
            byte2Box.Text = "0";
            byte3Box.Text = "64";
            byte4Box.Text = "0";
            byte5Box.Text = "0";
            byte6Box.Text = "0";
            byte7Box.Text = "0";


            SendBytes();
        }

        private void Pwm50Button_Click(object sender, EventArgs e)
        {
            byte1Box.Text = "255";
            byte2Box.Text = "0";
            byte3Box.Text = "128";
            byte4Box.Text = "0";
            byte5Box.Text = "0";
            byte6Box.Text = "0";
            byte7Box.Text = "0";

            SendBytes();
        }

        private void Pwm75Button_Click(object sender, EventArgs e)
        {
            byte1Box.Text = "255";
            byte2Box.Text = "0";
            byte3Box.Text = "192";
            byte4Box.Text = "0";
            byte5Box.Text = "0";
            byte6Box.Text = "0";
            byte7Box.Text = "0";

            SendBytes();
        }

        private void Pwm100Button_Click(object sender, EventArgs e)
        {
            byte1Box.Text = "255";
            byte2Box.Text = "0";
            byte3Box.Text = "0";
            byte4Box.Text = "0";
            byte5Box.Text = "3";
            byte6Box.Text = "0";
            byte7Box.Text = "0";

            SendBytes();
        }

        private void StopMotorButton_Click(object sender, EventArgs e)
        {
            byte1Box.Text = "255";
            byte2Box.Text = "9";
            byte3Box.Text = "0";
            byte4Box.Text = "0";
            byte5Box.Text = "0";
            byte6Box.Text = "0";
            byte7Box.Text = "0";
            SendBytes();
        }

        private void MoveXButton_Click(object sender, EventArgs e)
        {
            byte1Box.Text = "255";
            byte3Box.Text = "40";
            byte4Box.Text = "0";
            byte5Box.Text = "0";

            if (Convert.ToInt32(deltaXBox.Text) < 0)
            {
                byte6Box.Text = (-Convert.ToInt32(deltaXBox.Text)).ToString();
                byte2Box.Text = "2";
                SendBytes();
            }

            else if (Convert.ToInt32(deltaXBox.Text) > 0)
            {
                byte6Box.Text = deltaXBox.Text;
                byte2Box.Text = "3";
                SendBytes();
            }
        }

        private void OriginButton_Click(object sender, EventArgs e)
        {
            byte1Box.Text = "255";
            byte2Box.Text = "8";
            byte3Box.Text = "0";
            byte4Box.Text = "0";
            byte5Box.Text = "0";
            byte6Box.Text = "0";
            byte7Box.Text = "0";

            SendBytes();
        }

        private void RunStepperNegativeButton_Click(object sender, EventArgs e)
        {
            byte1Box.Text = "255";
            byte2Box.Text = "10";
            byte3Box.Text = "0";
            byte4Box.Text = "0";
            byte5Box.Text = "0";
            byte6Box.Text = "0";
            byte7Box.Text = "0";

            SendBytes();
        }

        private void RunStepperPositive_Click(object sender, EventArgs e)
        {
            byte1Box.Text = "255";
            byte2Box.Text = "11";
            byte3Box.Text = "0";
            byte4Box.Text = "0";
            byte5Box.Text = "0";
            byte6Box.Text = "0";
            byte7Box.Text = "0";

            SendBytes();
        }

        private void StopStepperButton_Click(object sender, EventArgs e)
        {
            byte1Box.Text = "255";
            byte2Box.Text = "19";
            byte3Box.Text = "0";
            byte4Box.Text = "0";
            byte5Box.Text = "0";
            byte6Box.Text = "0";
            byte7Box.Text = "0";

            SendBytes();
        }

        private void MoveYButton_Click(object sender, EventArgs e)
        {

            byte1Box.Text = "255";
            byte3Box.Text = "0";
            byte4Box.Text = "0";
            byte5Box.Text = "0";

            if (Convert.ToInt32(deltaYBox.Text) < 0)
            {
                byte7Box.Text = (-Convert.ToInt32(deltaYBox.Text)).ToString();
                byte2Box.Text = "12";
                SendBytes();
            }

            else if (Convert.ToInt32(deltaYBox.Text) > 0)
            {
                byte7Box.Text = deltaYBox.Text;
                byte2Box.Text = "13";
                SendBytes();
            }
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            int xDirection = 0;
            int yDirection = 0;

            byte1Box.Text = "255";
            //byte3Box.Text = "45";
            byte4Box.Text = "0";
            byte5Box.Text = "0";

            if (Convert.ToInt32(deltaXBox.Text) < 0)
            {
                byte6Box.Text = (2 * (-Convert.ToInt32(deltaXBox.Text))).ToString();
                xDirection = 0;

            }

            else if (Convert.ToInt32(deltaXBox.Text) > 0)
            {
                byte6Box.Text = (2 * (Convert.ToInt32(deltaXBox.Text))).ToString();

                xDirection = 1;

            }


            if (Convert.ToInt32(deltaYBox.Text) < 0)
            {
                byte7Box.Text = (2 * (-Convert.ToInt32(deltaYBox.Text))).ToString();

                yDirection = 0;

            }

            else if (Convert.ToInt32(deltaYBox.Text) > 0)
            {
                byte7Box.Text = (2 * (Convert.ToInt32(deltaYBox.Text))).ToString();

                yDirection = 1;

            }

            switch (xDirection)
            {
                case 0:

                    if (yDirection == 0)
                    {
                        byte2Box.Text = "30";
                    }

                    else if (yDirection == 1)
                    {
                        byte2Box.Text = "31";
                    }
                    break;

                case 1:
                    if (yDirection == 0)
                    {
                        byte2Box.Text = "32";
                    }

                    else if (yDirection == 1)
                    {
                        byte2Box.Text = "33";
                    }
                    break;

            }

            if (deltaYBox.Text == "0")
            {
                if (deltaXBox.Text == "0")
                {
                    byte3Box.Text = "0";
                }

                else
                {
                    byte3Box.Text = "40";
                }
            }

            else
            {
                int byte3Val = (int)((Math.Abs((Convert.ToDecimal(deltaXBox.Text)) / (Convert.ToDecimal(deltaYBox.Text)))) * 19 + 9);
                byte3Box.Text = byte3Val.ToString();
            }

            SendBytes();
        }
    }
}
