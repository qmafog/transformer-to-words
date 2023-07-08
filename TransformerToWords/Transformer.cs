using System;
#pragma warning disable

namespace TransformerToWords
{
    /// <summary>
    /// Implements transformer class.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transforms each element of source array into its 'word format'.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of 'word format' of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <example>
        /// new[] { 2.345, -0.0d, 0.0d, 0.1d } => { "Two point three four five", "Minus zero", "Zero", "Zero point one" }.
        /// </example>
        public static string ConvertDigit(char d)
        {
            switch (d)
            {
                case '-':
                    return "minus";
                case '0':
                    return "zero";
                case '1':
                    return "one";
                case '2':
                    return "two";
                case '3':
                    return "three";
                case '4':
                    return "four";
                case '5':
                    return "five";
                case '6':
                    return "six";
                case '7':
                    return "seven";
                case '8':
                    return "eight";
                case '9':
                    return "nine";
                case '.':
                    return "point";
                case 'E':
                    return "E";
                case '+':
                    return "plus";
                default:
                    return string.Empty;
            }
        }

        public static string TransformToWords(double number)
        {
            string strNum = number.ToString();
            string resultString = string.Empty;
            int i = 0;

            if (strNum[0] == '-')
            {
                resultString += ConvertDigit('-') + " ";
                i++;
            }

            if (strNum[0] == '+')
            {
                resultString += ConvertDigit('+') + " ";
                i++;
            }

            if (number == 0)
            {
                resultString += "zero";
                return char.ToUpper(resultString[0]) + resultString.Substring(1);
            }

            if (double.IsNaN(number))
            {
                return "Not a Number";
            }

            if (double.IsPositiveInfinity(number))
            {
                return "Positive Infinity";
            }

            if (double.IsNegativeInfinity(number))
            {
                return "Negative Infinity";
            }

            if (number == double.Epsilon)
            {
                return "Double Epsilon";
            }

            int len = strNum.Length - i;
            while (len > 0)
            {
                resultString += ConvertDigit(strNum[i]) + ' ';
                i++;
                len--;
            }

            resultString = resultString[..^1];
            return char.ToUpper(resultString[0]) + resultString.Substring(1);
        }

        public string[] Transform(double[]? source)
        {
            if (source is null)
            {
                throw new ArgumentNullException("Array cannot be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            int n = source.Length;
            string[] strArr = new string[n];
            for (int i = 0; i < n; i++)
            {
                string str = TransformToWords(source[i]);
                strArr[i] = str;
            }

            return strArr;
        }
    }
}
