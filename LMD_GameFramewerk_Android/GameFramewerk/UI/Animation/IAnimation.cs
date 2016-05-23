namespace LMD_GameFramewerk_Android.GameFramewerk.UI.Animation
{
	public interface IAnimation
	{
		/// <summary>
		/// Запускает анимацию
		/// </summary>
		void Start();
		/// <summary>
		/// Останавливает анимацию
		/// </summary>
		void Stop();
		/// <summary>
		/// Обновляет анимацию
		/// </summary>
		/// <param name="dt"></param>
		void Step(float dt);
		/// <summary>
		/// Возвращает значение запущена ли анимация
		/// </summary>
		/// <returns></returns>
		bool IsEnable();
		/// <summary>
		/// Возвращает анимационный объект
		/// </summary>
		/// <returns></returns>
		BaseUI GetElement();
		/// <summary>
		/// Устанваливает анимационный объект
		/// </summary>
		/// <param name="element">UI элемент</param>
		void SetElement(BaseButton element);
		/// <summary>
		/// Навешивает на анимацию обратную реакцию, к владельцу AnimationEvent
		/// </summary>
		/// <param name="animationEvent"></param>
		void SetEventAnimation(IAnimationEvent animationEvent);
	}
}