using LMD_GameFramewerk_Android.GameFramewerk.BaseGame;

namespace LMD_GameFramewerk_Android.GameFramewerk
{
	public interface ISystemParticles
	{
		/// <summary>
		/// Добавляет новые частицы
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		/// <param name="parameterses">Параметры частицы</param>
		void Add(float x, float y, GSystemParticles.ParticleParameters[] parameterses);
		/// <summary>
		/// Отрисовывает и обновляет частицы
		/// </summary>
		/// <param name="dt">Дельта времени</param>
		void DrawAndStep(float dt);
		/// <summary>
		/// Очищает частицы
		/// </summary>
		void Dispose();
	}
}