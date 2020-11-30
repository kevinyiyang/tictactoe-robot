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
using System.Threading;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;


using System.Diagnostics;



namespace tictactoe_robot
{
    public partial class Form1 : Form
    {
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();

        int[,] gamestate = new int[3, 3];

        // Current player state variable
        // 0: Human
        // 1: Computer
        int currentPlayer = 0;

        int dataState = 0;
        int newByte = 0;

        int x_pos = 100;
        int y_pos = 100;

      
           
        


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

            // Initialize board display
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    gamestate[i, j] = 0;
                }
            }

            UpdateGameState();





           





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
                timer1.Enabled = false;
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

        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int bytesToRead = serialPort1.BytesToRead;

            while (bytesToRead != 0)
            {
                newByte = serialPort1.ReadByte();
                dataQueue.Enqueue(newByte);
                // Check if there are still bytes to read
                bytesToRead = serialPort1.BytesToRead;
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
            //fullByteBox.Text = fullByte.ToString();

            byte6Box.Text = "0";
            byte7Box.Text = "0";

            SendBytes();
        }
       
        private void SendBytes()
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                foreach (int i in dataQueue)
                {
                    // Dequeue all data in dataQueue byte by byte and store in value
                    dataQueue.TryDequeue(out int value);

                    switch (dataState)
                    {
                        case 0:
                            if (value == 255)
                            {
                                textBox1.Text = value.ToString();
                                dataState = 1;
                            }
                            break;

                        case 1:
                            x_pos = value;
                            xPositionTextBox.Text = value.ToString();
                            textBox2.Text = value.ToString();
                            dataState = 2;
                            break;

                        case 2:
                            y_pos = value;
                            yPositionTextBox.Text = value.ToString();
                            textBox3.Text = value.ToString();
                            dataState = 0;
                            break;

                        default:
                            break;
                    }
                }
            }
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

            MovePlatform(Convert.ToInt32(deltaXBox.Text), Convert.ToInt32(deltaYBox.Text));
           
        }

        private void MovePlatform(int delta_x, int delta_y)
        {
           
            int xDirection = 0;
            int yDirection = 0;

            byte1Box.Text = "255";
            //byte3Box.Text = "45";
            byte4Box.Text = "0";
            byte5Box.Text = "0";

            if (delta_x < 0)
            {
                byte6Box.Text = (-delta_x).ToString();
                xDirection = 0;
            }

            else if (delta_x > 0)
            {
                byte6Box.Text = (delta_x).ToString();
                xDirection = 1;
            }


            if (delta_y < 0)
            {
                byte7Box.Text = (-delta_y).ToString();
                yDirection = 0;
            }

            else if (delta_y > 0)
            {
                byte7Box.Text = (delta_y).ToString();
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

            if (delta_y == 0)
            {

                byte7Box.Text = "0";

                if (delta_x == 0)
                {
                    byte6Box.Text = "0";
                    byte3Box.Text = "0";
                }

                else
                {
                    byte3Box.Text = "40";
                }
            }

            else
            {
                int byte3Val = (int)((Math.Abs(delta_x)) / (int)(Math.Abs(delta_y)) * 19 + 9);
                byte3Box.Text = byte3Val.ToString();
            }

            SendBytes();

            readyTextBox.Text = "Ready";
        }

        private void DrawTriangle(int x_start, int y_start)
        {

           
            MovePlatform(5, 5);


            Thread.Sleep(5000);

            MovePlatform(5, -5);

            Thread.Sleep(5000);

            MovePlatform(-10, 0);

            //while ((x_pos != (x_start + 10)) && (y_pos != (y_start))) {
            //    Thread.Sleep(1000);
            //};

            //MovePlatform(-10, 0);

            //while ((x_pos != (x_start)) && (y_pos != (y_start))) { };
        }

        private void DrawSquare(int x_start, int y_start)
        {
            MovePlatform(0, 8);


            Thread.Sleep(5000);

            MovePlatform(8, 0);

            Thread.Sleep(5000);

            MovePlatform(0, -8);


            Thread.Sleep(5000);

            MovePlatform(-8, 0);
        }
        private void DrawTriangleButton_Click(object sender, EventArgs e)
        {
            DrawTriangle(x_pos, y_pos);

        }

        private void DrawSquareButton_Click(object sender, EventArgs e)
        {
            DrawSquare(x_pos, y_pos);
        }

        private void UpdateGameState()
        {
            for (int i = 0; i < 9; i++)
            {
                foreach (PictureBox pb in boardDisplay.Controls.OfType<PictureBox>())
                {
                    if (pb.Name.Equals("board" + i.ToString()))
                    {
                        if (gamestate[i/3,i%3] == 1)
                        {
                            pb.Image = Image.FromFile("..\\..\\images\\sq.png");
                        }

                        else if (gamestate[i / 3, i % 3] == -1)
                        {
                            pb.Image = Image.FromFile("..\\..\\images\\o.png");
                        }

                        else
                        {
                            pb.Image = Image.FromFile("..\\..\\images\\empty.png");
                        }
                    }
                }
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Mat img = Emgu.CV.CvInvoke.Imread("..\\..\\images\\board-m01.png");

            //currentImageBox.Image = img.ToBitmap();

            ParseImage(img);
        }

        void ParseImage(Mat img)
        {

            Mat gray = new Mat();
            Mat filtered = new Mat();
            Mat edged = new Mat();

            VectorOfPoint approx = new VectorOfPoint();

            MCvScalar color = new MCvScalar(0, 255, 255);
            

            CvInvoke.CvtColor(img, gray, Emgu.CV.CvEnum.ColorConversion.Rgb2Gray);
            
            CvInvoke.BilateralFilter(gray, filtered, 25, 20, 20);
            
            CvInvoke.Canny(filtered, edged, 30, 200);
            

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat m = new Mat();

            CvInvoke.FindContours(edged, contours, m, Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            textBox5.Text = contours.Size.ToString();
            
            // Extracting board from image
            for (int i = 0; i < contours.Size; i++)
            {
                VectorOfPoint c = contours[i];
               

                double peri = CvInvoke.ArcLength(c, true);
                CvInvoke.ApproxPolyDP(c, approx,  peri * 0.1, true);

                if(CvInvoke.ContourArea(approx, false) > 1)
                {
                    if(approx.Size == 4)
                    {
                        textBox6.Text = "REACHED!";
                        Point[] pts = approx.ToArray();

                        CvInvoke.DrawContours(img, contours, i, new MCvScalar(0, 0, 255), 2);
                        currentImageBox.Image = img.ToBitmap();
                        
                        break;                    
                       
                        
                    }
                }

                
            }


            // Separating board into 9 sections

            // Displaying coordinates of board in textbox
            debuggingTextBox.Clear();

            debuggingTextBox.AppendText("Board Coordinates \r\n");
            
            for (int i = 0; i < approx.Size; i++)
            {
                debuggingTextBox.AppendText(approx[i].ToString() + "\r\n");
            }

            int boardWidth = approx[0].X - approx[1].X;
            int boardHeight = approx[2].Y - approx[0].Y;

            Mat board = new Mat(img,new Rectangle(approx[1].X,approx[0].Y,boardWidth,boardHeight));

            // Display board image
            currentImageBox.Image = board.ToBitmap();


            int segWidth = boardWidth / 3;
            int segHeight = boardHeight / 3;

            int padding = 10;

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Mat segment = new Mat(board, new Rectangle((j * segWidth + padding), (i * segHeight + padding), segWidth - 2 * padding, segHeight - 2 * padding));

                    // Look for square within segment

                    Mat segGray = new Mat();
                    Mat segFiltered = new Mat();
                    Mat segEdged = new Mat();

                    VectorOfPoint segApprox = new VectorOfPoint();


                    CvInvoke.CvtColor(segment, segGray, Emgu.CV.CvEnum.ColorConversion.Rgb2Gray);

                    CvInvoke.BilateralFilter(segGray, segFiltered, 25, 20, 20);

                    CvInvoke.Canny(segFiltered, segEdged, 30, 200);


                    VectorOfVectorOfPoint segContours = new VectorOfVectorOfPoint();

                    CvInvoke.FindContours(segEdged, segContours, m, Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                    for (int k = 0; k < segContours.Size; k++)
                    {
                        VectorOfPoint c = contours[k];


                        double peri = CvInvoke.ArcLength(c, true);
                        CvInvoke.ApproxPolyDP(c, segApprox, peri * 0.1, true);

                        if (CvInvoke.ContourArea(segApprox, false) > 1)
                        {
                            if (approx.Size == 4)
                            {
                                textBox6.Text = "REACHED!";
                                Point[] pts = approx.ToArray();

                                CvInvoke.DrawContours(img, contours, i, new MCvScalar(0, 0, 255), 2);

                                gamestate[i,j] = 1;

                            }
                        }


                    }

                }
            }


            UpdateGameState();
        }

        
    }
}
