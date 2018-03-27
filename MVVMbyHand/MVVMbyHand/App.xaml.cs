using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibModel;
using MVVMbyHand.View;
using Xamarin.Forms;

namespace MVVMbyHand
{
	public partial class App : Application
	{
	    public static WordHistoryModel BoModel;

		public App ()
		{
			InitializeComponent();

            BoModel = new WordHistoryModel();
			MainPage = new BaseTabPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
