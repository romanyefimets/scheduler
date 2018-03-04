using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Scheduler
{


    public partial class Form1 : Form
    {
        public static Color HIGHLIGHT = Color.Yellow;
        public static Color NORMAL = Color.White;

        public static int NUM_DAYS = 31;
        public static int SUN = 1;
        public static int MON = 2;
        public static int TUE = 3;
        public static int WED = 4;
        public static int THU = 5;
        public static int FRI = 6;
        public static int SAT = 7;

        public static Calander scheduler;
        public static Dictionary<int, PictureBox> picMap;
        public static Dictionary<String,int> dayNameMap;

        public static Year year;



        public Form1(User user)
        {
            InitializeComponent();
            scheduler = new Calander(pictureBox1);
            dayNameMap = new Dictionary<String, int>();
            initDayNameMap();


            year = new Year(2018); // will need to change this later

            scheduler.loadCalender(year, user);

            picMap = new Dictionary<int, PictureBox>();
            createPicMap();
            populate(year.getMonth(scheduler.curMonth - 1)); // change this to current date

        }

        public void initDayNameMap()
        {
            dayNameMap.Add("Sunday", SUN);
            dayNameMap.Add("Monday",MON);
            dayNameMap.Add("Tuesday",TUE);
            dayNameMap.Add("Wednesday",WED);
            dayNameMap.Add("Thursday",THU);
            dayNameMap.Add("Friday", FRI);
            dayNameMap.Add("Saturday", SAT);
        }

        public void createPicMap()
        {

            picMap.Add(1, pictureBox2);
            picMap.Add(2, pictureBox3);
            picMap.Add(3, pictureBox4);
            picMap.Add(4, pictureBox5);
            picMap.Add(5, pictureBox6);
            picMap.Add(6, pictureBox7);
            picMap.Add(7, pictureBox8);
            picMap.Add(8, pictureBox9);
            picMap.Add(9, pictureBox10);
            picMap.Add(10, pictureBox11);

            picMap.Add(11, pictureBox12);
            picMap.Add(12, pictureBox13);
            picMap.Add(13, pictureBox14);
            picMap.Add(14, pictureBox15);
            picMap.Add(15, pictureBox16);
            picMap.Add(16, pictureBox17);
            picMap.Add(17, pictureBox18);
            picMap.Add(18, pictureBox19);
            picMap.Add(19, pictureBox20);
            picMap.Add(20, pictureBox21);

            picMap.Add(21, pictureBox22);
            picMap.Add(22, pictureBox23);
            picMap.Add(23, pictureBox24);
            picMap.Add(24, pictureBox25);
            picMap.Add(25, pictureBox26);
            picMap.Add(26, pictureBox27);
            picMap.Add(27, pictureBox28);
            picMap.Add(28, pictureBox29);
            picMap.Add(29, pictureBox30);
            picMap.Add(30, pictureBox31);

            picMap.Add(31, pictureBox32);
            picMap.Add(32, pictureBox33);
            picMap.Add(33, pictureBox34);
            picMap.Add(34, pictureBox35);
            picMap.Add(35, pictureBox36);
            picMap.Add(36, pictureBox45);

            picMap.Add(37, pictureBox46);



        }

        private void showNextMonth(int direction)
        {
            scheduler.curMonth += direction;
            if (scheduler.curMonth > 11) scheduler.curMonth = 0;
            if (scheduler.curMonth < 0) scheduler.curMonth = 11;

            clearCalander();
            scheduler.getDayMap().Clear();
            scheduler.selected = 10;
            scheduler.selected = 10;
            populate(year.getMonth(scheduler.curMonth));
            //scheduler.selected = 
        }

        public void clearCalander()
        {
            Dictionary<int, Day> dic = scheduler.getDayMap();
            foreach (KeyValuePair<int, Day> pair in dic)
            {
                int dayNum = pair.Key;
                Day day = pair.Value;
                writeDayName(day.getColorBox(), "");
                unHighLight(dayNum);
               
            }
        }
        public void populate(Month m)
        {
            writeTitle(pictureBox44, m.getName());

            string firstDay = m.getDay(0).getDay();
            int startDay = dayNameMap[firstDay];

            for (int i = 1; i <= m.getDayRange(); i++)
            {
                int startNum = startDay + i - 1;
                Day day = new Day(i);
                
                scheduler.addDayMap(startNum, day);
                scheduler.getDay(startNum).setColorBox(picMap[startNum]);
                writeDayNum(startNum);
                writeDayName();
            }

            int currentDay = scheduler.selected;
            Dictionary<int, Day> dic = scheduler.getDayMap();

            foreach (KeyValuePair<int, Day> pair in dic)
            {
                Day day = pair.Value;
                if (day.getNumber() == scheduler.selected)
                {
                    currentDay = pair.Key;
                }
            }
            scheduler.prevSelected = scheduler.selected;
            scheduler.selected = currentDay;

            //unHighLight(scheduler.prevSelected);
            highLight(currentDay);
        }

        private void singleClick(object sender, EventArgs e, int boxNumber)
        {
            if (scheduler.getDay(boxNumber) != null)
            {
                scheduler.prevSelected = scheduler.selected;
                scheduler.selected = boxNumber;

                highLight(scheduler.selected);
                unHighLight(scheduler.prevSelected);
            }

        }
        public void writeDayName()
        {


            writeDayName(pictureBox37, "Sunday");
            writeDayName(pictureBox38, "Monday");
            writeDayName(pictureBox39, "Tuesday");
            writeDayName(pictureBox40, "Wednesday");
            writeDayName(pictureBox41, "Thursday");
            writeDayName(pictureBox42, "Friday");
            writeDayName(pictureBox43, "Saturday");
        }

        public void writeDayName(PictureBox picBox, String name)
        {
            Font font = new Font("TimesNewRoman", 18, FontStyle.Regular, GraphicsUnit.Pixel);
            Point p = new Point(0, 0);
            drawText(picBox, name, font, p);
        }


        public void writeTitle(PictureBox picBox, String name)
        {
            Font font = new Font("TimesNewRoman", 30, FontStyle.Regular, GraphicsUnit.Pixel);
            int halfX = picBox.Location.X / 2 - name.Count();

            Point p = new Point(halfX, 0);
            drawText(picBox, name, font, p);
        }

        public void drawText(PictureBox picBox, String name, Font f, Point p)
        {
            Image image = new Bitmap(picBox.Width, picBox.Height);
            Graphics g = Graphics.FromImage(image);
            g.DrawString(name, f, Brushes.Black, p);
            picBox.Image = image;
        }


        public void writeDayNum(int boxNumber)
        {

            Day day = scheduler.getDay(boxNumber);
            if (day != null)
            {
                PictureBox picBox = day.getColorBox();



                Image image = new Bitmap(picBox.Width, picBox.Height);
                Graphics g = Graphics.FromImage(image);
                Font font = new Font("TimesNewRoman", 20, FontStyle.Bold, GraphicsUnit.Pixel);
                g.DrawString(day.getNumber().ToString(), font, Brushes.Black, new Point(0, 0));
                picBox.Image = image;
            }
        
        }

        public void highLight(int boxNumber)
        {
            scheduler.getDay(boxNumber).setBoxColor(HIGHLIGHT);
        }

        public void unHighLight(int boxNumber)
        {
            scheduler.getDay(boxNumber).setBoxColor(NORMAL);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 3);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 8);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 9);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 10);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 11);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 12);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 13);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 14);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 15);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 16);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 17);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 18);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 19);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 20);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 21);
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 22);
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 23);
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 24);
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 25);
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 26);
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 27);
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 28);
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 29);
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 30);
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 31);
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 32);
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 33);
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 34);
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 35);
        }


        private void pictureBox45_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 36);
        }


        private void pictureBox46_Click(object sender, EventArgs e)
        {
            singleClick(sender, e, 37);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showNextMonth(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showNextMonth(-1);
        }

    }
}


