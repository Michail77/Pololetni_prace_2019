using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Playlisty : ContentPage
	{
        public TestApp.MainPage sender;
		public Playlisty(TestApp.MainPage sender)
		{
			InitializeComponent ();
            this.sender = sender;
            BindingContext = new ViewModel.PlaylistyViewModel(sender); //Nabindujeme viewmodel k view
        }
	}
}