using CsvUtilities.Writer;
using System;
using System.Collections.Generic;
using CsvUtilities.Reader;

namespace CSVSerializer_Tester
{
    class Program
    {
        static void Main(string[] args)
        {

            CsvReader reader = new CsvReader(true);
            reader.ReadCsv2();
            /*CsvWriter<TestObject> writer = new CsvWriter<TestObject>(new CsvWriterConfig(CsvStrictness.Loose));
            List<TestObject> testList = new List<TestObject>();

            TestObject.AddProperty("Age", typeof(int));

            for (int i = 0; i < 5; i++)
            {
                TestObject test = new TestObject()
                {
                    Calls = 90,
                    Name = "Fredrick",
                    Special = "This, is why we can't have nice things.\n\nAnother paragraph here. \n\nAnd here, with lots, of commas, and I'm quoting you: \"This is what you, said\" with extra quotes:\"\",\"",
                    Times = new List<int>() { 1, 2, 3, 4 },
                };
                test.SetPropertyValue("Age", 99999);
                testList.Add(test);
            }*/

            //string testString = "Test Escape of \"extra\"\" quotes";
            //string testString = "012\"3\",\"456789";
            //int index = testString.IndexOf("234");
            //testString = testString.Insert(index, "here");
            //string outputString = EscapeCharacter(testString, "\"");

            //string text = System.IO.File.ReadAllText(@"C:\Users\Douglasg14b\Documents\Visual Studio 2015\Projects\CSVSerializer Tester\test.csv");

            //writer.WriteCSV(@"C:\Users\Douglasg14b\Documents\Visual Studio 2015\Projects\CSVSerializer Tester\test.csv", testList);

            /*var watch = new System.Diagnostics.Stopwatch();
            long total = 0;
            int interations = 100;
            for (var i = 0; i < interations; i++)
            {
                watch.Start();
                string rows = writer.GetCSVString(testList);
                watch.Stop();
                long ms = watch.ElapsedMilliseconds;
                total += ms;
                Console.WriteLine(ms);
                watch.Reset();
            }
            watch.Stop();
            float average = total / interations;
            Console.WriteLine("Average Time: " + average);*/
            Console.ReadLine();
        }

        private static string EscapeCharacter(string input, string character)
        {
            if (!input.Contains(character))
            {
                return input;
            }

            string output = input;
            int i = 0;
            while ((i = output.IndexOf(character, i)) != -1)
            {
                int index2 = output.IndexOf(character, i + character.Length);
                if(index2 != -1)
                {
                    output = output.Insert(index2, "\"");
                    output = output.Insert(i, "\"");
                    i = index2 + character.Length + 2;
                }
                else
                {
                    output = output.Insert(i + character.Length, "\"");
                    output = output.Insert(i, "\"");
                    i += character.Length + 4;
                }                           
                if (i - 1 >= output.Length)
                {
                    break;
                }
            }

            return output;
        }
    }

    public class TestObject : CustomTypeHelper<TestObject>
    {
        public int Calls { get; set; }
        public string Name { get; set; }
        public string Special { get; set; }
        public List<int> Times { get; set; }
        public List<string> TestEmptyCollection { get; set; }
    }
}
