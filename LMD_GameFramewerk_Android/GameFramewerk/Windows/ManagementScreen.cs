namespace LMD_GameFramewerk_Android.GameFramewerk.Windows
{
	public class ManagementScreen
	{
		private IGame game;
		private Screen currentScreen;

		public ManagementScreen(IGame game)
		{
			this.game = game;
		}

		/// <summary>
		/// Обновляет активный экран
		/// </summary>
		/// <param name="dt">Дельта времени</param>
		public void Step(float dt)
		{
			currentScreen.Step(dt);
		}

		/// <summary>
		/// Перерисовывает активный экран
		/// </summary>
		public void Draw()
		{
			currentScreen.Draw();
		}

		/// <summary>
		/// Устанавливает активный экран
		/// </summary>
		/// <param name="screen">Объект экрана который будет обрабатываться</param>
		public void SetCurrentScreen(Screen screen)
		{
			if (currentScreen != null)
			{
				// Ставим активный экран на паузу
				currentScreen.Pause();
				// Освобождаем ресурсы активного экрана
				currentScreen.Dispose();
			}

			// Загружаем в память новый экран
			screen.Resume();
			// Обновляем новый экран с дельтой времени 0
			screen.Step(0);
			// Устанавливаем новый экран - текущим
			currentScreen = screen;
		}

		/// <summary>
		/// Возвращает текущий экран
		/// </summary>
		/// <returns></returns>
		public Screen GetCurrentScreen()
		{
			return currentScreen;
		}
	}
}