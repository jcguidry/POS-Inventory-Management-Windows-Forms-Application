using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class CustomerView : Form
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cart_and_Checkout checkoutform = new Cart_and_Checkout();
            checkoutform.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button56_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            LoginForm form = new LoginForm();
            form.Show();
        }
    }
}
