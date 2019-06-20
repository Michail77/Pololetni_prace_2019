using MediaManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TestApp.ViewModel
{
    class PlaylistyViewModel : INotifyPropertyChanged
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
        public Command PlayClick { get; }
        public Command PlayClick2 { get; }
        public string ButtonText { get; }
        public string ButtonText1 { get; }
        public string[] playlist { get; }
        public string[] playlist2 { get; }

        public MainPage sender;

        public PlaylistyViewModel(MainPage sender)
        {
            this.sender = sender;
            DomuClick = new Command(Domu);
            PlaylistyClick = new Command(Playlisty);
            ButtonClick = new Command(Button);
            PlayClick = new Command(Play);
            PlayClick2 = new Command(Play2);
            ButtonText = "Eminem - Kamikaze 2019";
            ButtonText1 = "Linkin Park";
            ImageName = "play1.png";
            SongName = "";

            //Vytvoreni playlistu
            playlist = new string[3];
            playlist[0] = "/storage/sdcard0/download/Killshot2.mp3";
            playlist[1] = "/storage/sdcard0/download/Kamikaze.mp3";
            playlist[2] = "/storage/sdcard0/download/Venom.mp3";

            playlist2 = new string[3];
            playlist2[0] = "/storage/sdcard0/download/Numb.mp3";
            playlist2[1] = "/storage/sdcard0/download/In The End.mp3";
            playlist2[2] = "/storage/sdcard0/download/Breaking The Habit.mp3";
        }
        public void Play()
        {
            //MediaManager.CrossMediaManager.Current.Play(playlist);
            sender.ChangeView(new View.Playlist(sender, playlist)); //Otevreme playlist kde jsou songy
        }
        public void Play2()
        {
            //MediaManager.CrossMediaManager.Current.Play(playlist);
            sender.ChangeView(new View.Playlist(sender, playlist2));
        }
        public void Button()
        {
            CrossMediaManager.Current.PlayPause();
            if (ImageName == "play1.png")
            {
                ImageName = "pause1.png";
            }
            else
            {
                ImageName = "play1.png";
            }
        }
        public void Domu()
        {
            sender.RemoveView();
        }
        public void Playlisty()
        {
            
        }
    }
}
