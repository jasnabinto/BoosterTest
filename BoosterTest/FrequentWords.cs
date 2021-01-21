using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoosterTest
{
    public interface IFrequentWords
    {
        /// <summary>
        /// MostFrequentWords
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        string MostFrequentWords(string[] source);
    }
    /// <summary>
    /// Class for getting frequent counts
    /// </summary>
    public class FrequentWords : IFrequentWords
    {
        /// <summary>
        /// MostFrequentWords
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string MostFrequentWords(string[] source)
        {
            try { 
            StringBuilder TenMostFrequentWords = new StringBuilder();
            var words = source
                .GroupBy(x => x)
                .Select(x => new { Word = x.Key, Count = x.Count() })//getting count word wise from source consists of all words
                .OrderByDescending(x => x.Count)
                .Take(10)
                .ToDictionary(x => x.Word, x => x.Count);

             foreach (var word in words)
            {
                TenMostFrequentWords.Append(word.Key + "- " + word.Value + ",");
            }
            return TenMostFrequentWords.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }
    }
}
