using Android.Graphics;

namespace LMD_GameFramewerk_Android.GameFramewerk.BaseGame
{
	public class GGraphics : IGraphics
	{
		private Canvas graphics;

		public void SetGraphics(Canvas g)
		{
			graphics = g;
		}

		public Canvas GetGraphics()
		{
			return graphics;
		}
	}
}