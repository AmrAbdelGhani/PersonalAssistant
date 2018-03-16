using System;
using System.Text.RegularExpressions;
namespace IntentRecognition
{
    class ConverterHandler
    {
        public static string ToHexaConversion(string num)
        {
            int x = 0; string hexaval = "";          
            x = Convert.ToInt32(num);
            hexaval = x.ToString("X");
            hexaval = Regex.Replace(hexaval, ".{1}", "$0 ");

            Console.Write(hexaval);
            return hexaval;
        }
        public static string ToDecimalConversion(string num)
        {
            int res = int.Parse(num, System.Globalization.NumberStyles.HexNumber);
            return res.ToString();
        }
    }
}
