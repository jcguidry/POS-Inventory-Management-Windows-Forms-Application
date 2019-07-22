using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; // at the top
using System.Data.OleDb;
/*
namespace POS_System
{
    public partial class Checkout : Form
    {
        public Checkout()
        {
            InitializeComponent();
        }

        private void Checkout_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
namespace POS_System

{
    public partial class Form3 : Form
    {
        /*

        OleDbConnection connection = new OleDbConnection();
        connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\collinguidry\Source\Repos\termproject2060\POS System\POS System\2060 Term Project.mdb";
            connection.Open();
            /////////////////////////

            /////////////////////////
            connection.Close();

       */

    /*
        public string receipt;


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\collinguidry\source\repos\Lab 10 guidry\Example 1\Lab10 Example.mdb";
            connection.Open();

            /////////////////////////

            // 3 lines of DB connection code
            //getting parameters from Form3
            string tr_id = textBox1.Text;
            double no_a = Convert.ToInt16(textBox2.Text);
            double no_b = Convert.ToInt16(textBox3.Text);
            double no_c = Convert.ToInt16(textBox4.Text);
            string today = DateTime.Now.ToString();
            //writing a row for item A to tbl_tr
            if (no_a > 0)
            {
                OleDbCommand cmd1 = new OleDbCommand("insert into tbl_tr (Tr_id, Cashier_id, item_id, units, tr_date) values (@a, @b, @c, @d, @e)", connection);
                cmd1.Parameters.AddWithValue("@a", textBox1.Text);
                cmd1.Parameters.AddWithValue("@b", Form1.emp_id);
                cmd1.Parameters.AddWithValue("@c", 1);
                cmd1.Parameters.AddWithValue("@d", no_a);
                cmd1.Parameters.AddWithValue("@e", today);
                cmd1.ExecuteNonQuery();
            }
            //writing a row for item B to tbl_tr
            if (no_b > 0)
            {
                OleDbCommand cmd2 = new OleDbCommand("insert into tbl_tr (Tr_id, Cashier_id, item_id, units, tr_date) values (@a, @b, @c, @d, @e)", connection);
                cmd2.Parameters.AddWithValue("@a", textBox1.Text);
                cmd2.Parameters.AddWithValue("@b", Form1.emp_id);
                cmd2.Parameters.AddWithValue("@c", 2);
                cmd2.Parameters.AddWithValue("@d", no_b);
                cmd2.Parameters.AddWithValue("@e", today);
                cmd2.ExecuteNonQuery();
            }
            //writing a row for item C to tbl_tr
            if (no_c > 0)
            {
                OleDbCommand cmd3 = new OleDbCommand("insert into tbl_tr (Tr_id, Cashier_id, item_id, units, tr_date) values (@a, @b, @c, @d, @e)", connection);
                cmd3.Parameters.AddWithValue("@a", textBox1.Text);
                cmd3.Parameters.AddWithValue("@b", Form1.emp_id);
                cmd3.Parameters.AddWithValue("@c", 3);
                cmd3.Parameters.AddWithValue("@d", no_c);
                cmd3.Parameters.AddWithValue("@e", today);
                cmd3.ExecuteNonQuery();
            }


            //getting price of all items from tbl_item
            double price_a = 0;
            double price_b = 0;
            double price_c = 0;
            string name_a = "";
            string name_b = "";
            string name_c = "";
            OleDbCommand cmd4 = new OleDbCommand("select * from tbl_item", connection);
            OleDbDataReader DR = cmd4.ExecuteReader();
            while (DR.Read()) // similar to foreach row
            {
                if ((int)(DR["item_id"]) == 1)
                {
                    price_a = Convert.ToDouble(DR["price"]);
                    name_a = DR["item_name"].ToString();
                }
                else if ((int)(DR["item_id"]) == 2)
                {
                    price_b = Convert.ToDouble(DR["price"]);
                    name_b = DR["item_name"].ToString();
                }
                else if ((int)(DR["item_id"]) == 3)
                {
                    price_c = Convert.ToDouble(DR["price"]);
                    name_c = DR["item_name"].ToString();
                }
            }
            DR.Close();
            //populating labels
            label5.Text = (no_a + no_b + no_c).ToString();
            label7.Text = string.Format("{0:c}", (no_a * price_a + no_b * price_b + no_c * price_c));
            label9.Text = string.Format("{0:c}", ((no_a * price_a + no_b * price_b + no_c * price_c) * 0.06));
            label11.Text = string.Format("{0:c}", ((no_a * price_a + no_b * price_b + no_c * price_c) * 1.06));
            //creating receits
            receipt = "Receipt\n\n";
            receipt += string.Format("Transaction ID: {0}\n", textBox1.Text);
            receipt += string.Format("Cashier ID: {0}\n", Form1.emp_id);
            receipt += string.Format("Date: {0:d} & Time: {0:t}\n", DateTime.Now);
            receipt += new String('-', 49) + "\n";
            receipt += string.Format("{0,-12}{1,5} x {2,13}{3,15}\n", "Item Name", "Quantity", "Unit Price", "Price");
            receipt += new String('-', 49) + "\n";
            receipt += string.Format("{0,-12}{1,22:g} x{2,18:C}{3,13:C}\n", name_a.Trim(), no_a, price_a, price_a * no_a);
            receipt += string.Format("{0,-12}{1,22:g} x{2,18:C}{3,13:C}\n", name_b.Trim(), no_b, price_b, price_b * no_b);
            receipt += string.Format("{0,-12}{1,22:g} x{2,18:C}{3,13:C}\n", name_c.Trim(), no_c, price_c, price_c * no_c);
            receipt += new String('-', 49) + "\n";
            receipt += string.Format("{0,-39}{1,31:c}\n", "Subtotal", price_a * no_a + price_b * no_b + price_c * no_c);
            receipt += string.Format("{0,-44}{1,31:c}\n", "Tax", 0.06 * (price_a * no_a + price_b * no_b + price_c * no_c));
            receipt += new String('-', 49) + "\n";
            receipt += string.Format("{0,-42}{1,31:c}\n", "Total", 1.06 * (price_a * no_a + price_b * no_b + price_c * no_c));
            receipt += new String('-', 49) + "\n\n";
            receipt += "Thank you!!\n\n";
            MessageBox.Show("Checked out!!");
            */
            // DB connection close.

            /////////////////////////

            //connection.Close();
            

    
//        }
 //   }
//}
