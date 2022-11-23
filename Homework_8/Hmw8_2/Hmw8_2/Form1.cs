using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hmw8_2
{
    public partial class Form1 : Form
    {

        Graphics g, g2, g3, g4, g5;
        Rectangle rect1, rect2, rect3, rect4, rect5;

        Random r = new Random();

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numberOfSamples = trackBar1.Value;
            label1.Text = "Number of samples : " + numberOfSamples.ToString();
        }

        Pen PenTrajectory;
        int numberOfSamples = 1000;
        Bitmap b, b2, b3, b4, b5;

        public Form1()
        {
            InitializeComponent();

            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            b2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g2 = Graphics.FromImage(b2);

            b3 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            g3 = Graphics.FromImage(b3);

            b4 = new Bitmap(pictureBox4.Width, pictureBox4.Height);
            g4 = Graphics.FromImage(b4);

            b5 = new Bitmap(pictureBox5.Width, pictureBox5.Height);
            g5 = Graphics.FromImage(b5);
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            this.g = Graphics.FromImage(this.b);
            this.g2 = Graphics.FromImage(this.b2);
            this.g3 = Graphics.FromImage(this.b3);
            this.g4 = Graphics.FromImage(this.b4);
            this.g5 = Graphics.FromImage(this.b5);

            this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g.Clear(Color.White);

            this.g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g2.Clear(Color.White);

            this.g3.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g3.Clear(Color.White);

            this.g4.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g4.Clear(Color.White);

            this.g5.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g5.Clear(Color.White);

            rect1 = new Rectangle(0, 0, this.b.Width - 1, this.b.Height - 1);
            g.DrawRectangle(Pens.Black, rect1);
            rect2 = new Rectangle(0, 0, this.b2.Width - 1, this.b2.Height - 1);
            g2.DrawRectangle(Pens.Black, rect2);
            rect3 = new Rectangle(0, 0, this.b3.Width - 1, this.b3.Height - 1);
            g3.DrawRectangle(Pens.Black, rect3);
            rect4 = new Rectangle(0, 0, this.b4.Width - 1, this.b5.Height - 1);
            g4.DrawRectangle(Pens.Black, rect4);
            rect5 = new Rectangle(0, 0, this.b5.Width - 1, this.b5.Height - 1);
            g5.DrawRectangle(Pens.Black, rect5);

            double minValue = -3;
            double maxValue = 3;

            double delta = maxValue - minValue;
            double nintervals = 150;
            double intervalsSize = delta / nintervals;

            int nTrials = (int)trackBar1.Value;

            Dictionary<double, int> istogramDict = new Dictionary<double, int>();

            double tempValue = minValue;

            for (int i = 0; i <= nintervals; i++)
            {
                tempValue = minValue + (intervalsSize * i);
                tempValue = Math.Round(tempValue, 2);
                istogramDict[tempValue] = 0;
            }

            int total = 0;

            for (int x = 0; x < nTrials; x++)
            {
                double xRnd = (r.NextDouble() * 2) - 1;
                double value1 = 0;


                double yRnd = (r.NextDouble() * 2) - 1;

                double s = (xRnd * xRnd) + (yRnd * yRnd);

                while (s < 0 || s > 1)
                {
                    xRnd = (r.NextDouble() * 2) - 1;
                    yRnd = (r.NextDouble() * 2) - 1;
                    s = (xRnd * xRnd) + (yRnd * yRnd);
                }

                xRnd = xRnd * Math.Sqrt(-2 * Math.Log(s) / s);
                yRnd = yRnd * Math.Sqrt(-2 * Math.Log(s) / s);

                value1 = xRnd;


                foreach (double key in istogramDict.Keys)
                {
                    double range = key + intervalsSize;
                    if (range > maxValue) range = maxValue;
                    if (value1 < range && value1 > key)
                    {
                        istogramDict[key] += 1;
                        if (total < istogramDict[key])
                        {
                            total = istogramDict[key];
                        }
                        break;
                    }
                }
            }

            g.TranslateTransform(0, this.b.Height);
            g.ScaleTransform(1, -1);

            int idIstogram = 0;
            int widthIstogram = (int)(this.b.Width / nintervals);
            double lastKeyY = 0;

            foreach (double key in istogramDict.Keys)
            {
                lastKeyY = key;
                int newHeight = istogramDict[key] * this.b.Height / total;
                int newX = (widthIstogram * idIstogram) + 10;
                Rectangle isto = new Rectangle(newX, 0, widthIstogram, newHeight);
                idIstogram++;

                int nextWidthIstogram = (int)(widthIstogram * idIstogram * 1);

                g.DrawRectangle(Pens.Black, isto);
                g.FillRectangle(Brushes.LightGreen, isto);

            }

            this.pictureBox1.Image = b;

            double minVal2 = 0;
            double maxVal2 = 4;

            double delta2 = maxVal2 - minVal2;
            double intervals2 = 150;
            double intervals_Size2 = delta2 / intervals2;

            Dictionary<double, int> istogramDict2 = new Dictionary<double, int>();
            double tempValue2 = minVal2;
            for (int i = 0; i <= intervals2; i++)
            {
                tempValue2 = minVal2 + (intervals_Size2 * i);
                tempValue2 = Math.Round(tempValue2, 2);
                istogramDict2[tempValue2] = 0;
            }

            int total2 = 0;

            for (int x = 0; x < nTrials; x++)
            {
                double xRnd = (r.NextDouble() * 2) - 1;

                double value2 = 0;

                double yRnd = (r.NextDouble() * 2) - 1;

                double s = (xRnd * xRnd) + (yRnd * yRnd);

                while (s < 0 || s > 1)
                {
                    xRnd = (r.NextDouble() * 2) - 1;
                    yRnd = (r.NextDouble() * 2) - 1;
                    s = (xRnd * xRnd) + (yRnd * yRnd);
                }

                xRnd = xRnd * Math.Sqrt(-2 * Math.Log(s) / s);
                yRnd = yRnd * Math.Sqrt(-2 * Math.Log(s) / s);


                value2 = xRnd * xRnd;


                foreach (double key in istogramDict2.Keys)
                {
                    double range = key + intervals_Size2;
                    if (range > maxVal2) range = maxVal2;
                    if (value2 < range && value2 > key)
                    {
                        istogramDict2[key] += 1;
                        if (total2 < istogramDict2[key])
                        {
                            total2 = istogramDict2[key];
                        }
                        break;
                    }
                }
            }



            g2.TranslateTransform(0, this.b2.Height);
            g2.ScaleTransform(1, -1);

            int idIstogram2 = 0;
            int widthIstogram2 = (int)(this.b2.Width / intervals2);
            double lastKeyY2 = 0;

            foreach (double key in istogramDict2.Keys)
            {
                lastKeyY2 = key;
                int newHeight = istogramDict2[key] * this.b2.Height / total2;
                int newX = (widthIstogram2 * idIstogram2) + 10;
                Rectangle isto = new Rectangle(newX, 0, widthIstogram2, newHeight);
                idIstogram2++;

                int nextWidthIstogram = (int)(widthIstogram2 * idIstogram2 * 1);

                g2.DrawRectangle(Pens.Black, isto);
                g2.FillRectangle(Brushes.LightGreen, isto);

            }

            this.pictureBox2.Image = b2;

            double minValue3 = -8;
            double maxValue3 = 8;

            double delta3 = maxValue3 - minValue3;
            double nintervals3 = 150;
            double intervalsSize3 = delta3 / nintervals3;

            Dictionary<double, int> istogramDict3 = new Dictionary<double, int>();
            double tempValue3 = minValue3;
            for (int i = 0; i <= nintervals3; i++)
            {
                tempValue3 = minValue3 + (intervalsSize3 * i);
                tempValue3 = Math.Round(tempValue3, 2);
                istogramDict3[tempValue3] = 0;
            }

            int total3 = 0;

            for (int x = 0; x < nTrials; x++)
            {
                double xRnd = (r.NextDouble() * 2) - 1;
                double value3 = 0;

                double yRnd = (r.NextDouble() * 2) - 1;

                double s = (xRnd * xRnd) + (yRnd * yRnd);

                while (s < 0 || s > 1)
                {
                    xRnd = (r.NextDouble() * 2) - 1;
                    yRnd = (r.NextDouble() * 2) - 1;
                    s = (xRnd * xRnd) + (yRnd * yRnd);
                }

                xRnd = xRnd * Math.Sqrt(-2 * Math.Log(s) / s);
                yRnd = yRnd * Math.Sqrt(-2 * Math.Log(s) / s);


                value3 = xRnd / (yRnd * yRnd);


                foreach (double key in istogramDict3.Keys)
                {
                    double range = key + intervalsSize3;
                    if (range > maxValue3) range = maxValue3;
                    if (value3 < range && value3 > key)
                    {
                        istogramDict3[key] += 1;
                        if (total3 < istogramDict3[key])
                        {
                            total3 = istogramDict3[key];
                        }
                        break;
                    }
                }
            }



            g3.TranslateTransform(0, this.b3.Height);
            g3.ScaleTransform(1, -1);

            int idIstogram3 = 0;
            int widthIstogram3 = (int)(this.b3.Width / nintervals3);
            double lastKeyY3 = 0;

            foreach (double key in istogramDict3.Keys)
            {
                lastKeyY3 = key;
                int newHeight = istogramDict3[key] * this.b3.Height / total3;
                int newX = (widthIstogram3 * idIstogram3) + 10;
                Rectangle isto = new Rectangle(newX, 0, widthIstogram3, newHeight);
                idIstogram3++;

                int nextWidthIstogram = (int)(widthIstogram3 * idIstogram3 * 1);

                g3.DrawRectangle(Pens.Black, isto);
                g3.FillRectangle(Brushes.LightGreen, isto);

            }

            this.pictureBox3.Image = b3;

            double minValue4 = 0;
            double maxValue4 = 4;


            double delta4 = maxValue4 - minValue4;
            double nintervals4 = 150;
            double intervalsSize4 = delta4 / nintervals4;

            Dictionary<double, int> istogramDict4 = new Dictionary<double, int>();
            double tempValue4 = minValue4;
            for (int i = 0; i <= nintervals4; i++)
            {
                tempValue4 = minValue4 + (intervalsSize4 * i);
                tempValue4 = Math.Round(tempValue4, 2);
                istogramDict4[tempValue4] = 0;
            }

            int total4 = 0;

            for (int x = 0; x < nTrials; x++)
            {
                double xRnd = (r.NextDouble() * 2) - 1;

                double value4 = 0;


                double yRnd = (r.NextDouble() * 2) - 1;

                double s = (xRnd * xRnd) + (yRnd * yRnd);

                while (s < 0 || s > 1)
                {
                    xRnd = (r.NextDouble() * 2) - 1;
                    yRnd = (r.NextDouble() * 2) - 1;
                    s = (xRnd * xRnd) + (yRnd * yRnd);
                }

                xRnd = xRnd * Math.Sqrt(-2 * Math.Log(s) / s);
                yRnd = yRnd * Math.Sqrt(-2 * Math.Log(s) / s);


                value4 = (xRnd * xRnd) / (yRnd * yRnd);

                foreach (double key in istogramDict4.Keys)
                {
                    double range = key + intervalsSize4;
                    if (range > maxValue4) range = maxValue4;
                    if (value4 < range && value4 > key)
                    {
                        istogramDict4[key] += 1;
                        if (total4 < istogramDict4[key])
                        {
                            total4 = istogramDict4[key];
                        }
                        break;
                    }
                }
            }



            g4.TranslateTransform(0, this.b4.Height);
            g4.ScaleTransform(1, -1);

            int idIstogram4 = 0;
            int widthIstogram4 = (int)(this.b4.Width / nintervals4);
            double lastKeyY4 = 0;

            foreach (double key in istogramDict4.Keys)
            {
                lastKeyY4 = key;
                int newHeight = istogramDict4[key] * this.b4.Height / total4;
                int newX = (widthIstogram4 * idIstogram4) + 10;
                Rectangle isto = new Rectangle(newX, 0, widthIstogram4, newHeight);
                idIstogram4++;

                int nextWidthIstogram = (int)(widthIstogram4 * idIstogram4 * 1);

                g4.DrawRectangle(Pens.Black, isto);
                g4.FillRectangle(Brushes.LightGreen, isto);

            }

            this.pictureBox4.Image = b4;

            double minValue5 = -10;
            double maxValue5 = 10;


            double delta5 = maxValue5 - minValue5;
            double nintervals5 = 150;
            double intervalsSize5 = delta5 / nintervals5;

            Dictionary<double, int> istogramDict5 = new Dictionary<double, int>();
            double tempValue5 = minValue5;
            for (int i = 0; i <= nintervals5; i++)
            {
                tempValue5 = minValue5 + (intervalsSize5 * i);
                tempValue5 = Math.Round(tempValue5, 2);
                istogramDict5[tempValue5] = 0;
            }

            int total5 = 0;

            for (int x = 0; x < nTrials; x++)
            {
                double xRnd = (r.NextDouble() * 2) - 1;
                double value5 = 0;

                double yRnd = (r.NextDouble() * 2) - 1;

                double s = (xRnd * xRnd) + (yRnd * yRnd);

                while (s < 0 || s > 1)
                {
                    xRnd = (r.NextDouble() * 2) - 1;
                    yRnd = (r.NextDouble() * 2) - 1;
                    s = (xRnd * xRnd) + (yRnd * yRnd);
                }

                xRnd = xRnd * Math.Sqrt(-2 * Math.Log(s) / s);
                yRnd = yRnd * Math.Sqrt(-2 * Math.Log(s) / s);


                value5 = xRnd / yRnd;


                foreach (double key in istogramDict5.Keys)
                {
                    double range = key + intervalsSize5;
                    if (range > maxValue5) range = maxValue5;
                    if (value5 < range && value5 > key)
                    {
                        istogramDict5[key] += 1;
                        if (total5 < istogramDict5[key])
                        {
                            total5 = istogramDict5[key];
                        }
                        break;
                    }
                }
            }



            g5.TranslateTransform(0, this.b5.Height);
            g5.ScaleTransform(1, -1);

            int idIstogram5 = 0;
            int widthIstogram5 = (int)(this.b5.Width / nintervals5);
            double lastKeyY5 = 0;

            foreach (double key in istogramDict5.Keys)
            {
                lastKeyY5 = key;
                int newHeight = istogramDict5[key] * this.b5.Height / total5;
                int newX = (widthIstogram5 * idIstogram5) + 1;
                Rectangle isto = new Rectangle(newX, 0, widthIstogram5, newHeight);
                idIstogram5++;

                int nextWidthIstogram = (int)(widthIstogram5 * idIstogram5 * 1);

                g5.DrawRectangle(Pens.Black, isto);
                g5.FillRectangle(Brushes.LightGreen, isto);

            }

            this.pictureBox5.Image = b5;
        }
    }
}