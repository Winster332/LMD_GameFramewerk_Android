using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using LMD_GameFramewerk_Android.GameFramewerk.BaseGame;

namespace LMD_GameFramewerk_Android
{
	[Activity(Label = "LMD_GameFramewerk_Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			RequestedOrientation = ScreenOrientation.Landscape;
			Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
			RequestWindowFeature(WindowFeatures.NoTitle);
			
			SetContentView(new GGame(this));
		}
	}
}

