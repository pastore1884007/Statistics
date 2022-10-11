using Microsoft.VisualBasic.FileIO;

namespace Ex_3
{
    public partial class Form1 : Form
    {
        string[] array1 = { "brown", "blonde", "black", "red"};
        int[] array2 = { 0, 0, 0, 0 };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.AppendText("Univariate Distribution students' Hair color: \n");
            this.richTextBox1.AppendText("\n");
            this.richTextBox1.ScrollToCaret();
            using (TextFieldParser parser = new TextFieldParser("C:\\Users\\Utente\\Desktop\\Statistics_students_dataset.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                string[] header = parser.ReadFields();
                int index = 0;
                for (int i = 0; i < header.Length; i++)
                {
                    if (header[i] == "Hair_color")
                    {
                        index = i;
                    }
                }
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    for (int i = 0; i < array1.Length; i++)
                    {
                        if (array1[i] == fields[index].ToLower())
                        {
                            array2[i]++;
                        }
                    }
                }
            }
            for (int i = 0; i < array1.Length; i++)
            {
                string hair_color = array1[i];
                int numero = array2[i];
                this.richTextBox1.AppendText(hair_color + ": " + numero.ToString() + " on 36" +"\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
        }
    }
}