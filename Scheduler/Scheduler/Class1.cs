using System;
using System.Collections.Generic;

// Stores information about an event
public class Event 
{
    private string eventName { get; set; }      // event name   
    private double startHour { get; set; }      // event start time
    private double endHour { get; set; }        // event end date 
    private string description { get; set; }    // event description (optional)
    private string startDate { get; set; }      // event start date
    private string endDate { get; set; }        // event end date
}

// Stores information about a day 
public class Day
{
    private string day { get; set; }        // stores the day (ex. Monday)
    private int dayNumber { get; set; }     // stores the day number in the month (ex. 13)

    // List to store events for this day
    List<Event> events = new List<Event>();
}

// Stores information about a month
public class Month
{
    private string monthName { get; set; }      // stores the month (ex. January)

    // List to store days in the month
    List<Day> days = new List<Day>();   
}

// Stores information about a year
public class Year
{
    private int year { get; set; }          // stores the year (ex. 2018)

    // List to store month in a year 
    List<Month> months = new List<Month>();
}
