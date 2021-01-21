using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoosterTest
{
    /// <summary>
    /// interface
    /// </summary>
    public interface ILargestSmallest
    {
        string LargestFiveWords(string[] source);
        string SmallestFiveWords(string[] source);
    }
    public class LargestSmallest : ILargestSmallest
    {
        /// <summary>
        /// LargestFiveWords
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string LargestFiveWords(string[] source)
        {
            try 
            { 
            StringBuilder largestFiveWords = new StringBuilder();            
            IEnumerable<string> words = source
                                        .OrderByDescending(x=>x.ToString().Length)
                                        .ThenByDescending(x => x.ToString()).Take(5);
            foreach (string word in words)
            {
                largestFiveWords.Append(word + ",");
            }
            return largestFiveWords.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }
        /// <summary>
        ///SmallestFiveWords
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string SmallestFiveWords(string[] source)
        {
            try { 
            StringBuilder smallestFiveWords = new StringBuilder();
           IEnumerable<string> words = source
                                        .OrderBy(x => x.ToString().Length)
                                        .ThenBy(x => x.ToString()).Take(5);
            foreach (string word in words)
            {
                smallestFiveWords.Append(word + ",");
            }
            return smallestFiveWords.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }
        

}
}
