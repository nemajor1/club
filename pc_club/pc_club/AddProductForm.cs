using System;
using System.Windows.Forms;

namespace pc_club
{
    public partial class AddProductForm : Form
    {
        DBController dbController = new DBController();
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(textBox2.Text);
            dbController.AddProduct(textBox1.Text, price);
            Close();
        }
    }
}
