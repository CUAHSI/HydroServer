using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
// take from: http://www.informit.com/guides/content.asp?g=dotnet&seqNum=175&rl=1

namespace WaterOneFlowImpl
{
    
        public struct W3CDateTime : IComparable
        {
            private DateTime dtime;		// The time in the local time zone
            private TimeSpan ofs;		// offset from dtime to universal time

            #region Constructors
            /// <summary>
            /// Create a W3CDateTime structure from the passed datetime and offset
            /// </summary>

            /// <param name="dt"></param>
            /// <param name="off"></param>
            public W3CDateTime(DateTime dt, TimeSpan off)
            {
                dtime = dt;
                ofs = off;
            }

            /// <summary>
            /// Create a W3CDateTime structure from the passed DateTime.
            /// Offset is assumed to be the local offset.
            /// </summary>

            /// <param name="dt"></param>
            public W3CDateTime(DateTime dt)
                : this(dt, LocalUtcOffset)
            {
            }

            #endregion

            #region Properties

            public DateTime DateTime
            {
                get { return dtime; }
            }

            public DateTime LocalTime
            {
                get { return UtcTime + LocalUtcOffset; }
            }

            static public TimeSpan LocalUtcOffset
            {
                get
                {
                    DateTime xNow = DateTime.Now;
                    return xNow - xNow.ToUniversalTime();
                }
            }

            static public W3CDateTime MaxValue
            {
                get { return new W3CDateTime(DateTime.MaxValue, TimeSpan.Zero); }
            }

            static public W3CDateTime MinValue
            {
                get { return new W3CDateTime(DateTime.MinValue, TimeSpan.Zero); }
            }

            static public W3CDateTime Now
            {
                get { return new W3CDateTime(DateTime.Now); }
            }

            static public W3CDateTime Today
            {
                get { return new W3CDateTime(DateTime.Today); }
            }

            static public W3CDateTime UtcNow
            {
                get { return new W3CDateTime(DateTime.UtcNow, TimeSpan.Zero); }
            }

            public TimeSpan UtcOffset
            {
                get { return ofs; }
            }

            public DateTime UtcTime
            {
                get { return dtime - ofs; }
            }

            #endregion

            #region methods

            public W3CDateTime Add(TimeSpan val)
            {
                return new W3CDateTime(dtime + val, this.ofs);
            }

            public W3CDateTime AddDays(double val)
            {
                return new W3CDateTime(dtime.AddDays(val), this.ofs);
            }

            public W3CDateTime AddHours(double val)
            {
                return new W3CDateTime(dtime.AddHours(val), this.ofs);
            }

            public W3CDateTime AddMilliseconds(double val)
            {
                return new W3CDateTime(dtime.AddMilliseconds(val), this.ofs);
            }

            public W3CDateTime AddMinutes(double val)
            {
                return new W3CDateTime(dtime.AddMinutes(val), this.ofs);
            }

            public W3CDateTime AddMonths(int val)
            {
                return new W3CDateTime(dtime.AddMonths(val), this.ofs);
            }

            public W3CDateTime AddSeconds(double val)
            {
                return new W3CDateTime(dtime.AddSeconds(val), this.ofs);
            }

            public W3CDateTime AddTicks(long val)
            {
                return new W3CDateTime(dtime.AddTicks(val), this.ofs);
            }

            public W3CDateTime AddYears(int val)
            {
                return new W3CDateTime(dtime.AddYears(val), this.ofs);
            }

            public static int Compare(W3CDateTime t1, W3CDateTime t2)
            {
                return DateTime.Compare(t1.UtcTime, t2.UtcTime);
            }

            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is W3CDateTime))
                    return false;
                return DateTime.Equals(this.UtcTime, ((W3CDateTime)obj).UtcTime);
            }

            public static bool Equals(W3CDateTime t1, W3CDateTime t2)
            {
                return DateTime.Equals(t1.UtcTime, t2.UtcTime);
            }

            public override int GetHashCode()
            {
                return dtime.GetHashCode() ^ this.ofs.GetHashCode();
            }

            public TimeSpan Subtract(W3CDateTime val)
            {
                return UtcTime.Subtract(val.UtcTime);
            }

            public W3CDateTime Subtract(TimeSpan val)
            {
                return new W3CDateTime(dtime.Subtract(val), this.ofs);
            }

            public W3CDateTime ToLocalTime(TimeSpan offset)
            {
                return new W3CDateTime(UtcTime - offset, offset);
            }

            public W3CDateTime ToLocalTime()
            {
                return ToLocalTime(LocalUtcOffset);
            }

            public W3CDateTime ToUniversalTime()
            {
                return new W3CDateTime(UtcTime, TimeSpan.Zero);
            }

            static public W3CDateTime Parse(string s)
            {
                const string Rfc822DateFormat =
                      @"^((Mon|Tue|Wed|Thu|Fri|Sat|Sun), *)?(?<day>\d\d?) +" +
                      @"(?<month>Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec) +" +
                      @"(?<year>\d\d(\d\d)?) +" +
                      @"(?<hour>\d\d):(?<min>\d\d)(:(?<sec>\d\d))? +" +
                      @"(?<ofs>([+\-]?\d\d\d\d)|UT|GMT|EST|EDT|CST|CDT|MST|MDT|PST|PDT)$";
               /* const string W3CDateFormat =
                      @"^(?<year>\d\d\d\d)" +
                      @"(-(?<month>\d\d)"+
                      @"(-(?<day>\d\d)"+
                      @"(T(?<hour>\d\d):(?<min>\d\d)"+
                      @"(:(?<sec>\d\d)(?<ms>\.\d+)?)?" +
                      @"(?<ofs>(Z|[+\-]\d\d:\d\d))?)?)?)?$";
                * */
                
                const string W3CDateFormat =
                  @"^(?<year>\d\d\d\d)" +
                  @"(-(?<month>\d\d)(-(?<day>\d\d)(T(?<hour>\d\d):(?<min>\d\d)(:(?<sec>\d\d)(?<ms>\.\d+)?)?" +
                  @"(?<ofs>(Z|[+\-]\d\d:\d\d))?)?)?)?$";
                
                //string combinedFormat = string.Format(
                 // @"(?<rfc822>{0})|(?<w3c>{1})", Rfc822DateFormat, W3CDateFormat);
                string combinedFormat = string.Format(@"(?<w3c>{0})", W3CDateFormat);
                // try to parse it
                Regex reDate = new Regex(combinedFormat);
                Match m = reDate.Match(s);
                if (!m.Success)
                {
                    // Didn't match either expression. Throw an exception.
                    throw new FormatException("String is not a valid date time stamp.");
                }
                try
                {
                    bool isRfc822 = m.Groups["rfc822"].Success;
                    int year = int.Parse(m.Groups["year"].Value);
                    // handle 2-digit and 3-digit years
                    if (year < 1000)
                    {
                        if (year < 50) year = year + 2000; else year = year + 1999;
                    }

                    int month;
                    if (isRfc822)
                        month = ParseRfc822Month(m.Groups["month"].Value);
                    else
                        month = (m.Groups["month"].Success) ? int.Parse(m.Groups["month"].Value) : 1;

                    int day = m.Groups["day"].Success ? int.Parse(m.Groups["day"].Value) : 1;
                    int hour = m.Groups["hour"].Success ? int.Parse(m.Groups["hour"].Value) : 0;
                    int min = m.Groups["min"].Success ? int.Parse(m.Groups["min"].Value) : 0;
                    int sec = m.Groups["sec"].Success ? int.Parse(m.Groups["sec"].Value) : 0;
                    int ms = m.Groups["ms"].Success ? (int)Math.Round

              ((1000 * double.Parse(m.Groups["ms"].Value))) : 0;

                    TimeSpan ofs = TimeZone.CurrentTimeZone.GetUtcOffset(System.DateTime.Now);  //TimeSpan.Zero;

                    if (m.Groups["ofs"].Success)
                    {
                        if (isRfc822)
                            ofs = ParseRfc822Offset(m.Groups["ofs"].Value);
                        else
                            ofs = ParseW3COffset(m.Groups["ofs"].Value);
                    }
                    return new W3CDateTime(new DateTime(year, month, day, hour, min, sec, ms), ofs);
                }
                catch (Exception ex)
                {
                    throw new FormatException("String is not a valid date time stamp.", ex);
                }
            }

            private static readonly string[] MonthNames = new string[]
    {
      "Jan", "Feb", "Mar", "Apr", "May", "Jun", 
      "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};

            private static int ParseRfc822Month(string monthName)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (monthName == MonthNames[i])
                    {
                        return i + 1;
                    }
                }
                throw new ApplicationException("Invalid month name");
            }

            private static TimeSpan ParseRfc822Offset(string s)
            {
                if (s == string.Empty)
                    return TimeSpan.Zero;
                int hours = 0;
                switch (s)
                {
                    case "UT":
                    case "GMT":
                        break;
                    case "EDT": hours = -4; break;
                    case "EST":
                    case "CDT": hours = -5; break;
                    case "CST":
                    case "MDT": hours = -6; break;
                    case "MST":
                    case "PDT": hours = -7; break;
                    case "PST": hours = -8; break;
                    default:
                        if (s[0] == '+')
                        {
                            string sfmt = s.Substring(1, 2) + ":" + s.Substring(3, 2);
                            return TimeSpan.Parse(sfmt);
                        }
                        else
                            return TimeSpan.Parse(s.Insert(s.Length - 2, ":"));
                }
                return TimeSpan.FromHours(hours);
            }

            private static TimeSpan ParseW3COffset(string s)
            {
                if (s == string.Empty)
                    return TimeZone.CurrentTimeZone.GetUtcOffset(System.DateTime.Now);

                else if ( s == "Z")
                    return TimeSpan.Zero;
                else
                {
                    if (s[0] == '+')
                        return TimeSpan.Parse(s.Substring(1));
                    else
                        return TimeSpan.Parse(s);
                }
            }

            private static string FormatOffset(TimeSpan ofs, string separator)
            {
                string s = string.Empty;
                if (ofs >= TimeSpan.Zero)
                    s = "+";
                return s + ofs.Hours.ToString("00") + separator + ofs.Minutes.ToString("00");
            }

            // Format is "X" (RFC822) or "W" (W3C)
            public string ToString(string format)
            {
                switch (format)
                {
                    case "X":
                        return dtime.ToString(@"ddd, dd MMM yyyy HH\:mm\:ss ") +
                            FormatOffset(ofs, "");
                    case "W":
                        return dtime.ToString(@"yyyy-\MM\-ddTHH\:mm\:ss") +
                            FormatOffset(ofs, ":");
                    default:
                        throw new FormatException("Unknown format specified.");
                }
            }

            public override string ToString()
            {
                return ToString("W");
            }
            #endregion

            #region Operators
            public static W3CDateTime operator +(W3CDateTime d, TimeSpan s)
            {
                return d.Add(s);
            }

            public static bool operator ==(W3CDateTime t1, W3CDateTime t2)
            {
                return Equals(t1, t2);
            }

            public static bool operator >(W3CDateTime t1, W3CDateTime t2)
            {
                return (Compare(t1, t2) > 0);
            }

            public static bool operator >=(W3CDateTime t1, W3CDateTime t2)
            {
                return (Compare(t1, t2) >= 0);
            }

            public static bool operator !=(W3CDateTime t1, W3CDateTime t2)
            {
                return !Equals(t1, t2);
            }

            public static bool operator <(W3CDateTime t1, W3CDateTime t2)
            {
                return (Compare(t1, t2) < 0);
            }

            public static bool operator <=(W3CDateTime t1, W3CDateTime t2)
            {
                return (Compare(t1, t2) <= 0);
            }

            public static TimeSpan operator -(W3CDateTime t1, W3CDateTime t2)
            {
                return t1.Subtract(t2);
            }

            public static W3CDateTime operator -(W3CDateTime dt, TimeSpan s)
            {
                return dt.Subtract(s);
            }

            #endregion

            #region IComparable Members

            public int CompareTo(object o)
            {
                if (o == null)
                    return 1;
                if (o is W3CDateTime)
                    return Compare(this, (W3CDateTime)o);
                throw new ArgumentException("Don't know how to compare");
            }

            #endregion
        }
    }
