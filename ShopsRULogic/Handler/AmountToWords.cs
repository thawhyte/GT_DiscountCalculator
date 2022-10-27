﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRULogic.Handler
{
    public class AmountToWords
    {
        #region Number to  Word

        public string NumberToWords(double doubleNumber)
        {
            int beforeFloatingPoint = (int)Math.Floor(doubleNumber);
            string beforeFloatingPointWord = string.Format("{0} dollar", NumberToWords(beforeFloatingPoint));
            string afterFloatingPointWord = string.Format("{0} cent(s) only.", SmallNumberToWord((int)((doubleNumber - beforeFloatingPoint) * 100), ""));
            if ((int)((doubleNumber - beforeFloatingPoint) * 100) > 0)
            {
                return string.Format("{0} and {1}", beforeFloatingPointWord, afterFloatingPointWord);
            }
            else
            {
                return string.Format("{0} only", beforeFloatingPointWord);
            }
        }

        private string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            var words = "";

            if (number / 1000000000 > 0)
            {
                words += NumberToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if (number / 1000000 > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            words = SmallNumberToWord(number, words);

            return words;
        }

        private string SmallNumberToWord(int number, string words)
        {
            if (number <= 0) return words;
            if (words != "")
                words += " ";

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
            return words;
        }

        #endregion
    }
}
