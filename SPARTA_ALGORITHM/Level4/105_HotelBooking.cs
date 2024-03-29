using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class HotelBooking
    {
        public struct Booking
        {
            public string StartTime;
            public string EndTime;
            public Booking(string startTime, string endTime)
            {
                StartTime = startTime;
                EndTime = endTime;
            }
        }

        public class Solution
        {
            public int solution(string[,] book_time)
            {
                List<Booking> bookings = new List<Booking>();

                for (int i = 0; i < book_time.GetLength(0); i++)
                {
                    bookings.Add(new Booking(book_time[i, 0], book_time[i, 1]));
                }

                bookings.Sort((a, b) => (a.StartTime).CompareTo(b.StartTime));

                List<Booking> sortedBookings = new List<Booking>();
                sortedBookings.Add(bookings[0]);
                for (int i = 1; i < bookings.Count; i++)
                {
                    bool isPossible = false;
                    for (int j = 0; j < sortedBookings.Count; j++)
                    {
                        if (CompareBookingTime(sortedBookings[j], bookings[i]))
                        {
                            sortedBookings[j] = bookings[i];
                            isPossible = true;
                            break;
                        }
                    }
                    if (!isPossible) sortedBookings.Add(bookings[i]);
                }

                return sortedBookings.Count;
            }

            static bool CompareBookingTime(Booking booking1, Booking booking2)
            {
                StringBuilder sb = new StringBuilder();
                string[] str = booking2.StartTime.Split(':');
                int hour = int.Parse(str[0]);
                int minute = int.Parse(str[1]);

                if (minute + 10 == 60) hour++;
                else minute += 10;

                sb.Append(hour).Append(":").Append(minute);

                if ((booking1.EndTime).CompareTo(sb.ToString()) >= 0)
                    return false;
                else
                    return true;
            }
        }
    }
}
