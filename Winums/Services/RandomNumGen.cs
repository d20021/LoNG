using System;
using System.Collections.Generic;

namespace Winums
{
    public class RandomNumGen
    {
        static int GenRandNumber(List<int> existingNumbers) {
            Random rnd = new Random();
            int number = 0;

            do
            {
                number = rnd.Next(1, 49);

            } while (existingNumbers.Contains(number));

            return number;
        }

        public static List<int> GenDrawSequence() {
            List <int> seq = new List<int>();

            for (int i = 0; i < 6; i++) {
                seq.Add(GenRandNumber(seq));
            }
            seq.Sort();
            return seq;
        }
    }
}
