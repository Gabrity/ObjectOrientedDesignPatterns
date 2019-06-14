﻿namespace Builder
{
    public interface ISwap
    {
        IDayCounter DayCounter { get; set; }
        ILeg Leg1 { get; set; }
        ILeg Leg2 { get; set; }
    }
}