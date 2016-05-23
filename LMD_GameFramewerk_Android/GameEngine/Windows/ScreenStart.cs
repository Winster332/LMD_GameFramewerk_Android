using Android.Graphics;
using Android.Views;
using LMD_GameFramewerk_Android.GameFramewerk;
using LMD_GameFramewerk_Android.GameFramewerk.UI;

namespace LMD_GameFramewerk_Android.GameEngine.Windows
{
	public class ScreenStart : Screen
	{
		private float dt;

		public ScreenStart(IGame game) : base(game)
		{
		}

		public override void Step(float dt)
		{
			this.dt = dt;
		}

		public override void Draw()
		{
			Game.GetGraphics().GetGraphics().DrawColor(Color.Argb(255, 50, 50, 50));
			
			DrawElements(dt);
		}

		public override void Resume()
		{
			Image image = new Image(Game);
			image.SetX(Game.GetWindowWidth() / 2);
			image.SetY(Game.GetWindowHeight() / 2);
			image.SetWidth(300);
			image.SetHeight(200);
			image.SetImage(Image.ConvertToBitmap(ResourceGame.text_lmd));
			AddElement(image);
		}

		public override void Pause()
		{
		}

		public override void Dispose()
		{
			RemoveElements();
		}

		public override void OnTouch(MotionEvent eventArgs)
		{
			TouchElements(eventArgs.GetX(), eventArgs.GetY(), TypeTouch.Down);
		}
	}
}