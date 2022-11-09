using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace homework6
{
    public partial class Form1 : Form
    {
        Bitmap b;
        Graphics g;
        Pen PenTrajectory = new Pen(Color.DarkGreen, 1);

        Bitmap bIsto;
        Graphics gIsto;
        Boolean boolWeight = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.g = Graphics.FromImage(b);
            this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g.Clear(Color.White);
            this.richTextBox1.Clear();

            Rectangle VirtualWindow = new Rectangle(0, 0, this.b.Width - 1, this.b.Height - 1);
            g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow);
            int index = 1;
            Random r = new Random();

            int trialsnumber = 200, samplesize = 10; 
            var valuestring = new List<double>();

            double minX = 0;
            double maxX = samplesize;
            double maxValue = 0;
            double minValue = 0;
            double minY = minValue;
            double maxY = maxValue;

            using (TextFieldParser parser = new TextFieldParser(@"./../../weight-height.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    double key = double.Parse(fields[index], CultureInfo.InvariantCulture);
                    valuestring.Add(key);
                }
            }

            int length = valuestring.Count;
            List<double> avglist = new List<double>();

            for (int i = 0; i < trialsnumber; i++)
            {
                List<Point> Punti = new List<Point>();
                List<int> selectorList = new List<int>();


                double tempmean = 0;
                double mean = 0;

                for (int j = 0; j <= samplesize; j++)
                {
                    int selector = r.Next(length);
                    selectorList.Add(selector);

                    double value = valuestring[selector];
                    
                    mean = (mean + value);
                    tempmean = mean / (j+1);


                    if (minValue == 0 || tempmean < minValue)
                    {
                        minValue = tempmean;
                    }

                    if (minValue == 0 || tempmean > maxValue)
                    {
                        maxValue = tempmean;
                    }

                    minY = minValue;
                    maxY = maxValue;

                }
                avglist.Add(tempmean);

                tempmean = 0;
                mean = 0;

                for (int j = 0; j < selectorList.Count; j++)
                {
                    int random = selectorList[j];
                    double value = valuestring[random];

                    mean = (mean + value);
                    tempmean = mean / (j + 1);

                    int xDevice = (int)(FromXRealToXVirtual(j, minX, maxX, VirtualWindow.Left, VirtualWindow.Width));
                    int YDevice = (int)(FromYRealToYVirtual(tempmean, minY, maxY, VirtualWindow.Top, VirtualWindow.Height));
                    Punti.Add(new Point(xDevice, YDevice));
                }

            }
            int n = 1;
                foreach (double j in avglist)
                {
                    this.richTextBox1.AppendText("Mean of sample" + n.ToString() + ": " + j.ToString() + "\n");
                    n++;
                }

            this.pictureBox1.Image = b;

            this.bIsto = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.gIsto = Graphics.FromImage(bIsto);

            this.gIsto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.gIsto.Clear(Color.White);

            Rectangle VirtualWindow2 = new Rectangle(0, 0, this.bIsto.Width - 1, this.bIsto.Height - 1);
            gIsto.DrawRectangle(Pens.Black, VirtualWindow2);

            double minAvg = avglist.Min();
            double maxAvg = avglist.Max();
            double delta = maxAvg - minAvg;
            double nintervals = 20;
            double intervalsSize = delta / nintervals;
            Dictionary<double, int> istoDict = new Dictionary<double, int>();

            double tempValue = minAvg;
            for (int i = 0; i < nintervals; i++)
            {
                istoDict[tempValue] = 0;
                tempValue = tempValue + intervalsSize;
            }

            int total = 0;

            foreach (double value in avglist)
            {
                foreach (double key in istoDict.Keys)
                {
                    if (value < key + intervalsSize)
                    {
                        total++;
                        istoDict[key] += 1;
                        break;
                    }
                }
            }

            gIsto.TranslateTransform(0, this.bIsto.Height);
            gIsto.ScaleTransform(1, -1);

            int idIsto = 0;
            int widthIsto = (int)(this.bIsto.Width / nintervals);
            foreach (double key in istoDict.Keys)
            {
                int newHeight = istoDict[key] * this.bIsto.Height / total;
                int newX = (widthIsto * idIsto) + 1;
                Rectangle isto = new Rectangle(newX, 0, widthIsto, newHeight);
                idIsto++;

                int nextWidthIstogram = (int)(widthIsto * idIsto * 1);
                
                SolidBrush the_brush = new SolidBrush(Color.Yellow);
                gIsto.DrawRectangle(Pens.Black, isto);
                gIsto.FillRectangle(the_brush, isto);
            }
            this.pictureBox1.Image = bIsto;

            double[] avg_list = avglist.ToArray();

            double population_expected_value = compute_mean(avg_list);

            richTextBox3.Clear();
            richTextBox3.AppendText("Mean of the entire population: " + population_expected_value.ToString().PadRight(50) + "\n");
            
        }

        public double compute_mean(double[] numbers)
        {
            int count = 1;
            double mean = 0;
            int size = numbers.Length;
            for (int i = 0; i < size; i++)
            {
                mean = mean + ((numbers[i] - mean) / (double)count);
                count++;
            }
            return mean;
        }

        public double FromXRealToXVirtual(double X, double minX, double maxX, int Left, int W)
            {
                if ((maxX - minX) == 0)
                    return 0;

                return Left + W * (X - minX) / (maxX - minX);
            }

            public double FromYRealToYVirtual(double Y, double minY, double maxY, int Top, int H)
            {
                if ((maxY - minY) == 0)
                    return 0;

                return Top + H - H * (Y - minY) / (maxY - minY);
            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.b = new Bitmap(this.pictureBox2.Width, this.pictureBox2.Height);
            this.g = Graphics.FromImage(b);
            this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g.Clear(Color.White);
            //this.richTextBox1.Clear();


            Rectangle VirtualWindow = new Rectangle(0, 0, this.b.Width - 1, this.b.Height - 1);
            g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow);

            Random r = new Random();
            int index=1;

            int trialsnumber = 200, samplesize = 10; 
            var valuestring = new List<double>();

            double minX = 0;
            double maxX = samplesize;
            double maxValue = 0;
            double minValue = 0;
            double minY = minValue;
            double maxY = maxValue;

            using (TextFieldParser parser = new TextFieldParser(@"./../../weight-height.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    double key = double.Parse(fields[index], CultureInfo.InvariantCulture);
                    valuestring.Add(key);
                }
            }

            int length = valuestring.Count;
            List<double> variancelist = new List<double>();

            for (int i = 0; i < trialsnumber; i++)
            {
                List<Point> Punti = new List<Point>();
                List<int> selectorList = new List<int>();


                double tempmean = 0;
                double mean = 0;
                double variance = 0.0;

                for (int j = 0; j <= samplesize; j++)
                {
                    int selector = r.Next(length);
                    selectorList.Add(selector);

                    double value = valuestring[selector];

                    mean = (mean + value);
                    tempmean = mean / (j + 1);

                    variance += Math.Pow(value - tempmean, 2.0);
                    variance= (variance/(j + 1))*3;

                    if (minValue == 0 || variance < minValue)
                    {
                        minValue = variance;
                    }

                    if (minValue == 0 || variance > maxValue)
                    {
                        maxValue = variance;
                    }

                    minY = minValue;
                    maxY = maxValue;

                }
                variancelist.Add(variance);


                tempmean = 0;
                mean = 0;
                double variance1 = 0.0;

                for (int j = 0; j < selectorList.Count; j++)
                {
                    int itm = selectorList[j];
                    double value = valuestring[itm];

                    mean = (mean + value);
                    tempmean = mean / (j + 1);

                    variance1 += Math.Pow(value - tempmean, 2.0);
                    variance1 = variance1 / (j + 1);

                    int xDevice = (int)(FromXRealToXVirtual(j, minX, maxX, VirtualWindow.Left, VirtualWindow.Width));
                    int YDevice = (int)(FromYRealToYVirtual(variance1, minY, maxY, VirtualWindow.Top, VirtualWindow.Height));
                    Punti.Add(new Point(xDevice, YDevice));
                }

            }
            int n = 1;
                foreach (double j in variancelist)
                {
                    this.richTextBox2.AppendText("Variance of sample" + n.ToString() + ": " + j.ToString() + "\n");
                    n++;
                }
            this.pictureBox2.Image = b;

            this.bIsto = new Bitmap(this.pictureBox2.Width, this.pictureBox2.Height);
            this.gIsto = Graphics.FromImage(bIsto);

            this.gIsto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.gIsto.Clear(Color.White);

            Rectangle VirtualWindow2 = new Rectangle(0, 0, this.bIsto.Width - 1, this.bIsto.Height - 1);
            gIsto.DrawRectangle(Pens.Black, VirtualWindow2);

            double minAvg = variancelist.Min();
            double maxAvg = variancelist.Max();
            double delta = maxAvg - minAvg;
            double nintervals = 20;
            double intervalsSize = delta / nintervals;

            Dictionary<double, int> istoDict = new Dictionary<double, int>();

            double tempValue = minAvg;
            for (int i = 0; i < nintervals; i++)
            {
                istoDict[tempValue] = 0;
                tempValue = tempValue + intervalsSize;
            }

            int total = 0;

            foreach (double value in variancelist)
            {
                foreach (double key in istoDict.Keys)
                {
                    if (value < key + intervalsSize)
                    {
                        total++;
                        istoDict[key] += 1;
                        break;
                    }
                }
            }

            gIsto.TranslateTransform(0, this.bIsto.Height);
            gIsto.ScaleTransform(1, -1);

            int idIsto = 0;
            int widthIsto = (int)(this.bIsto.Width / nintervals);
            foreach (double key in istoDict.Keys)
            {
                int newHeight = istoDict[key] * this.bIsto.Height / total;
                int newX = (widthIsto * idIsto) + 1;
                Rectangle isto = new Rectangle(newX, 0, widthIsto, newHeight);
                idIsto++;

                int nextWidthIstogram = (int)(widthIsto * idIsto * 1);

                SolidBrush the_brush = new SolidBrush(Color.Yellow);
                gIsto.DrawRectangle(Pens.Black, isto);
                gIsto.FillRectangle(the_brush, isto);
            }
            this.pictureBox2.Image = bIsto;

            double[] variance_list = variancelist.ToArray();

            double population_variance = compute_variance(variance_list);

            richTextBox3.AppendText("Variance of the entire population: " + population_variance.ToString().PadRight(50));

        }

        public double compute_variance(double[] numbers)
        {
            double mean = 0;
            double oldM;
            double variance = 0;
            int count = 1;
            int size = numbers.Length;

            for (int j = 0; j < size; j++)
            {
                double val = numbers[j];
                oldM = mean;
                mean = mean + (val - mean) / count;
                variance = variance + (val - mean) * (val - oldM);
                count++;
            }

            variance = variance / (numbers.Length);

            return (variance);
        }

    }
}

