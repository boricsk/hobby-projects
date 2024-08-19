
static string timeConversion(string s)
{
    string military_time = "";
    string day_period = s.Substring(s.Length - 2);
    int hour = int.Parse(s.Substring(0,2));
    
    if (day_period == "AM")
    {
        if (hour == 12)
        {
            military_time = "00" + s.Substring(2, s.Length - 4);
        }
        else
        {            
            military_time = s.Substring(0, s.Length - 2);
        }
    }

    if (day_period == "PM")
    {
        if (hour == 12)
        {
            military_time = "12" + s.Substring(2, s.Length - 4);
        }
        else 
        {
            hour += 12;
            military_time = hour + s.Substring(2, s.Length - 4);
        }

    }
   return military_time;
}

timeConversion("12:01:00AM");
timeConversion("01:01:00AM");
timeConversion("02:01:00AM");
timeConversion("03:01:00AM");
timeConversion("04:01:00AM");
timeConversion("05:01:00AM");
timeConversion("06:01:00AM");
timeConversion("07:01:00AM");
timeConversion("08:01:00AM");
timeConversion("09:01:00AM");
timeConversion("10:01:00AM");
timeConversion("11:01:00AM");
timeConversion("12:01:00PM");
timeConversion("01:01:00PM");