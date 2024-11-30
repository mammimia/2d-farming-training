using UnityEngine;

public class GameTime
{
    public Season Season { get; private set; }
    public int Year { get; private set; }
    public int Month { get; private set; }
    public int Day { get; private set; }
    public int Hour { get; private set; }
    public int Minute { get; private set; }
    public int Second { get; private set; }

    public GameTime(int year, int month, int day, int hour, int minute, int second)
    {
        Year = year;
        Month = month;
        Season = GetSeason();
        Day = day;
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public Season GetSeason()
    {
        return Month switch
        {
            1 => Season.Winter,
            2 => Season.Winter,
            3 => Season.Spring,
            4 => Season.Spring,
            5 => Season.Spring,
            6 => Season.Summer,
            7 => Season.Summer,
            8 => Season.Summer,
            9 => Season.Autumn,
            10 => Season.Autumn,
            11 => Season.Autumn,
            12 => Season.Winter,
            _ => Season.None,
        }; ;
    }

    public MonthName GetMonthName()
    {
        return Month switch
        {
            0 => MonthName.None,
            1 => MonthName.Jan,
            2 => MonthName.Feb,
            3 => MonthName.Mar,
            4 => MonthName.Apr,
            5 => MonthName.May,
            6 => MonthName.Jun,
            7 => MonthName.Jul,
            8 => MonthName.Aug,
            9 => MonthName.Sep,
            10 => MonthName.Oct,
            11 => MonthName.Nov,
            12 => MonthName.Dec,
            _ => MonthName.None,
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
            Month++;
            if (Month > 12)
            {
                Month = 1;
                Year++;
                EventHandler.CallYearUpdateEvent(this);
            }

            Season = GetSeason();
            if (Month == 3 || Month == 6 || Month == 9 || Month == 12)
            {
                EventHandler.CallSeasonUpdateEvent(GetSeason());
            }
        }
    }
}
