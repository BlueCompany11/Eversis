using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eversis.BusinessLogic;
using Eversis.Models;
using Eversis.Views;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Eversis.ViewModels
{
	public class MainViewModel : BindableBase, INavigationAware
	{
		private readonly PersonLoader personLoader;
		private readonly PersonSaver personSaver;
		private BindingList<Person> people;
		private Person selectedPerson;
		private readonly IRegionManager regionManager;

		public MainViewModel(PersonLoader personLoader, PersonSaver personSaver, IRegionManager regionManager)
		{
			LoadCommand = new DelegateCommand(this.LoadFile);
			SaveCommand = new DelegateCommand(async () => await this.SavePeople());
			EditCommand = new DelegateCommand(this.Edit);
			this.personLoader = personLoader;
			this.personSaver = personSaver;
			People = new();
			this.regionManager = regionManager;
		}
		public DelegateCommand LoadCommand { get; private set; }
		public DelegateCommand SaveCommand { get; private set; }
		public DelegateCommand EditCommand { get; private set; }

		public BindingList<Person> People
		{
			get { return people; }
			set { SetProperty(ref people, value); }
		}

		public Person SelectedPerson
		{
			get { return selectedPerson; }
			set { SetProperty(ref selectedPerson, value); }
		}
		private void LoadFile()
		{
			var openFileDialog = new OpenFileDialog
			{
				Filter = "CSV Files (*.csv)|*.csv"
			};
			if (openFileDialog.ShowDialog() == true)
			{
				People.AddRange(personLoader.LoadPeople(openFileDialog.FileName));
			}
		}
		private Task SavePeople()
		{
			return Task.Run(() => personSaver.Save(People));
		}

		private void Edit()
		{
			var para = new NavigationParameters() {
				{ "person", this.SelectedPerson }
			};
			this.regionManager.RequestNavigate("ContentRegion", nameof(EditPersonView), para);
		}

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			SelectedPerson = navigationContext.Parameters.GetValue<Person>("person");
		}

		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext)
		{

		}
	}
}
