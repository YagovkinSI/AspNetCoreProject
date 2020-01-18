using AspNetCoreProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AspNetCoreProject.DAL.Initialisation.Formater
{
    public static class ProvinceFormatter
    {
        private static readonly char delimiter = ';';

        public static IEnumerable<Province> GetDataFrom(Stream sourceStream)
        {
            var provinces = new List<Province>();
            using (var stream = new StreamReader(sourceStream))
            {
                while (stream.Peek() >= 0)
                {
                    var line = stream.ReadLine();
                    var fieldData = line.Split(delimiter);
                    if (fieldData.Length < 6)
                        continue;
                    var success = int.TryParse(fieldData[0], out var id);
                    success &= fieldData[1].Length > 0;
                    success &= int.TryParse(fieldData[2], out var forest);
                    success &= int.TryParse(fieldData[3], out var river);
                    success &= int.TryParse(fieldData[4], out var coast);
                    success &= int.TryParse(fieldData[5], out var swamp);
                    if (!success)
                        continue;
                    var province = new Province
                    {
                        Id = id,
                        Name = fieldData[1],
                        Description = GetDescription(forest > 0, river > 0, coast > 0, swamp > 0)
                    };
                    provinces.Add(province);
                }
            }
            return provinces;
        }

        private static string GetDescription(bool forest, bool river, bool coast, bool swamp)
        {
            var description = "Имеется:"
                    + (river ? " судоходная река," : "")
                    + (coast ? " морское побережье," : "")
                    + " пахотные земли,"
                    + (forest ? " леса," : "")
                    + (swamp ? " болота," : "");
            return description[0..^1] + ".";
        }

        private class CsvProvince
        {

        }
    }
}
