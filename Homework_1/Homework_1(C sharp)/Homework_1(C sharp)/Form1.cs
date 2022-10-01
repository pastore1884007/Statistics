namespace Homework_1_C_sharp_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnGetItem.MouseEnter += OnMouseEnterBtn1;
            btnGetItem.MouseLeave += OnMouseLeaveBtn1;
            btnGetIndex.MouseEnter += OnMouseEnterBtn2;
            btnGetIndex.MouseLeave += OnMouseLeaveBtn2;
        }

        private void btnGetItem_Click(object sender, EventArgs e)
        {
            listBoxItem.Items.Clear();
            foreach(string s in checkedListBox.CheckedItems)
                listBoxItem.Items.Add(s);
        }

        private void btnGetIndex_Click(object sender, EventArgs e)
        {
            listBoxIndex.Items.Clear();
            for(int i=0;i<checkedListBox.CheckedIndices.Count;i++)
                listBoxIndex.Items.Add(checkedListBox.CheckedIndices[i]);
        }

        private void OnMouseEnterBtn1(object sender, EventArgs e)
        {
            btnGetItem.BackColor = Color.Green;
        }
        private void OnMouseEnterBtn2(object sender, EventArgs e)
        {
            btnGetIndex.BackColor = Color.Green;
        }
        private void OnMouseLeaveBtn1(object sender, EventArgs e)
        {
            btnGetItem.BackColor = Color.Yellow;
        }
        private void OnMouseLeaveBtn2(object sender, EventArgs e)
        {
            btnGetIndex.BackColor = Color.Yellow;
        }
    }
}