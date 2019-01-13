using System;
using System.Text;

namespace WordTransProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString, resultString, resultString2;
            string unicodeString = "This string contains the unicode character Pi (Π)";

            string inputLine;

            Console.Write("Please key in the String: ");
            inputLine = Console.ReadLine();

            if (string.IsNullOrEmpty(inputLine))
            {
                inputLine = unicodeString;
            }
          

            //document's sample
            MSSampleFunc(inputLine);

            //using "(int)", char to int
            Console.WriteLine("====Convert by Int====");

            testString = inputLine;
            ConvertStringToAsciiString(testString, out resultString);

            //using "Encoding.ASCII"
            Console.WriteLine("====Convert by Encoding====");
            resultString2 = ConvertStringToAsciiStringByEncoding(testString);

            Console.WriteLine($"result1: {resultString}, result2: {resultString2}, are thay equal? {(resultString == resultString2)}");

        }

        private static string ConvertStringToAsciiStringByEncoding(string testString)
        {
            string reslutString = "";
            byte[] asciiBytes = Encoding.ASCII.GetBytes(testString);

            Console.WriteLine($"Original word: {testString}");

            foreach (var item in asciiBytes)
            {
                reslutString += item;
                Console.WriteLine($"World: {item}, ASCII: {(item)}, string: {reslutString}");
            }

            return reslutString;
        }

        private static void ConvertStringToAsciiString(string testString, out string reslutString)
        {
            reslutString = "";
            int asciiInt = 0;
            foreach (var item in testString)
            {
                asciiInt = (int)item;
                reslutString += asciiInt;
                Console.WriteLine($"World: {item}, ASCII: {(asciiInt)}, string: {reslutString}");
            }
        }

        private static void MSSampleFunc(string unicodeString)
        {
            // Create two different encodings.
            Encoding ascii = Encoding.ASCII;
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(unicodeString);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string asciiString = new string(asciiChars);

            // Display the strings created before and after the conversion.
            Console.WriteLine("Original string: {0}", unicodeString);
            Console.WriteLine("Ascii converted string: {0}", asciiString);
        }
    }
}
