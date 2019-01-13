using System;
using System.Text;

namespace WordTransProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MSSampleFunc();

            Console.WriteLine("====Convert by Int====");
            string testString = "test_123=";
            string reslutString = "";
            int asciiInt = 0;
            foreach (var item in testString)
            {
                asciiInt = (int)item;
                reslutString += asciiInt;
                Console.WriteLine($"World: {item}, ASCII: {(asciiInt)}, string: {reslutString}");
            }

            Console.WriteLine("====Convert by Encoding====");
            string reslutString2 = "";
            Console.WriteLine($"Original word: {testString}");
            byte[] asciiBytes = Encoding.ASCII.GetBytes(testString);
            reslutString2 =  Encoding.ASCII.GetString(asciiBytes);
            Console.WriteLine($"ASCII1: {reslutString2}");

            reslutString2 = "";
            foreach (var item in asciiBytes)
            {
                reslutString2 += item;
                Console.WriteLine($"World: {item}, ASCII: {(item)}, string: {reslutString2}");
            }

            Console.WriteLine($"result1: {reslutString}, result2: {reslutString2}, are thay equal? {(reslutString == reslutString2)}");

        }

        private static void MSSampleFunc()
        {
            string unicodeString = "This string contains the unicode character Pi (\u03a0)";

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
