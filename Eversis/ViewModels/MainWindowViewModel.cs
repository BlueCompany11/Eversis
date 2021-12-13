using Prism.Mvvm;

namespace Eversis.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private string _title = "Eversis";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public MainWindowViewModel()
		{

		}
	}
}
