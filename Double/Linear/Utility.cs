using System;
namespace BasicMath.Double.Linear
{
    public static class Utility
    {
        public static double Sample(this double[] dArr, double t)
        {
            int count = dArr.Length;
            if (count == 0)
                return double.NaN;
            if (count == 1 || t <= 0.0)
                return dArr[0];
            if (t >= 1.0)
                return dArr[count - 1];
            double iDouble = t * (count - 1);
            int idLower = (int)Math.Floor(iDouble);
            int idUpper = idLower + 1;
            return dArr[idLower] + (dArr[idUpper] - dArr[idLower]) * (iDouble - idLower);
        }

        public static double Lerp(double from, double to, double value)
        {
            if (value > 1)
                return to;
            if (value < 0)
                return from;
            return from * (1 - value) + to * value;
        }

    }
}
