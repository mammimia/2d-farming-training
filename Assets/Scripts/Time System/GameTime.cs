using UnityEngine;

public class GameTime
{
    public Season Season { get; private set; }
    public int Year { get; private set; }
    public int Day { get; private set; }
    public int Hour { get; private set; }
    public int Minute { get; private set; }
    public int Second { get; private set; }

    public GameTime(Season season, int year, int day, int hour, int minute, int second)
    {
        Season = season;
        Year = year;
        Day = day;
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public DayOfTheWeek GetDayOfTheWeek()
    {
        int dayOfTheWeek = Day % 7;
        return dayOfTheWeek switch
        {
            0 => DayOfTheWeek.Sunday,
            1 => DayOfTheWeek.Monday,
            2 => DayOfTheWeek.Tuesday,
            3 => DayOfTheWeek.Wednesday,
            4 => DayOfTheWeek.Thursday,
            5 => DayOfTheWeek.Friday,
            6 => DayOfTheWeek.Saturday,
            _ => DayOfTheWeek.None,
        };
    }

    public void IncrementTime()
    {
        Second++;
        if (Second >= 60)
        {
            Second -= 60;
            Minute++;
            EventHandler.CallTimeUpdateEvent(this);
        }

        if (Minute >= 60)
        {
            Minute = 0;
            Hour++;
            EventHandler.CallHourUpdateEvent(this);
        }

        if (Hour >= 24)
        {
            Hour = 0;
            Day++;
            EventHandler.CallDayUpdateEvent(this);
        }

        if (Day > 30)
        {
            Day = 1;
            Season++;
            EventHandler.CallSeasonUpdateEvent(Season);
        }

        if (Season > Season.Winter)
        {
            Season = Season.Spring;
            Year++;
            EventHandler.CallYearUpdateEvent(this);
        }
    }
}
