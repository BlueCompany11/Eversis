using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Eversis.Models;

namespace Eversis.BusinessLogic
{
	public class PersonLoader
	{
		public List<Person> LoadPeople(string filePath)
		{
			var ret = new List<Person>();
			var config = new CsvConfiguration(CultureInfo.InvariantCulture)
			{
				PrepareHeaderForMatch = args => args.Header.ToLower(),
			};
			using (var reader = new StreamReader(filePath))
			using (var csv = new CsvReader(reader, config))
			{
				ret = csv.GetRecords<Person>().ToList();
			}
			return ret;
		}
	}
}
