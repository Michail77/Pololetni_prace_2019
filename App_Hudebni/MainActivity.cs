using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Views.View;
using Android.Views;
using System;
using Android.Media;
using System.Timers;

namespace App_Hudebni
{
    [Activity(Label = "App_hudebni", Theme = "@style/AppTheme", MainLauncher = true, Icon ="@drawable/Icon")] //Nastavíme ikonku na mobilu, ikona je uložena ve složce drawable  
    public class MainActivity : AppCompatActivity, IOnClickListener
    {
        //Vytvorime promenné se kterýma budeme nasledne pracovat

        public SeekBar Posuvnik;
        public ImageButton BTN_Spustit_Zastavit;
        public TextView Cas, Nazev;
        public MediaPlayer player;

        public int DelkaHudby, RealnyCas;

        protected override void OnCreate(Bundle savedInstanceState) 
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Najdeme si objekty pomocí jejich ID (objekty které jsou v Layoutu např. tlacitka, view apod ....)
            BTN_Spustit_Zastavit = FindViewById<ImageButton>(Resource.Id.BTN_Spustit_Zastavit);
            BTN_Spustit_Zastavit.SetOnClickListener(this); //Spuštění zpětného volání
            //BTN_Spustit_Zastavit.Click += delegate
            //{
            //    ImageView imageView = FindViewById<ImageView>(Resource.Id.AlbumId);
            //    imageView.SetImageResource(Resource.Drawable.Album);
            //};
            player = new MediaPlayer();

        }

        public void OnClick(View v) //Co se stane po kliknutí ve view, v našem případě se přehraje hudba (mp3 soubor)
        {
            if(v.Id == Resource.Id.BTN_Spustit_Zastavit)
            {
                new SpustitHudbu(this).Execute("https://youtu.be/FxQTY-W6GIo"); //Přímý odkaz na hudbu která se spustí po stisknutí buttonu
            }
        }
    }

    internal class SpustitHudbu : AsyncTask<string, string, string> //Aby přehrávání hudby mohlo běžet v pozadí, aby se hudba přehravala a zroven ukazovala posuvnik a cas
    {
        private MainActivity mainActivity;

        public SpustitHudbu(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }

        protected override string RunInBackground(params string[] @params)
        {
            try
            {
                mainActivity.player.SetDataSource(@params[0]); //Nastavi zdroj dat pro prehrani
                mainActivity.player.Prepare(); //Připravi prehravac na prehravani
            }
            catch (Exception e)
            {

            }
            return "";
        }

        protected override void OnPostExecute(string result) //Vykoname asynchronní task
        {
            mainActivity.DelkaHudby = mainActivity.RealnyCas = mainActivity.player.Duration; //Zobrazime delku hudby jako zbyvajicí čas
            if (!mainActivity.player.IsPlaying) //Pokud se hudba neprehrava
            {
                mainActivity.player.Start(); //prehrajeme ji 
                mainActivity.BTN_Spustit_Zastavit.SetImageResource(Resource.Drawable.Pause); //Zmenime obrazek buttonu na pauzu
            }
            else
            {
                mainActivity.player.Pause(); //pauzneme ji 
                mainActivity.BTN_Spustit_Zastavit.SetImageResource(Resource.Drawable.Play_2); //Zmenime obrazek buttonu na spusteni
            }

            PosouvaniPosuvniku();
        }

        private void PosouvaniPosuvniku()
        {
            mainActivity.Posuvnik.Max = mainActivity.player.Duration;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 10;
            timer.Elapsed += PozicePosuvniku;
            timer.Enabled = true;
            mainActivity.Cas.Text = mainActivity.player.Duration.ToString();
        }

        private void PozicePosuvniku(object sender, System.Timers.ElapsedEventArgs e)
        {
            mainActivity.Posuvnik.Progress = mainActivity.player.CurrentPosition;
        }

        //internal void Execute(string v)
        //{
        //    throw new Exception("Nejde");
        //}
        
        
    }
}