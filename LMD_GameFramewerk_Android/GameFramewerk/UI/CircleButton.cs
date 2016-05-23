using System;
using LMD_GameFramewerk_Android.GameFramewerk.UI.Animation;

namespace LMD_GameFramewerk_Android.GameFramewerk.UI
{
	public class CircleButton : BaseButton
	{
		public delegate void ButtonEvent(BaseButton e);
		public event ButtonEvent onClick;

		public CircleButton(IGame game) : base(game)
		{
		}

		public override void Step(float dt)
		{
			if (IsVisible)
			{
				image.Step(dt);
				Animation?.Step(dt);
			}
		}

		public override void Draw()
		{
			if (IsVisible)
			{
				image.Draw();
			}
		}

		public override void Dispose()
		{
			image.Dispose();
		}

		public override void SetTouch(float x, float y, TypeTouch type)
		{
			if (IsVisible)
			{
				float distance = 0;
				switch (type)
				{
					case TypeTouch.Down:
						distance = (float)Math.Sqrt(Math.Pow(x - GetX(), 2) + Math.Pow(y - GetY(), 2));

						if (distance < GetWidth() / 2)
						{
							Animation?.Start();
						}
						break;
					case TypeTouch.Move:
						break;
					case TypeTouch.Up:
						if (Animation == null)
							if (onClick != null)
							{
								distance = (float)Math.Sqrt(Math.Pow(x - GetX(), 2) + Math.Pow(y - GetY(), 2));

								if (distance < GetWidth() / 2)
								{
									onClick(this);
								}
							}
						break;
				}
			}
		}

		public void SetRadius(float radius)
		{
			image.SetX(radius * 2);
			image.SetY(radius * 2);
		}

		public float GetRadius()
		{
			return GetWidth();
		}

		public override void OnStart(IAnimation animation)
		{
		}

		public override void OnStop(IAnimation animation)
		{
			onClick?.Invoke(this);
		}
	}
}