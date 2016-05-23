namespace LMD_GameFramewerk_Android.GameFramewerk.Windows
{
	public class Intent
	{
		public Screen screenFrom;
		public Screen screenTo;
		public float Min_Pause;
		private Screen screenLoading;
		private IGame game;

		public Intent(IGame game)
		{
			this.game = game;
			Min_Pause = 20;
		}

		public void SetScreenLoading(Screen screenLoading)
		{
			this.screenLoading = screenLoading;
		}

		public void Start()
		{
			if (screenLoading != null)
			{
				screenLoading.SetUserDate(this);
				game.SetScreen(screenLoading);
			}
			else
			{
				game.SetScreen(screenTo);
			}
		}

		public void Stop()
		{
		}
	}
}