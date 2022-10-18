using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homework_3
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> data = new Dictionary<string, int>();
        readonly int column = 2; // take the index of the column inside the CSV of our interest (protocol)
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextFieldParser parser = new TextFieldParser("C:\\Users\\Utente\\Desktop\\Wireshark_capture.csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                string[] dataCSV = parser.ReadFields();
                string key = dataCSV[column];

                if (data.ContainsKey(key)) data[key]++;
                else data.Add(key, 1);
            }
            this.richTextBox1.AppendText("TCP errors distrubution in the file obtained using Wireshark while I was connected to the sapienza network:  \n\n");
            foreach (KeyValuePair<string, int> pair in data)
            {
                int value = pair.Value;
                string key = pair.Key;
                if (pair.Key.Equals("TCP Errors")) continue;
                this.richTextBox1.AppendText(key + ": " + value.ToString() + "\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
        }
    }
}