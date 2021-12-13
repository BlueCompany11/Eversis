using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eversis.Models;
using Eversis.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Eversis.ViewModels
{
	public class EditPersonViewModel : BindableBase, INavigationAware
	{
		private Person person;
		private readonly IRegionManager regionManager;

		public EditPersonViewModel(IRegionManager regionManager)
		{
			this.regionManager = regionManager;
			SaveCommand = new DelegateCommand(this.Save);
		}
		public DelegateCommand SaveCommand { get; private set; }
		public Person Person
		{
			get { return person; }
			set { SetProperty(ref person, value); }
		}
		void Save()
		{
			var para = new NavigationParameters() {
				{ "person", this.Person }
			};
			this.regionManager.RequestNavigate("ContentRegion", nameof(MainView), para);
		}
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext)
		{

		}

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			Person = navigationContext.Parameters.GetValue<Person>("person");
		}
	}
}
