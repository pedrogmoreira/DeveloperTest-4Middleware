using DeveloperTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DeveloperTest.Tools.Csv
{
    public class CsvManager
    {

        private static readonly string PATH = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
        private static readonly Uri DIR = new Uri($"{PATH}\\data");
        private static readonly Uri FILEPATH = new Uri($"{DIR}\\apiData.csv");

        public CsvManager()
        {
            if (!Directory.Exists(DIR.LocalPath))
            {
                Directory.CreateDirectory(DIR.LocalPath);
            }
        }

        public static void WriteToFile(IEnumerable<Test> data)
        {
            File.WriteAllLines(FILEPATH.LocalPath, data.Select(x => $"{x.Id},{x.Name},{x.Status}"));
        }

        public static IEnumerable<Test> ReadFromFile()
        {
            var rawData = File.ReadAllLines(FILEPATH.LocalPath);
            var data = new List<Test>();

            foreach (var line in rawData)
            {
                var dataComponents = line.Split(',');
                data.Add(new Test
                {
                    Id = int.Parse(dataComponents[0]),
                    Name = dataComponents[1],
                    Status = bool.Parse(dataComponents[2])
                });
            }

            return data;
        }
    }
}
