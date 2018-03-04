using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;


// Stores information about an event
namespace Scheduler
{
    public class Event
    {
        private string eventName;       // event name   
        private double startHour;       // event start time
        private double endHour;         // event end date 
                                        //private string description;     // event description (optional)
                                        //private string startDate;       // event start date
                                        //private string endDate;         // event end date

        public string getName() { return eventName; }               // get event name
        public void setName(string name) { eventName = name; }      // set event name

        public double getStart() { return startHour; }              // get start hour
        public void setStart(double time) { startHour = time; }     // set start hour

        public double getEnd() { return endHour; }                  // get end hour
        public void setEnd(double time) { endHour = time; }         // set end hour

        //public string getDescription() { return description; }          // get description
        //public void setDescription(string desc) { description = desc; } // set description (optional)
    }

    // Stores information about a day 
    public class Day
    {
        private string day;                         // stores the day (ex. Monday)
        private int dayNumber;                      // stores the day number in the month (ex. 13)
        private bool[] available = new bool[48];    // store available times
        List<Event> events = new List<Event>();     // List to store events for this day
        private PictureBox colorBox;

        public Day()
        {
            for (int i = 0; i < 48; i++) { available[i] = true; }    // make all values true
            colorBox = new PictureBox();
        }

        public Day(int num)
        {
            dayNumber = num;
            colorBox = new PictureBox();
        }
        public string getDay() { return day; }              // get day name 
        public void setDay(string day2) { day = day2; }     // set day name

        public int getNumber() { return dayNumber; }                // get day number
        public void setNumber(int number) { dayNumber = number; }   // set day number   

        // retrieves list of events
        public List<Event> getEvents() { return events; }

        // find all events with a name
        public List<Event> findEvent(string name)
        {
            List<Event> tempEvent = new List<Event>();      // temporary store events

            for (int i = 0; i < events.Count; i++)
            {
                // add all events with this name to the list
                if (events[i].getName() == name) { tempEvent.Add(events[i]); }
            }
            return tempEvent;                               // return list of events 
        }

        // sets events
        public void setEvent(string name, double start, double end)
        {
            Event tempEvent = new Event();      // create event instance
            tempEvent.setName(name);            // set name
            tempEvent.setStart(start);          // set start time
            tempEvent.setEnd(end);              // set end time
            events.Add(tempEvent);              // add event 
        }

        // checks if a time is availabe for an event to be input into
        public bool checkAvailability(double start, double end)
        {
            int startIndex = Convert.ToInt32(start * 2);    // convert time to start index    
            int endIndex = Convert.ToInt32(end * 2);        // convert time to end index
            for (int i = startIndex; i < endIndex; i++)     // loop and check availability
            {
                if (!available[i]) { return false; }         // not availabe
            }
            return true;                                    // available
        }

        // updates availability array 
        public void setAvailability(double start, double end)
        {
            int startIndex = Convert.ToInt32(start * 2);    // convert time to start index
            int endIndex = Convert.ToInt32(end * 2);        // convert time to end index
            for (int i = startIndex; i < endIndex; i++)
            {
                available[i] = false;                       // set to not available
            }
        }

        public int getEventRange()
        {
            return events.Count;
        }

        public Event getEvent(int index)
        {
            return events[index];
        }

        public void setColorBox(object sender)
        {
            colorBox = (PictureBox)sender;
        }

        public PictureBox getColorBox()
        {
            return colorBox;
        }

        public void setBoxColor(Color color)
        {
            colorBox.BackColor = color;
        }
    }

    // Stores information about a month
    public class Month
    {
        private int monthNumber;                // stores the month number 
        private string monthName;               // stores the month (ex. January)
        List<Day> days = new List<Day>();       // List to store days in the month

        public int getNumber() { return monthNumber; }              // get month number
        public void setNumber(int number) { monthNumber = number; } // set month number

        public string getName() { return monthName; }               // get month name
        public void setName(string name) { monthName = name; }      // set month name

        public Day getDay(int day)              // gets day 
        { return days[day]; }                   // return current day

        public int getDayRange()
        { return days.Count; }                  // get day list lenght

        // create a day instance and put it into day list
        public void addDay(int number, string name)
        {
            Day insert = new Day();
            insert.setDay(name);
            insert.setNumber(number);
            days.Add(insert);
        }
    }

    // Stores information about a year
    public class Year
    {
        private int year;                       // stores the year (ex. 2018)
        List<Month> months = new List<Month>(); // List to store month in a year 

        public Year(int year) {this.year = year;}

        public Year() { }
        public int getYear() { return year; }               // get year
        public void setYear(int year2) { year = year2; }    // set year

        // create a month instance and input into the list
        public void addMonth(int number, string name)
        {
            Month insert = new Month();
            insert.setName(name);
            insert.setNumber(number);
            months.Add(insert);
        }

        public Month getMonth(int month)        // gets month 
        { return months[month]; }               // return current month

        public int getMonthRange()
        { return months.Count; }                // get month list lenght
    }



    /*
    using System;
    using System.Collections.Generic;


    // Stores information about an event
    public class Event 
    {
        private string eventName;       // event name   
        private double startHour;       // event start time
        private double endHour;         // event end date 
        //private string description;     // event description (optional)
        //private string startDate;       // event start date
        //private string endDate;         // event end date

        public string getName() { return eventName; }               // get event name
        public void setName(string name) { eventName = name; }      // set event name

        public double getStart() { return startHour; }              // get start hour
        public void setStart(double time) { startHour = time; }     // set start hour

        public double getEnd() { return endHour; }                  // get end hour
        public void setEnd(double time) { endHour = time; }         // set end hour

        //public string getDescription() { return description; }          // get description
        //public void setDescription(string desc) { description = desc; } // set description (optional)
    }

    // Stores information about a day 
    public class Day
    {
        private string day;                         // stores the day (ex. Monday)
        private int dayNumber;                      // stores the day number in the month (ex. 13)
        private bool[] available = new bool[48];    // store available times
        List<Event> events = new List<Event>();     // List to store events for this day

        public Day ()
        {
            for(int i = 0; i < 48; i++) { available[i] = true; }    // make all values true
        }
        public string getDay() { return day; }              // get day name 
        public void setDay(string day2) { day = day2; }     // set day name

        public int getNumber() { return dayNumber; }                // get day number
        public void setNumber(int number) { dayNumber = number; }   // set day number   

        // retrieves list of events
        public List<Event> getEvents() { return events; }

        // find all events with a name
        public List<Event> findEvent(string name)
        {
            List<Event> tempEvent = new List<Event>();      // temporary store events

            for(int i=0; i < events.Count; i++)
            {
                // add all events with this name to the list
                if(events[i].getName() == name) { tempEvent.Add(events[i]); }
            }
            return tempEvent;                               // return list of events 
        }

        // sets events
        public void setEvent(string name, double start, double end) 
        {
            Event tempEvent = new Event();      // create event instance
            tempEvent.setName(name);            // set name
            tempEvent.setStart(start);          // set start time
            tempEvent.setEnd(end);              // set end time
            events.Add(tempEvent);              // add event 
        }

        // checks if a time is availabe for an event to be input into
        public bool checkAvailability(double start, double end)
        {
            int startIndex = Convert.ToInt32(start * 2);    // convert time to start index    
            int endIndex = Convert.ToInt32(end * 2);        // convert time to end index
            for (int i = startIndex; i < endIndex; i++)     // loop and check availability
            {
                if(!available[i]) { return false; }         // not availabe
            }
            return true;                                    // available
        }

        // updates availability array 
        public void setAvailability(double start, double end)
        {
            int startIndex = Convert.ToInt32(start * 2);    // convert time to start index
            int endIndex = Convert.ToInt32(end * 2);        // convert time to end index
            for (int i = startIndex; i < endIndex; i++)
            {
                available[i] = false;                       // set to not available
            }
        }
    }

    // Stores information about a month
    public class Month
    {
        private int monthNumber;                // stores the month number 
        private string monthName;               // stores the month (ex. January)
        List<Day> days = new List<Day>();       // List to store days in the month

        public int getNumber() { return monthNumber; }              // get month number
        public void setNumber(int number) { monthNumber = number; } // set month number

        public string getName() { return monthName; }               // get month name
        public void setName(string name) { monthName = name; }      // set month name

        public Day getDay(int day)              // gets day 
        { return days[day]; }                   // return current day

        public int getDayRange()
        { return days.Count; }                  // get day list lenght

        // create a day instance and put it into day list
        public void addDay(int number, string name)
        {
            Day insert = new Day();
            insert.setDay(name);
            insert.setNumber(number);
            days.Add(insert);
        }
    }

    // Stores information about a year
    public class Year
    {
        private int year;                       // stores the year (ex. 2018)
        List<Month> months = new List<Month>(); // List to store month in a year 

        public int getYear() { return year; }               // get year
        public void setYear(int year2) { year = year2; }    // set year

        // create a month instance and input into the list
        public void addMonth(int number, string name)
        {
            Month insert = new Month();
            insert.setName(name);
            insert.setNumber(number);
            months.Add(insert);
        }

        public Month getMonth(int month)        // gets month  
        { return months[month]; }               // return current month

        public int getMonthRange()
        { return months.Count; }                // get month list lenght
    }

    public class TestClass
    {
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
            if (curr.getMonth(month-1).getDay(day-1).checkAvailability(start, end)) 
            {
                curr.getMonth(month-1).getDay(day-1).setAvailability(start, end);   // set availability array
                curr.getMonth(month-1).getDay(day-1).setEvent(name, start, end);    // set event
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
            for(int i = 0; i < curr.getMonthRange(); i++)
            {
                // iterate through days of the month
                for(int j = 0; j < curr.getMonth(i).getDayRange(); j++)
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

        // load in the names of months 
        public void loadCalender(Year curr)
        {
            string line;
            int monthCount = 1;
            //Year curr = new Year();
            //curr.setYear(2018);

            System.IO.StreamReader file = new System.IO.StreamReader("C:/Users/Boggie/Desktop/2018.txt");
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

                string dayName="";

                for(int i = 1; i <= numberOfDays; i++)      // loop all days of month
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
                    curr.getMonth(monthCount-1).addDay(i, dayName);
                    startDay++; 
                }
                monthCount++;
            }
            file.Close();
        }

        // reads a text file with all the stored events and loads them into the calendar
        public void loadEvents(Year curr)
        {
            int month = 0;
            int day = 0;
            double start = 0;
            double end = 0;
            string name = "";
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader("C:/Users/Boggie/Desktop/2018.txt");
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
        }


    }

    */
}

