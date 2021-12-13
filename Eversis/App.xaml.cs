using System.Globalization;
using System.Reflection;
using System;
using System.Windows;
using Eversis.BusinessLogic;
using Eversis.ViewModels;
using Eversis.Views;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Eversis.DataAccess;

namespace Eversis
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<PersonLoader>();
			containerRegistry.Register<PersonSaver>();
			containerRegistry.Register<PeopleContext>();
			containerRegistry.RegisterForNavigation<MainView>();
			containerRegistry.RegisterForNavigation<EditPersonView>();
		}
		protected override void OnInitialized()
		{
			var regionManager = this.Container.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion("ContentRegion", typeof(MainView));
			base.OnInitialized();
		}


	}
}
