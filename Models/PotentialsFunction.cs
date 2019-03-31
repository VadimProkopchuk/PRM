// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System;
using System.Drawing;

namespace PRM.Models
{
    public class PotentialsFunction
    {
        public PotentialsFunction(double xKoef, double yKoef, double xyKoef, double freeKoef)
        {
            XKoef = xKoef;
            YKoef = yKoef;
            XyKoef = xyKoef;
            FreeKoef = freeKoef;
        }

        public double XKoef { get; set; }
        public double YKoef { get; set; }
        public double XyKoef { get; set; }
        public double FreeKoef { get; set; }

        public double GetValue(Point point) => FreeKoef + (XKoef * point.X) + (YKoef * point.Y )+ (XyKoef * point.X * point.Y);

        public double GetY(double x) => -(XKoef * x + FreeKoef) / (XyKoef * x + YKoef);

        public override string ToString()
        {
            if (Math.Abs(XyKoef) > double.Epsilon)
            {
                return $"y=({-XKoef}*x{(-FreeKoef < 0 ? "" : "+")}{-FreeKoef})/({XyKoef}*x{(YKoef < 0 ? "" : "+")}{YKoef})";
            }

            return Math.Abs(YKoef) > double.Epsilon ? 
                $"y={-(double) XKoef / YKoef}*x{(-(double) FreeKoef / YKoef < 0 ? "" : "+")}{-(double) FreeKoef / YKoef}" : 
                $"x={-(double) FreeKoef / XKoef}";
        }

        public static PotentialsFunction operator +(PotentialsFunction first, PotentialsFunction second) => 
            new PotentialsFunction(first.XKoef + second.XKoef, first.YKoef + second.YKoef,
                first.XyKoef + second.XyKoef, first.FreeKoef + second.FreeKoef);

        public static PotentialsFunction operator *(int koef, PotentialsFunction function) => 
            new PotentialsFunction(koef * function.XKoef, koef * function.YKoef, koef * function.XyKoef, 
                koef * function.FreeKoef);
    }
}