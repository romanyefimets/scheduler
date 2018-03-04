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
    public partial class Login : Form
    {
        CreateAccount CreateForm;
        Form1 romanForm;
        //private AccountManagement help = new AccountManagement();

        //private static User user1;

        public Login()
        {
            InitializeComponent();
            //help = new AccountManagement();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (Program.help.TryLogin(textBox1.Text, textBox2.Text))
            {
                case 0:                         // successful login
                    // run romans code
                    Program.user.setUsername(textBox1.Text);

                    romanForm = new Form1(Program.user);
                    romanForm.Show();
                    this.Hide();
                   
                    //
                    break;
                case 1:                         // right username, wrong password
                    textBox2.Clear();
                    label2.Text = "Wront Password...";
                    //Form1_Load(sender, e);
                    break;
                case 2:                         // usename not found
                    textBox1.Clear();
                    textBox2.Clear();
                    label2.Text = "Unknown Username";
                    //Form1_Load(sender, e);
                    break;
            }
            //return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateForm = new CreateAccount();
            CreateForm.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar=('*');
        }
    }
}
