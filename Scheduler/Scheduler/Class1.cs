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
    private string day { get; set; }        // stores the day (ex. Monday)
    private int dayNumber { get; set; }     // stores the day number in the month (ex. 13)
    private bool[] available = new bool[48];    // store available times

    // List to store events for this day
    List<Event> events = new List<Event>();

    // retrieves events
    public Event getEvent(string name)     
    {
        for(int i = 0; i < events.Count; i++)
        {
            if(events[i].getName() == name) { return events[i]; }   // event found
        }
        return null;                        // no event found
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
    private string monthName { get; set; }      // stores the month (ex. January)

    // List to store days in the month
    List<Day> days = new List<Day>();   

    public Day getDay(int day)              // gets day 
    {
        return days[day];                   // return current day
    }
}

// Stores information about a year
public class Year
{
    private int year { get; set; }          // stores the year (ex. 2018)

    // List to store month in a year 
    List<Month> months = new List<Month>();

    public Month getMonth(int month)        // gets month 
    {
        return months[month];               // return current month
    }
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

    public void addEvent(int month, int day, double start, double end, string name)
    {
        Year curr = new Year();

        // event time is available, can input event
        if (curr.getMonth(month).getDay(day).checkAvailability(start, end)) 
        {
            curr.getMonth(month).getDay(day).setAvailability(start, end);   // set availability array
            curr.getMonth(month).getDay(day).setEvent(name, start, end);    // set event
        }
        else
        {
            Console.Write("Cannot add event, time overlap.../n");
            //Console.Write("No event found.../n");
        }
    }

    public Event findEvent_byName(string eventName)
    {
        
        return null;
    }

    public Event findEvent_byDate(int year, int month, int day)
    {

        return null;
    }

    public Event findEvent_byHour(double start, double end)
    {

        return null;
    }
}
