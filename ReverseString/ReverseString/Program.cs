using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int sum = 0;
            const int _max = 10000000;
            ReverseString rev = new ReverseString();


            var s1 = Stopwatch.StartNew();

            for (int i = 0; i < _max; i++)
            {
                sum += rev.GetReverseString("programmingisfun").Length;
            }
            s1.Stop();
            var s2 = Stopwatch.StartNew();

            for (int i = 0; i < _max; i++)
            {
                sum += rev.GetReverseStringUsingArray("programmingisfun").Length;
            }
            s2.Stop();
            var s3 = Stopwatch.StartNew();

            for (int i = 0; i < _max; i++)
            {
                sum += rev.GetReverseStringDirect("programmingisfun").Length;
            }
            s3.Stop();

            Console.WriteLine(s1.Elapsed.TotalMilliseconds);
            Console.WriteLine(s2.Elapsed.TotalMilliseconds);
            Console.WriteLine(s3.Elapsed.TotalMilliseconds);

            Console.ReadKey();
        }
    }
    public class ReverseString
    {
        /// <summary>
        /// Method to reverse string using string.
        /// </summary>
        /// <param name="str">Input param.</param>
        /// <returns>Reversed string</returns>
        public string GetReverseString(string str)
        {

            string rev = string.Empty;
            var length = str.Length-1;
            for (int i=length ; i >=0;i--)
            {
                rev += str[i];
                //It takes longer to append in a string . 
                //So never ever use it.9506 ms.
            }
            return rev;
        }

        /// <summary>
        /// Method to reverse string using ToCharArray and Reverse method.
        /// </summary>
        /// <param name="str">Input param.</param>
        /// <returns>Reversed string</returns>
        public string GetReverseStringUsingArray(string str)
        {
            char[] rev = str.ToCharArray();
            Array.Reverse(rev);
            return new string(rev); //1499 ms.
        }

        /// <summary>
        /// Method to reverse string using Iteration and Char Array.
        /// </summary>
        /// <param name="str">Input param.</param>
        /// <returns>Reversed string</returns>
        public string GetReverseStringDirect(string str)
        {
            char[] rev = new char[str.Length];
            int forward = 0;
            for(int i=str.Length-1;i>=0;i--)
            {
                rev[forward] = str[i];
            }

            return new string(rev);//1437 ms 
            //Best method to use.as no TocharArray() or Reverse() methods are being used.
        }
    }
}
