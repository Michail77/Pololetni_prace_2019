using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace App_Hudebni
{
    [Activity(Label = "App_hudebni", Theme = "@style/AppTheme", MainLauncher = true, Icon ="@drawable/Icon")] //Nastavíme ikonku na mobilu, ikona je uložena ve složce drawable
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState) 
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
        }
    }
}