using System;
namespace BasicMath.Integer.Linear
{
    public static class Utility
    {

        public static uint GreatestCommonDivisor(uint[] interger)
        {
            if (interger.Length == 0)
                throw new ArgumentNullException();
            if (interger.Length == 1)
                return interger[0];
            if (interger.Length == 2)
                return GreatestCommonDivisor(interger[0], interger[1]);
            int progress;
            if ((interger.Length % 2) == 1)
            {
                progress = 1;
            }
            else
            {
                progress = 2;
            }
            uint[] intermediateState = new uint[interger.Length];
            for (int i = 0; i < interger.Length - 1; i += progress)
            {
                intermediateState[i] = GreatestCommonDivisor(interger[i], interger[i + 1]);
            }
            return GreatestCommonDivisor(intermediateState);
        }

        public static uint GreatestCommonDivisor(uint a, uint b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            uint h;

            do
            {
                h = a % b;
                a = b;
                b = h;
            } while (b != 0);

            return a;
        }

    }
}
