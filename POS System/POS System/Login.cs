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

namespace POS_System
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            /*
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:C:\Users\collinguidry\source\repos\2060 project v2\POS System\POS System\2060 Term Project items.mdb";
            connection.Open();
            /////////////////////////

            /////////////////////////
            connection.Close();

            */
        }
        private void DBConnect (object sender, EventArgs e)
        {

            
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Email = textBox1.Text;
            string Password = textBox2.Text;

            int EmailLength = Email.Length;
            int PasswordLength = Password.Length;
            if (!(EmailLength > 0) | !(PasswordLength > 0))
                MessageBox.Show("Please enter an email and/or password.");
            else
            {

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\collinguidry\source\repos\2060 project v2\POS System\POS System\2060 Term Project items.mdb";
                connection.Open();
                /////////////////////////

                OleDbCommand cmd_employee = new OleDbCommand("select * from Employees where Email = @a", connection);
                cmd_employee.Parameters.AddWithValue("@a", Convert.ToString(textBox1.Text));
                OleDbDataReader DR_emp = cmd_employee.ExecuteReader();

                OleDbCommand cmd_user = new OleDbCommand("select * from Customers where Email = @b", connection);
                cmd_user.Parameters.AddWithValue("@b", Convert.ToString(textBox1.Text));
                OleDbDataReader DR_user = cmd_user.ExecuteReader();
               


                string Emp_Pass = "", User_Pass = "";
                while (DR_emp.Read())
                {
                    Emp_Pass = DR_emp["Password"].ToString(); //Read a value from query

                }

                while (DR_user.Read())
                {
                    User_Pass = DR_user["Password"].ToString(); //Read a value from query

                }

                DR_emp.Close();
                DR_user.Close();

                if (Emp_Pass == Convert.ToString(textBox2.Text)) //if password entered = password in database
                {
                    MessageBox.Show("Entering employee view.");
                    this.Hide();
                    EmployeeView form = new EmployeeView();
                    form.Show();
                }
                else
                 if (User_Pass == Convert.ToString(textBox2.Text))
                    {
                    MessageBox.Show("Entering customer view.");
                    this.Hide();
                        CustomerView f2 = new CustomerView();
                        f2.Show();
                    }
                else
                {
                    MessageBox.Show("Records did not match. please try again.");
                    this.Hide();
                    LoginForm f1 = new LoginForm();
                    f1.Show();
                }
                
                /////////////////////////
                connection.Close();
            }

        }



        private void EmployeeCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private class Form1
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome!" );
            this.Hide();
            NewCustomerForm form = new NewCustomerForm();
            form.Show();
        }
    }
}
