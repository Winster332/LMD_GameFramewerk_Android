namespace LMD_GameFramewerk_Android.GameFramewerk.BaseGame
{
	public class GCamera : ICamera
	{
		public float x;
		public float y;

		public GCamera()
		{
			x = 0;
			y = 0;
		}

		public void SetXY(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public void SetX(float value)
		{
			x = value;
		}

		public void SetY(float value)
		{
			y = value;
		}

		public float GetX()
		{
			return x;
		}

		public float GetY()
		{
			return y;
		}
	}
}