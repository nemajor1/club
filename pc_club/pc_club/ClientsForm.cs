﻿using System;
using System.Windows.Forms;

namespace pc_club
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            int balance = Convert.ToInt32(textBox2.Text);
            DBController.AddBalance(id, balance);
        }
    }
}
