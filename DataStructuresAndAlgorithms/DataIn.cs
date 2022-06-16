using System.Collections.Generic;
using System.IO;

namespace DataStructuresAndAlgorithms
{
    internal partial class Program
    {
        public class DataIn
        {
            public static IEnumerable<int> ReadTestIntegers(string filePath)
            {
                using TextReader reader = File.OpenText(filePath);
                string lastLine;

                while ((lastLine = reader.ReadLine()) != null)
                {
                    yield return int.Parse(lastLine);
                }
            }

        }
    }
}
