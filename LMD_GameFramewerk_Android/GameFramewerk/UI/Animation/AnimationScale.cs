using System.Drawing;

namespace LMD_GameFramewerk_Android.GameFramewerk.UI.Animation
{
	/// <summary>
	/// Анимация мастштабирования
	/// </summary>
	public class AnimationScale : IAnimation
	{
		private IAnimationEvent animationEvent;
		private float x_begin;
		private float y_begin;
		private float x_end;
		private float y_end;
		private float x_duration;
		private float y_duration;
		private float x_currentStep;
		private float y_currentStep;
		private BaseButton elementUi;
		private bool Enable;
		private bool Back;
		private bool _Back;
		private PointF Buffer_duration;

		public AnimationScale()
		{
			Enable = false;
			Back = true;
			_Back = false;
		}

		/// <summary>
		/// Инициализирует анимацию
		/// </summary>
		/// <param name="x_begin">Начальная позиция width</param>
		/// <param name="y_begin">Начальная позиция height</param>
		/// <param name="x_end">Конечная позиция width</param>
		/// <param name="y_end">Конечная позиция height</param>
		/// <param name="x_duration">Скорость по координате X</param>
		/// <param name="y_duration">Скорость по координате Y</param>
		/// <param name="elementUi">UI элемент</param>
		/// <param name="Back">Нужно ли возвражаться к прежней модели</param>
		public void Initialize(float x_begin, float y_begin, float x_end, float y_end,
			float x_duration, float y_duration, BaseButton elementUi, bool Back = true)
		{
			this.x_begin = x_begin;
			this.y_begin = y_begin;
			this.x_end = x_end;
			this.y_end = y_end;
			this.x_duration = x_duration;
			this.y_duration = y_duration;
			this.elementUi = elementUi;
			this.Back = Back;
			this._Back = Back;
			this.Buffer_duration = new PointF(x_duration, y_duration);

			x_currentStep = x_begin;
			y_currentStep = y_begin;
		}

		public void Start()
		{
			Enable = true;

			animationEvent?.OnStart(this);
		}

		public void Stop()
		{
			Enable = false;

			x_currentStep = x_begin;
			y_currentStep = y_begin;
			elementUi.SetWidth(x_begin);
			elementUi.SetHeight(y_begin);
			_Back = Back;
			x_duration = Buffer_duration.X;
			y_duration = Buffer_duration.Y;

			animationEvent?.OnStop(this);
		}

		public void Step(float dt)
		{
			if (Enable)
			{
				if ((x_begin < x_end || y_begin < y_end) && (Buffer_duration.X > 0 && Buffer_duration.Y > 0))
				{
					if (x_currentStep < x_end)
					{
						x_currentStep += x_duration;
						y_currentStep += y_duration;

						if (!_Back)
						{
							if (x_currentStep < x_begin)
								Stop();
							if (y_currentStep < y_begin)
								Stop();
						}
					}
					else
					{
						if (Back && _Back)
						{
							x_duration = -1;
							x_currentStep += x_duration;
							y_duration = -1;
							y_currentStep += y_duration;

							_Back = false;
						}
					}

					elementUi.SetWidth(x_currentStep);
					elementUi.SetHeight(y_currentStep);
				}
				else
				{
					if (x_currentStep > x_end)
					{
						x_currentStep -= x_duration;
						y_currentStep -= y_duration;

						if (!_Back)
						{
							if (x_currentStep > x_begin)
								Stop();
							if (y_currentStep > y_begin)
								Stop();
						}
					}
					else
					{
						if (Back && _Back)
						{
							x_duration = -1;
							x_currentStep -= x_duration;
							y_duration = -1;
							y_currentStep -= y_duration;

							_Back = false;
						}
					}

					elementUi.SetWidth(x_currentStep);
					elementUi.SetHeight(y_currentStep);
				}
			}
		}

		public bool IsEnable()
		{
			return Enable;
		}

		public BaseUI GetElement()
		{
			return elementUi;
		}

		public void SetElement(BaseButton element)
		{
			elementUi = element;
		}

		public void SetEventAnimation(IAnimationEvent animationEvent)
		{
			this.animationEvent = animationEvent;
		}
	}
}