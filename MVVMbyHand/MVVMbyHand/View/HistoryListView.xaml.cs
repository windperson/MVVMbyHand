using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMbyHand.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMbyHand.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryListView : ContentPage
	{
		public HistoryListView ()
		{
			InitializeComponent ();
		    BindingContext = new HistoryListViewModel(App.BoModel);
		}
	}
}