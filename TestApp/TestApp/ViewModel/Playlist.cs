using MediaManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestApp.ViewModel
{
	public class Playlist : INotifyPropertyChanged
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
        public ICommand PlayClick { get; } //Command akceptující parametr
        
        //Kdyz zmenim obrazek , zmen ho ve view taky
       
        public string PlaylistName { get; set; }
        public string ButtonText { get; set; }
        
        public MainPage sender;
        string[] playlist;



        public Playlist(MainPage sender, string[] playlist, StackLayout parent) //Vytvoření playlistu, davame mu sendera aby měnil change view, playlist aby vedel jaky vytvorit, parent -- aby vedel kam to vytvorit
        {
            PlaylistName = "Eminem"; //Nazev playlistu
            //ButtonText = ("Play/Pause");
            ImageName = "play1.png"; //Nazev pause imagebuttonu
            this.sender = sender; //Ukladani do likalni promenné
            this.playlist = playlist;

            DomuClick = new Command(Domu);
            PlaylistyClick = new Command(Playlisty);
            ButtonClick = new Command(Button);
            PlayClick = new Command<string>(Play);

            foreach(string s in playlist) //Pro kazdy song v playlistu vytváří button
            {
                CrossMediaManager.Current.Play(s);
                var song = new Button()
                {
                    Text = Name(s),
                    TextColor = Xamarin.Forms.Color.White,
                    BackgroundColor = Color.FromHex("001d4d"),
                    Command = PlayClick,
                    CommandParameter = s //Aby vedel co spustit
                };
                parent.Children.Add(song); //Vykresli button v playlistu
                CrossMediaManager.Current.Stop();
            }

        }
        public string Name(string song) //Uprava nazvu songu (sdcar/download/killshot.mp3 --> killshot )
        {
            string outp= "";
            outp = song.Split('/').Last();
            outp = outp.Replace(".mp3", "");
            return outp;
        }
        public void Domu() //Metoda co vrati na mainpage
        {
            sender.RemoveView();
            sender.RemoveView();
        }
        public void Playlisty()
        {
            //sender.ChangeView(new View.Playlisty(sender));
            sender.RemoveView();
        }
        public void Button()
        {
            CrossMediaManager.Current.PlayPause(); //Spustit/zastavit song
            
            if (ImageName == "play1.png") //Zmena obrazku z pause na play a naopak (nefunguje)
            {
                ImageName = "pause1.png";
            }
            else if (ImageName == "pause1.png")
            {
                ImageName = "play1.png";
            }

        }
        public void Play(string song)
        {
            CrossMediaManager.Current.Play(song);
            SongName = Name(song); //Měl by se zde zobrazit song name (nefunguje)
            ImageName = "pause1.png";

            /*
            for (int i = 0; i < Array.IndexOf(playlist, song); i++)
            {
                CrossMediaManager.Current.PlayNext();
            }*/

        }
    }
}