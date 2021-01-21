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
    public interface ITotalNumber
    {
        int NoOfCharacters(string line);
        int NoOfWords(string[] source);
    }
    public class TotalNumber : ITotalNumber
    {
        /// <summary>
        /// NoOfCharacters
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public int NoOfCharacters(string line)
        {
            try { 
            int totalNoOfCharacters = 0;
            line = line.Replace(" ", "");//replacing single space with no space
            totalNoOfCharacters = line.Length;
            return totalNoOfCharacters;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return 0;
            }
        }
        /// <summary>
        /// NoOfWords
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public int NoOfWords(string[] source)
        {
            try { 
            int totalNoOfWords = 0;
            totalNoOfWords = source.Length;           
            return totalNoOfWords;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return 0;
            }
        }
    }
}
