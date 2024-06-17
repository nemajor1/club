using System;
using System.Windows.Forms;

namespace pc_club.ModuleForms
{
    public partial class ModuleRegFormTest : Form
    {
        DBControllerTests dbControllerTest = new DBControllerTests();
        public ModuleRegFormTest()
        {
            InitializeComponent();
        }
        private void CallTest()
        {
            string[] names = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text };
            dbControllerTest.UserRegistration_ValidInput_ReturnsTrue(names);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CallTest();
        }
    }
}
