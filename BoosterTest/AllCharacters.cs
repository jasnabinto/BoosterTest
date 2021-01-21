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
    public interface IAllCharacters
    {
        /// <summary>
        /// AllCharactersWithCount
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        string AllCharactersWithCount(string line);
    }
    /// <summary>
    /// Class for getting all characters
    /// </summary>
    public class AllCharacters : IAllCharacters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AllCharacters()
        {

        }
        /// <summary>
        /// AllCharactersWithCount
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public string AllCharactersWithCount(string line)
        {
            try { 
            StringBuilder allCharactersWithCount = new StringBuilder();
            var entries = line
                .GroupBy(x => x)
                .Select(x => new { Character = x.Key, Count = x.Count() })//getting count character wise from line
                .OrderByDescending(x => x.Count)
                .ToDictionary(x => x.Character, x => x.Count);

            foreach (var character in entries)
            {
                allCharactersWithCount.Append(character.Key + "- " + character.Value + ",");
            }
            return allCharactersWithCount.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }
    }
}
