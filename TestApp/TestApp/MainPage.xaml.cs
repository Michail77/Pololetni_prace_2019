using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MediaManager;
namespace TestApp
{
    public partial class MainPage : ContentPage
    {
        MainPage sender;
        public MainPage(MainPage sender = null)
        {
            InitializeComponent();

            this.sender = sender;
            if (this.sender == null) { this.sender = this; } //Vytvoreni sendera, nastaveni na null

            CrossMediaManager.Current.Init();

            
            BindingContext = new ViewModel.MainWindowViewModel(this);
        }
        public void ChangeView(Page view)
        {
            Navigation.PushModalAsync(view); //Prepinani view
        }
        public void RemoveView()
        {
            Navigation.PopModalAsync();
        }
    }
}
