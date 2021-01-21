using DevTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace BoosterTest
{
    class Program
    {
      
        /// <summary>
        /// Program starts here
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                // using thread to avoid waiting or program stuck to read data from stream
                Thread StreamThread = new Thread(StreamRead);
                StreamThread.Start();
                Console.WriteLine("Stream Processing started.....Takes some time as we are reading 100000 kb from stream");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                
            }
        }
        /// <summary>
        /// This function will help to read data and process
        /// </summary>
        private static void StreamRead()
        {
            try {            
            int requiredTotalKB = 100000;
            LorumIpsumStream lorumIpsumStream = new LorumIpsumStream(requiredTotalKB);
            StreamReader streamReader = new StreamReader(lorumIpsumStream, Encoding.Unicode);
            string line = streamReader.ReadLine();//Reading line by line

            //Continue to read until you reach end of file
            while (line != null)
            {
                line = line.Replace("\0", "").ToLower();
                //Removing unwanted characters
                string[] source = line.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                //Getting distinct array of words
                string[] distinctSource = source.Distinct().ToArray();
                //write the line to console window
                //Console.WriteLine(line);
                   
                    //Getting total no of characters and words
                    ITotalNumber iTotalNumber = new TotalNumber();
                    int totalNumberOFCharacters = iTotalNumber.NoOfCharacters(line);
                    int totalNumberOFWords = iTotalNumber.NoOfWords(source);
                    Console.WriteLine("Total Number of Characters: " + totalNumberOFCharacters);
                    Console.WriteLine("Total Number of Words: " + totalNumberOFWords);

                    //Getting largest and smallest five words
                    ILargestSmallest iLargestSmallest = new LargestSmallest();
                    string largestFiveWords = iLargestSmallest.LargestFiveWords(distinctSource);
                    Console.WriteLine("Largest Five Words: " + largestFiveWords);

                    string smallestFiveWords = iLargestSmallest.SmallestFiveWords(distinctSource);
                    Console.WriteLine("Smallest Five Words: " + smallestFiveWords);

                    //Getting frequently used 10 words
                    IFrequentWords iFrequentWords = new FrequentWords();
                    string tenMostFrequentWords = iFrequentWords.MostFrequentWords(source);
                    Console.WriteLine("Most Frequent Ten Words: " + tenMostFrequentWords);

                    //Getting all characters and its frequency
                    IAllCharacters iAllCharacters = new AllCharacters();
                    string allCharactersWithCount = iAllCharacters.AllCharactersWithCount(line);
                    Console.WriteLine("All Characters with occurence: " + allCharactersWithCount);

                //Read the next line
                line = streamReader.ReadLine();
                    Console.WriteLine("Reading Next Line completed");
                }
                Console.WriteLine("Process Completed");
                //close the file
                lorumIpsumStream.Close();
            Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
           
        }
    }
}