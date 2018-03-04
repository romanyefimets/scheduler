using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class CreateAccount : Form
    {
        Login form;
       
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
     
        }

        // cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            form = new Login();
            form.Show();
            this.Hide();
        }

        // create account button
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")     
            { label9.Text = "Need input"; } else { label9.Text = ""; }
            if(textBox2.Text == "")
            { label10.Text = "Need input";} else { label10.Text = ""; }
            if(textBox3.Text == "" || !textBox3.Text.EndsWith(".com"))
            { label11.Text = "Invalid input";} else { label11.Text = ""; }
            if (textBox4.Text == "") { label7.Text = "Need input"; }
            else if (Program.help.UsernameExists(textBox4.Text))        // check if username exists
            {
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                label7.Text = "Username already exists";
                return;
            }
            else { label7.Text = ""; }
            if(textBox5.Text.Length < 6)
            {
                textBox5.Clear();
                textBox6.Clear();
                label8.Text = "Password too short";
                return;
            } else { label8.Text = ""; }
            if(textBox5.Text != textBox6.Text)
            {
                textBox5.Clear();
                textBox6.Clear();
                label8.Text = "Passwords don't match";
                return;
            }

            // create user go to login
            if (Program.help.CreateNewUser(textBox4.Text, textBox5.Text))
            {
                Program.help.SaveToFile();
                form = new Login();
                form.Show();
                this.Hide();
            }
            else
            {
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
        }
    }
}
