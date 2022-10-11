using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Formats.Asn1;

namespace Ex_2
{
    public partial class Form1 : Form
    {
        String csvPath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private class Foo
        {
            public string Name { get; set; }
            public string Sex { get; set; }
            public string Weight { get; set; }
            public string Height { get; set; }
            public string Hair_color { get; set; }
            public string Eye_color { get; set; }
            public string Age { get; set; }
            public string Shoe_size { get; set; }
            public string Siblings { get; set; }
            public string Cars { get; set; }
            public string Hobby { get; set; }
            public string Smoker { get; set; }
            public string Work { get; set; }
            public string Pets { get; set; }
            public string Favorite_number { get; set; }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open CSV File",
                Filter = "csv files (*.csv)|*.csv",
                CheckFileExists = true,
                CheckPathExists = true,
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog.FileName);
                csvPath = openFileDialog.FileName;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IEnumerable<Foo> records = null;
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<Foo>();
                //this.richTextBox1.AppendText("Total Recored : " + records.Count().ToString() + "\n");
                foreach (Foo record in records)
                {
                    this.richTextBox1.AppendText(record.Name + " " + record.Sex + " " + record.Weight + " " + record.Height + " " + record.Hair_color + " " + record.Eye_color + " " + record.Age + " " + record.Shoe_size + " " + record.Siblings + " " + record.Cars + " " + record.Hobby + " " + record.Smoker + " " + record.Pets + " " + record.Work + " " + record.Favorite_number + "\n");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();

        }
    }
}