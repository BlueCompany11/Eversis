using System;
using System.ComponentModel;
using System.Text;
using Eversis.Helpers;

namespace Eversis.Models
{
	public class Person : ViewModelHelper
	{
		private string id;
		public string Id
		{
			get => id;
			set => SetField(ref id, value);
		}
		private string name;
		public string Name
		{
			get => name;
			set => SetField(ref name, value);
		}
		private string surename;
		public string Surename
		{
			get => surename;
			set => SetField(ref surename, value);
		}
		private string email;
		public string Email
		{
			get => email;
			set => SetField(ref email, value);
		}
		private string phone;
		public string Phone
		{
			get => phone;
			set => SetField(ref phone, value);
		}
	}
}
