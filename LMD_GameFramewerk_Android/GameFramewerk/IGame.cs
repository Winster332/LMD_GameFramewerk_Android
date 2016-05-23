namespace LMD_GameFramewerk_Android.GameFramewerk
{
	public interface IGame
	{
		/// <summary>
		/// Возвращает страртовый экран
		/// </summary>
		/// <returns></returns>
		Screen GetStartScreen();
		/// <summary>
		/// Возвращает страртовый экран
		/// </summary>
		/// <returns></returns>
		Screen GetCurrentScreen();
		/// <summary>
		/// Устанавливает активный экран
		/// </summary>
		/// <param name="screen">Экран который будет установлен</param>
		void SetScreen(Screen screen);
		/// <summary>
		/// Возвращает указатель на объект класса ввода
		/// </summary>
		/// <returns></returns>
		IInput GetInput();
		/// <summary>
		/// Возвращает указатель на объект класса графики
		/// </summary>
		/// <returns></returns>
		IGraphics GetGraphics();
		/// <summary>
		/// Возвращает указатель на объект класса отвечающий за I/O данных файловой системы
		/// </summary>
		/// <returns></returns>
		IFileIO GetFileIO();
		/// <summary>
		/// Возвращает указатель на объект класса по обработки физический процессов
		/// </summary>
		/// <returns></returns>
		IPhysics GetPhysics();
		/// <summary>
		/// Возвращает указатель на объект класса отвечающего за обработку звуковых эффектов
		/// </summary>
		/// <returns></returns>
		IAudio GetAudio();
		/// <summary>
		/// Возвращает указатель на объект отвечающий за положение элементов на экране
		/// </summary>
		/// <returns></returns>
		ICamera GetCamera();
		/// <summary>
		/// Возвращает указатель на объект отвечающий за добавление частиц на экран
		/// </summary>
		/// <returns></returns>
		ISystemParticles GetSystemParticles();
		/// <summary>
		/// Возвращает ширину окна
		/// </summary>
		/// <returns></returns>
		float GetWindowWidth();
		/// <summary>
		/// Возвращает высоту окна
		/// </summary>
		/// <returns></returns>
		float GetWindowHeight();
	}
}