using Android.Graphics;
using LMD_GameFramewerk_Android.GameFramewerk.UI.Animation;

namespace LMD_GameFramewerk_Android.GameFramewerk.UI
{
	public abstract class BaseButton : BaseUI, IAnimationEvent
	{
		protected Image image;
		protected object Tag;
		protected IAnimation Animation;
		protected bool IsVisible;

		protected BaseButton(IGame game) : base(game)
		{
			image = new Image(game);
			image.SetScaleX(1f);
			image.SetScaleY(1f);
			IsVisible = true;
		}

		public override void SetX(float value)
		{
			image.SetX(value);
		}

		public override void SetY(float value)
		{
			image.SetY(value);
		}

		public override float GetX()
		{
			if (IsCamera)
				return image.GetX() + game.GetCamera().GetX();

			return image.GetX();
		}

		public override float GetY()
		{
			if (IsCamera)
				return image.GetY() + game.GetCamera().GetY();

			return image.GetY();
		}

		public override void SetVelocityX(float value)
		{
			image.SetVelocityX(value);
		}

		public override void SetVelocityY(float value)
		{
			image.SetVelocityY(value);
		}

		public override float GetVelocityX()
		{
			return image.GetVelocityX();
		}

		public override float GetVelocityY()
		{
			return image.GetVelocityX();
		}

		public override void SetAndle(float value)
		{
			image.SetAndle(value);
		}

		public override float GetAngle()
		{
			return image.GetAngle();
		}

		public override void SetAngularVelocity(float value)
		{
			image.SetAngularVelocity(value);
		}

		public override float GetAngularVelocity()
		{
			return image.GetAngularVelocity();
		}

		public Image GetImage()
		{
			return image;
		}

		public void SetImage(Image image)
		{
			this.image = image;
		}

		public void SetWidth(float value)
		{
			image.SetWidth(value);
		}

		public void SetHeight(float value)
		{
			image.SetHeight(value);
		}

		public float GetWidth()
		{
			return image.GetWidth();
		}

		public float GetHeight()
		{
			return image.GetHeight();
		}

		public void SetTag(object tag)
		{
			Tag = tag;
		}

		public object GetTag()
		{
			return Tag;
		}

		public void SetBitmap(Bitmap bitmap)
		{
			image.SetImage(bitmap);
		}

		public override void SetScaleX(float value)
		{
			image.SetScaleX(value);
		}

		public override void SetScaleY(float value)
		{
			image.SetScaleY(value);
		}

		public override float GetScaleX()
		{
			return image.GetScaleX();
		}

		public override float GetScaleY()
		{
			return image.GetScaleY();
		}

		public abstract void SetTouch(float x, float y, TypeTouch type);

		public void SetAnimation(IAnimation animation)
		{
			Animation = animation;
			animation.SetEventAnimation(this);
		}

		public override void SetEnableCamera(bool value)
		{
			IsCamera = value;
		}

		public void SetVisible(bool value)
		{
			IsVisible = value;
		}

		public bool GetVisible()
		{
			return IsVisible;
		}

		public abstract void OnStart(IAnimation animation);

		public abstract void OnStop(IAnimation animation);
	}
}