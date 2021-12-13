using System;
using System.Collections.Generic;
using System.Text;
using Eversis.DataAccess;
using Eversis.Models;

namespace Eversis.BusinessLogic
{
	public class PersonSaver
	{
		private readonly PeopleContext peopleContext;

		public PersonSaver(PeopleContext peopleContext)
		{
			this.peopleContext = peopleContext;
		}
		public void Save(IEnumerable<Person> people)
		{
			peopleContext.AddRange(people);
			peopleContext.SaveChanges();
		}
	}
}
