using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Browser.Trusted;

namespace Marking_App
{
    [Activity(Theme = "@style/Maui.SplashTheme",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
/*      
 *      Another way of setting the screenorientaion. However, this one only took place after page is loaded. One setup in the ACTIVITY takes
 *      precident over page load, hence forces the page load in the specified orientation.
 *      
 *      protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
        }*/
    }
}