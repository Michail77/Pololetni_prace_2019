using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MediaManager;
using MediaManager.Forms;
using System.Threading.Tasks;

namespace TestApp.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _SongName { get; set; }
        public string SongName
        {
            get { return _SongName; }
            set { if (_SongName != value) { _SongName = value; if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs("SongName")); } } }
        }
        public string _ImageName { get; set; }
        public string ImageName
        {
            get { return _ImageName; }
            set { if (_ImageName != value) { _ImageName = value; if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs("ImageName")); } } }
        }
        public Command DomuClick { get; }
        public Command PlaylistyClick { get; }
        public Command ButtonClick { get; }
        public string ButtonText { get; set; }
        public MainPage sender;
        public MainWindowViewModel(MainPage sender)
        {
            SongName = "Eminem - Killshot"; 
            //ButtonText = ("pause.png"); //Text="{Binding ButtonText}"
            ImageName = "play1.png";
            this.sender = sender;
            
            DomuClick = new Command(Domu);
            PlaylistyClick = new Command(Playlisty);
            ButtonClick = new Command(Button);
            CrossMediaManager.Current.Init();
            CrossMediaManager.Current.Play("/storage/sdcard0/download/Killshot.mp3");
            
        }

        public void Domu()
        {
            //
        }
        public void Playlisty()
        {
            sender.ChangeView(new View.Playlisty(sender));
        }
        public void Button()
        {
            CrossMediaManager.Current.PlayPause();
            if (ImageName == "play1.png")
            {
                ImageName = "pause1.png";
            }
            else if (ImageName == "pause1.png")
            {
                ImageName = "play1.png";
            }
            
        }
    }
}
