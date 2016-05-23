using Box2DX.Dynamics;

namespace LMD_GameFramewerk_Android.GameFramewerk.BaseGame.Physics
{
	public delegate void EventSolver(InfoBody body1, InfoBody body2);

	public class Solver : ContactListener
	{
		public event EventSolver onAdd;
		public event EventSolver onPersist;
		public event EventSolver onResult;
		public event EventSolver onRemove;
		private IGame game;

		public Solver(IGame game)
		{
			this.game = game;
		}

		public override void Add(ContactPoint point)
		{
			base.Add(point);

			onAdd?.Invoke((InfoBody)point.Shape1.GetBody().GetUserData(), (InfoBody)point.Shape2.GetBody().GetUserData());
		}

		public override void Persist(ContactPoint point)
		{
			base.Persist(point);

			onPersist?.Invoke((InfoBody)point.Shape1.GetBody().GetUserData(), (InfoBody)point.Shape2.GetBody().GetUserData());
		}

		public override void Result(ContactResult point)
		{
			base.Result(point);

			onResult?.Invoke((InfoBody)point.Shape1.GetBody().GetUserData(), (InfoBody)point.Shape2.GetBody().GetUserData());
		}

		public override void Remove(ContactPoint point)
		{
			base.Remove(point);

			onRemove?.Invoke((InfoBody)point.Shape1.GetBody().GetUserData(), (InfoBody)point.Shape2.GetBody().GetUserData());
		}
	}
}