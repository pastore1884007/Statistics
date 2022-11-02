using Microsoft.VisualBasic.FileIO;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace myColumnChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = -1;

            Dictionary<string,int> dic = new Dictionary<string, int>();

            using (TextFieldParser parser = new TextFieldParser("C:\\Users\\Utente\\Desktop\\Statistics_students_dataset.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    n = n + 1;
                    string[] fields = parser.ReadFields();
                    int i = 0;

                    foreach(string field in fields)
                    {
                        if (i == 7)
                        {
                            if (dic.ContainsKey(field))
                            {
                                dic[field] += 1;
                            }
                            else
                            {
                                dic.Add(field, 1);
                            }
                        }
                        i = i + 1;
                    }
                }
            }
            dic.Remove("Shoe_size");

            Bitmap b1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g1 = Graphics.FromImage(b1);

            Bitmap b2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g2 = Graphics.FromImage(b2);

            myVerticalChart(b1, g1, pictureBox1, dic, n);
            myHorizontalChart(b2, g2, pictureBox2, dic, n);
        }

        private double FromXRealToXVirtual(double X, double minX, double maxX, double W)
        {
            return (X - minX) / (maxX - minX)*W;
        }

        private double FromYRealToYVirtual(double Y, double minY, double maxY, double H)
        {
            return H - ((Y - minY) / (maxY - minY)) * H;
        }

        private void myVerticalChart(Bitmap b, Graphics g, PictureBox pB, Dictionary<string, int> d, int n)
        {
            int i = 0;
            int s = pB.Width / d.Count;

            g.DrawRectangle(new Pen(Color.Black), 0, 0, pB.Width - 1, pB.Height - 1);

            foreach (var o in d)
            {
                double vX = FromXRealToXVirtual(o.Value, 0, n, pB.Height);
                g.DrawRectangle(new Pen(Color.Red), i + 1, pB.Height - (int)vX - 1, s, (int)vX);
                g.DrawString(o.Key, new Font("Arial", 8), new SolidBrush(Color.Black), i, pB.Height - 14);
                i = i + s;
            }
            pB.Image = b;
        }

        private void myHorizontalChart(Bitmap b, Graphics g, PictureBox pB, Dictionary<string, int> d, int n)
        {
            int i = 0;
            int s = pB.Height / d.Count;

            g.DrawRectangle(new Pen(Color.Black), 0, 0, pB.Width - 1, pB.Height - 1);

            foreach (var o in d)
            {
                double vX = FromXRealToXVirtual(o.Value, 0, n, pB.Width);
                g.DrawRectangle(new Pen(Color.Red), 0, i, (int) vX, s);
                i = i + s;
            }
            pB.Image = b;
        }

    }
}