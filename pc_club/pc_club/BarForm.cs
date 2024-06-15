using System;
using System.Windows.Forms;

namespace pc_club
{
    public partial class BarForm : Form
    {
        DBController dbController = new DBController();
        AddProductForm addProductForm = new AddProductForm();

        public BarForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addProductForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            int quantity = Convert.ToInt32(textBox2.Text);
            dbController.AddQuantityProduct(id, quantity);
        }
    }
}
