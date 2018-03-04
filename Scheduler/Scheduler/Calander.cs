using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Scheduler
{
    public class Calander
    {
        public PictureBox calander;
        private Dictionary<int, Day> dataMap;

        public int selected;
        public int prevSelected;
        
        
        public Calander(PictureBox calander)
        {
            this.calander = calander;
            dataMap = new Dictionary<int, Day>();

            selected = 1; 
            prevSelected = 1;
        }

        public Dictionary<int, Day> getDayMap()
        {
            return dataMap;
        }

        public void addDayMap(int boxNum, Day sender)
        {
            dataMap.Add(boxNum, sender);
        }

        public Day getDay(int i)
        {
            if (dataMap.ContainsKey(i))
                return dataMap[i];
            return null;
        }

        // adds and event to the calendar 
        // @ parameters 
        //      month of event
        //      day of event 
        //      start time of event
        //      end time of event
        //      name of event

        public void addEvent(int month, int day, double start, double end, string name, Year curr)
        {
            //Year curr = new Year();

            // event time is available, can input event
            if (curr.getMonth(month - 1).getDay(day - 1).checkAvailability(start, end))
            {
                curr.getMonth(month - 1).getDay(day - 1).setAvailability(start, end);   // set availability array
                curr.getMonth(month - 1).getDay(day - 1).setEvent(name, start, end);    // set event
            }
            else
            {
                Console.Write("Cannot add event, time overlap.../n");
                //Console.Write("No event found.../n");
            }
        }

        // find all events with a certain name
        public List<Event> findEvent_byName(string eventName)
        {
            Year curr = new Year();
            List<Event> allEvents = new List<Event>();

            // iterate through months 
            for (int i = 0; i < curr.getMonthRange(); i++)
            {
                // iterate through days of the month
                for (int j = 0; j < curr.getMonth(i).getDayRange(); j++)
                {
                    // add list of events to final list
                    allEvents.AddRange(curr.getMonth(i).getDay(j).findEvent(eventName));
                }
            }
            return allEvents;
        }

        // find all events in a certain date
        public List<Event> findEvent_byDate(int year, int month, int day)
        {
            Year curr = new Year();
            //List<Event> allEvents = new List<Event>();

            // return a list of events 
            return curr.getMonth(month).getDay(day).getEvents();
        }

        public void SaveCalendar(Year curr, User user)
        {
            string year = curr.getYear().ToString();
            string userName = user.getUserName();


            string path = "Files/" + year + "_" + "Events_" + userName + ".txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < curr.getMonthRange(); i++)
                {
                    for (int j = 0; j < curr.getMonth(i).getDayRange(); j++)
                    {
                        for (int k = 0; k < curr.getMonth(i).getDay(j).getEventRange(); k++)
                        {
                            sw.WriteLine((i + 1).ToString());
                            sw.WriteLine((j + 1).ToString());
                            sw.WriteLine(curr.getMonth(i).getDay(j).getEvent(k).getName());
                            sw.WriteLine(curr.getMonth(i).getDay(j).getEvent(k).getStart().ToString());
                            sw.WriteLine(curr.getMonth(i).getDay(j).getEvent(k).getEnd().ToString());
                        }
                    }
                }
            }
        }


        // load in the names of months 
        public int loadCalender(Year curr, User user)
        {
            string line;
            int monthCount = 1;
            //Year curr = new Year();
            //curr.setYear(2018);

            string year = curr.getYear().ToString();
            string userName = user.getUserName();


            string path = "Files/" + year + "_" + userName + ".txt";

            if (!File.Exists(path)) return -1;

            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
     
                //line = ReadLine()System.Console.WriteLine(line);     // read line

                curr.addMonth(monthCount, line);    // add month to year list

                //System.Console.WriteLine(line);     // read next line
                //System.Console.WriteLine(line);     // read next line
                line = file.ReadLine();
                int numberOfDays = Int32.Parse(line);   // turn string to int

                //System.Console.WriteLine(line);     // rad next line
                line = file.ReadLine();
                int startDay = Int32.Parse(line);       // turn string to int

                string dayName = "";

                for (int i = 1; i <= numberOfDays; i++)      // loop all days of month
                {
                    switch (startDay % 7)
                    {
                        case 1:
                            dayName = "Monday";
                            break;
                        case 2:
                            dayName = "Tuesday";
                            break;
                        case 3:
                            dayName = "Wednesday";
                            break;
                        case 4:
                            dayName = "Thursday";
                            break;
                        case 5:
                            dayName = "Friday";
                            break;
                        case 6:
                            dayName = "Saturday";
                            break;
                        case 7:
                            dayName = "Sunday";
                            break;
                        default:
                            Console.Write("ERROR.../n");
                            break;
                    }
                    // add a day to a month 
                    curr.getMonth(monthCount - 1).addDay(i, dayName);
                    startDay++;
                }
                monthCount++;
            }
            file.Close();
            return 0;
        }

        // reads a text file with all the stored events and loads them into the calendar
        public int loadEvents(Year curr, User user)
        {
            int month = 0;
            int day = 0;
            double start = 0;
            double end = 0;
            string name = "";
            string line;

            string year = curr.getYear().ToString();
            string userName = user.getUserName();


            string path = "Files/" + year + "_" + "Events_" + userName + ".txt";

            if (!File.Exists(path)) return -1;

            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                month = Int32.Parse(line);  // get month number
                line = file.ReadLine();
                day = Int32.Parse(line);    // get day number
                line = file.ReadLine();
                name = line;                // get event name
                line = file.ReadLine();
                start = Double.Parse(line); // get start time
                line = file.ReadLine();
                end = Double.Parse(line);   // get end time

                addEvent(month, day, start, end, name, curr);   // add event to calendar
            }

            file.Close();
            return 0;
        }
    }
}
