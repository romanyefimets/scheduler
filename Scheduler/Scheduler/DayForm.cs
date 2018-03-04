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
    public partial class DayForm : Form 
    {
        //Calander scheduler;
        User me = new User();
       static  Form1 roman;
        
        public DayForm(Form1 form)
        {
            roman = form;
            InitializeComponent();
        }

        private void DayForm_Load(object sender, EventArgs e)
        {
            //label51.Text = roman.getCalender().getDay(roman.getCalender().selected);
            int temp = roman.getCalender().selected;
            label51.Text = roman.getCalender().getDay(temp).getDay();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label52.Visible = true;
            label53.Visible = true;
            label54.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text=="" || textBox3.Text=="")
            { label55.Text = "Input Required"; return; }

            roman.getCalender().addEvent(roman.getCalender().getCurrentMonth(), roman.getCalender().selected, Double.Parse(textBox2.Text), Double.Parse(textBox3.Text), textBox1.Text, roman.getYear());
            //textBox1.Tex = //name
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button3.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;

            roman.getCalender().SaveCalendar(roman.getYear(), Program.user);

        }
    }
}
