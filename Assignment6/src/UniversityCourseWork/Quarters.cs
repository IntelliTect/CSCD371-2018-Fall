﻿using System;

namespace Assignment6
{
    [Flags]
    public enum Quarters : byte
    {
        Spring = 1,
        Summer = 2,
        Fall = 4,
        Winter = 8
    }
}