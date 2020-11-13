using System;
namespace BasicMath.Single.Linear
{
    public static class Utility
    {
        public static float Sample(this float[] dArr, float t)
        {
            int count = dArr.Length;
            if (count == 0)
                return float.NaN;
            if (count == 1 || t <= 0.0)
                return dArr[0];
            if (t >= 1.0)
                return dArr[count - 1];
            float iFloat = t * (count - 1);
            int idLower = (int)MathF.Floor(iFloat);
            int idUpper = idLower + 1;
            return dArr[idLower] + (dArr[idUpper] - dArr[idLower]) * (iFloat - idLower);
        }

        public static float Lerp(float from, float to, float value)
        {
            if (value > 1)
                return to;
            if (value < 0)
                return from;
            return from * (1 - value) + to * value;
        }

    }
}
