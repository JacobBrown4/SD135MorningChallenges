using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoopsAndConditionals
{
    [TestClass]
    public class Super
    {
        [TestMethod]
        public void Supercal()
        {
            string challengeWord = "Supercalifragilisticexpialidocious";
            int letterCount = 0;
            foreach (char letter in challengeWord)
            {
                if (letter == 'i' || letter == 'l')
                {
                    Console.WriteLine(letter);
                }
                else
                {
                    Console.WriteLine("Not an i");
                }
                letterCount++;
            }
            Console.WriteLine(letterCount);
        }
    }
}
