using Android.Graphics;

namespace LMD_GameFramewerk_Android.GameFramewerk
{
	public interface IGraphics
	{
		/// <summary>
		/// Устанавливет текущий графикс
		/// </summary>
		/// <param name="g">Графкис указатель которого будет взят</param>
		void SetGraphics(Canvas g);
		/// <summary>
		/// Возвращает на текущий указатель графикса
		/// </summary>
		/// <returns></returns>
		Canvas GetGraphics();
	}
}