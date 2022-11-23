using System.Reflection;
using System;

namespace Hmw8_1
{
    public partial class Form1 : Form
    {

        Bitmap b, b2, b3;
        Graphics g, g2, g3;


        Rectangle rect1;
        Pen PenTrajectory;
        Random r;

        double minX;
        double maxX;
        double minY;
        double maxY;
        int numberOfPoints = 1000;


        List<Point> points;

        public Form1()
        {
            InitializeComponent();

            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            b2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g2 = Graphics.FromImage(b2);

            b3 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            g3 = Graphics.FromImage(b3);

            this.b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.b2 = new Bitmap(this.pictureBox2.Width, this.pictureBox2.Height);
            this.b3 = new Bitmap(this.pictureBox3.Width, this.pictureBox3.Height);
            this.r = new Random();
        }

        public int FromXRealToXVirtual(double X, double minX, double maxX, int L, int W)
        {
            return L + (int)(W * ((X - minX) / (maxX - minX)));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numberOfPoints = trackBar1.Value;
            label1.Text = "# points : " + numberOfPoints.ToString();
        }

        public int FromYRealToYVirtual(double Y, double minY, double maxY, int T, int H)
        {
            return T + (int)(H - H * ((Y - minY) / (maxY - minY)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.g = Graphics.FromImage(this.b);
            this.g2 = Graphics.FromImage(this.b2);
            this.g3 = Graphics.FromImage(this.b3);


            this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g.Clear(Color.White);

            this.g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g2.Clear(Color.White);

            this.g3.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g3.Clear(Color.White);

            points = new List<Point>();


            minX = -100d;
            maxX = 100d;
            minY = -100d;
            maxY = 100d;

            rect1 = new Rectangle(20, 20, this.b.Width - 40, this.b.Height - 40);
            g.DrawRectangle(Pens.Black, rect1);

            Random module = new Random();
            Random angle = new Random();
            Dictionary<int, int> xDistr = new Dictionary<int, int>();
            Dictionary<int, int> yDistr = new Dictionary<int, int>();

            int radius = 100;

            for (int i = 0; i < numberOfPoints; i++)
            {
                double p_rand = module.NextDouble() * radius;
                double p_angle = angle.NextDouble() * 2 * Math.PI;
                double x = p_rand * Math.Cos(p_angle);
                double y = p_rand * Math.Sin(p_angle);

                Point p = new Point(FromXRealToXVirtual(x, minX, maxX, rect1.Left, rect1.Width), FromYRealToYVirtual(y, minY, maxY, rect1.Top, rect1.Height));
                points.Add(p);

                if (xDistr.ContainsKey(p.X))
                    xDistr[p.X]++;
                else
                    xDistr.Add(p.X, 1);

                if (yDistr.ContainsKey(p.Y))
                    yDistr[p.Y]++;
                else
                    yDistr.Add(p.Y, 1);
            }

            foreach (Point p in points)
            {
                Rectangle rect = new Rectangle(p.X - 1, p.Y - 1, 2, 2);
                g.FillEllipse(Brushes.Black, rect);
            }

            Rectangle hor_Histo = new Rectangle(20, 20, this.b3.Width - 40, this.b3.Height - 40);
            g3.DrawRectangle(Pens.Black, hor_Histo);
            createIstogramHoriz(hor_Histo, g3, 20, this.b3.Width - 40, yDistr);


            Rectangle vert_Histo = new Rectangle(20, 20, this.b2.Width - 40, this.b2.Height - 40);
            g2.DrawRectangle(Pens.Black, vert_Histo);
            createIstogramVert(vert_Histo, g2, 20 + this.b2.Height - 40, this.b2.Height - 40, xDistr);

            pictureBox2.Image = b2;
            pictureBox3.Image = b3;
            pictureBox1.Image = b;
        }

        public void createIstogramHoriz(Rectangle istogramSpace, Graphics g, int x, int w, Dictionary<int, int> distances)
        {
            int max_value = 0;
            foreach (int key in distances.Keys)
            {
                if (distances[key] > max_value)
                    max_value = distances[key];
            }

            Pen istoPen = new Pen(Color.Orange, 2);

            foreach (int key in distances.Keys)
            {
                double currentInterValue = distances[key];
                double pct = (double)distances[key] / (double)max_value;
                g.DrawLine(istoPen,
                           new PointF(x, key),
                           new PointF(x + ((int)(pct * w)), key)
                );
            }

        }

        public void createIstogramVert(Rectangle istogramSpace, Graphics g, int y, int w, Dictionary<int, int> distances)
        {
            int max_value = 0;
            foreach (int key in distances.Keys)
            {
                if (distances[key] > max_value)
                    max_value = distances[key];
            }

            Pen istoPen = new Pen(Color.Orange, 2);

            foreach (int key in distances.Keys)
            {
                double currentInterValue = distances[key];
                double pct = (double)distances[key] / (double)max_value;
                g.DrawLine(istoPen,
                           new PointF(key, y - ((int)(pct * w))),
                           new PointF(key, y)
                );
            }

        }

    }
}