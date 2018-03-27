using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibModel;
using MVVMbyHand.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMbyHand.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputView : ContentPage
    {
        public InputView()
        {
            InitializeComponent();
            BindingContext = new InputViewModel(App.BoModel);
        }
    }
}