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
	public partial class Playlist : ContentPage
	{
        public TestApp.MainPage sender;
        public Playlist(TestApp.MainPage sender, string[] playlist)
        {
            InitializeComponent();
            this.sender = sender;
            
            BindingContext = new ViewModel.Playlist(sender, playlist, Playlists); //Nabindujeme viewmodel k view
            
        }
    }
}