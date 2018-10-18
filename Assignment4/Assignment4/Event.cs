﻿using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Assignment4
{
    public class Event
    {
        // Auto property
        public static int EventCount { get; private set; }

        // validated property
        public (DateTime startTime, DateTime endTime) TimeRange
        {
            get => _timeRange;
            
            set
            {
                if (value.startTime.Day != value.endTime.Day || value.startTime.Year != value.endTime.Year 
                                                             || value.startTime.Month != value.endTime.Month)
                {
                    throw new InvalidDataException("Event must start and end on same day!");
                }
                
                if (! (value.endTime.CompareTo(value.startTime) > 0)) // if startTime is not before endTime
                {
                    throw new InvalidDataException("Start time must be before end time!");
                }

                _timeRange = value;
            }
        }

        private (DateTime startTime, DateTime endTime) _timeRange;

        public Event(DateTime startingTime, DateTime endingTime)
        {
            TimeRange = (startingTime, endingTime);
            EventCount++;
        }

        ~Event()
        {
            EventCount--;
        }

        public static void ResetInstanceCount()
        {
            EventCount = 0;
        }
        
        public string GetSummaryInformation()
        {
            return $"The event starts at {TimeRange.startTime.Hour} and ends at {TimeRange.endTime.Hour}";
        }
    }
}