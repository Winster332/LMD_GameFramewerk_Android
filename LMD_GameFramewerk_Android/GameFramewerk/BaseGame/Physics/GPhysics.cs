using Android.Graphics;
using Box2DX.Collision;
using Box2DX.Common;
using Box2DX.Dynamics;
using LMD_GameFramewerk_Android.GameFramewerk.UI;

namespace LMD_GameFramewerk_Android.GameFramewerk.BaseGame.Physics
{
	public class GPhysics : IPhysics
	{
		private const float metric = 30f;
		private IGame game;
		private World world;
		private Solver solver;

		public GPhysics(IGame game)
		{
			this.game = game;
		}

		public void Initialize(float x, float y, float w, float h, float grav_x, float grav_y, bool doSleep)
		{
			solver = new Solver(game);

			AABB ab = new AABB();
			ab.LowerBound.Set(x, y);
			ab.UpperBound.Set(w, h);

			world = new World(ab, new Vec2(grav_x, grav_y), doSleep);
			world.SetContactListener(solver);
		}

		public void Dispose()
		{
			for (Body list = world.GetBodyList(); list != null; list = list.GetNext())
			{
				world.DestroyBody(list);
			}
			//	world.Dispose();
		}

		public void Step(float dt, int iterat)
		{
			world.Step(1f / 30f, iterat, iterat);
		}

		public void Draw()
		{
			for (Body list = world.GetBodyList(); list != null; list = list.GetNext())
			{
				InfoBody info = (InfoBody)list.GetUserData();

				if (info != null)
				{
					info.image.SetX(list.GetPosition().X * metric);
					info.image.SetY(list.GetPosition().Y * metric);
					info.image.SetAndle(list.GetAngle());

					info.image.Draw();
				}
			}
		}

		public Solver GetSolver()
		{
			return solver;
		}

		#region Rectangle
		public InfoBody AddRect(float x, float y, float w, float h, float angle, float density,
			float friction, float restetution, Bitmap image, object userDate = null)
		{
			Image g_image = new Image(game);
			g_image.SetImage(image);
			g_image.SetWidth(w);
			g_image.SetHeight(h);

			BodyDef bDef = new BodyDef();
			bDef.Position.Set(x / metric, y / metric);
			bDef.Angle = angle;

			PolygonDef pDef = new PolygonDef();
			pDef.Restitution = restetution;
			pDef.Friction = friction;
			pDef.Density = density;
			pDef.SetAsBox(w / metric / 2, h / metric / 2);

			Body body = world.CreateBody(bDef);
			body.CreateShape(pDef);
			body.SetMassFromShapes();

			InfoBody info = new InfoBody();
			info.image = g_image;
			info.body = body;
			info.userDate = userDate;

			body.SetUserData(info);

			return info;
		}

		public InfoBody AddRect(float x, float y, float w, float h, float angle, float density,
			float friction, float restetution, float mass, Image image, object userDate = null)
		{
			BodyDef bDef = new BodyDef();
			bDef.Position.Set(x / metric, y / metric);
			bDef.Angle = angle;

			PolygonDef pDef = new PolygonDef();
			pDef.Restitution = restetution;
			pDef.Friction = friction;
			pDef.Density = density;
			pDef.SetAsBox(w / metric / 2, h / metric / 2);

			Body body = world.CreateBody(bDef);
			body.CreateShape(pDef);
			body.SetMassFromShapes();

			float Inertia = body.GetInertia();
			MassData md = new MassData();
			md.I = Inertia;
			md.Mass = mass;
			body.SetMass(md);

			InfoBody info = new InfoBody();
			info.image = image;
			info.body = body;
			info.userDate = userDate;

			body.SetUserData(info);

			return info;
		}

		public InfoBody AddRect(float x, float y, float w, float h, float angle, float density,
			float friction, float restetution, float mass, Image image, bool IsBullet = true,
			bool IsSensor = false, bool AllowSleep = false, short group_index = 1, object userDate = null)
		{
			BodyDef bDef = new BodyDef();
			bDef.Position.Set(x / metric, y / metric);
			bDef.Angle = angle;
			bDef.AllowSleep = AllowSleep;
			bDef.IsBullet = IsBullet;

			PolygonDef pDef = new PolygonDef();
			pDef.Restitution = restetution;
			pDef.Friction = friction;
			pDef.Density = density;
			pDef.SetAsBox(w / metric / 2, h / metric / 2);
			pDef.Filter.GroupIndex = group_index;
			pDef.IsSensor = IsSensor;

			Body body = world.CreateBody(bDef);
			body.CreateShape(pDef);
			body.SetMassFromShapes();

			float Inertia = body.GetInertia();
			MassData md = new MassData();
			md.I = Inertia;
			md.Mass = mass;
			body.SetMass(md);

			InfoBody info = new InfoBody();
			info.image = image;
			info.body = body;
			info.userDate = userDate;

			body.SetUserData(info);

			return info;
		}
		#endregion
		#region Circle
		public InfoBody AddCircle(float x, float y, float radius, float angle, float density,
			float friction, float restetution, Bitmap image, object userDate = null)
		{
			Image g_image = new Image(game);
			g_image.SetImage(image);
			g_image.SetWidth(radius * 2);
			g_image.SetHeight(radius * 2);

			BodyDef bDef = new BodyDef();
			bDef.Position.Set(x / metric, y / metric);
			bDef.Angle = angle;

			CircleDef pDef = new CircleDef();
			pDef.Restitution = restetution;
			pDef.Friction = friction;
			pDef.Density = density;
			pDef.Radius = radius / metric;

			Body body = world.CreateBody(bDef);
			body.CreateShape(pDef);
			body.SetMassFromShapes();

			InfoBody info = new InfoBody();
			info.image = g_image;
			info.body = body;
			info.userDate = userDate;

			body.SetUserData(info);

			return info;
		}

		public InfoBody AddCircle(float x, float y, float radius, float angle, float density,
			float friction, float restetution, float mass, Image image, object userDate = null)
		{
			BodyDef bDef = new BodyDef();
			bDef.Position.Set(x / metric, y / metric);
			bDef.Angle = angle;

			CircleDef pDef = new CircleDef();
			pDef.Restitution = restetution;
			pDef.Friction = friction;
			pDef.Density = density;
			pDef.Radius = radius / metric;

			Body body = world.CreateBody(bDef);
			body.CreateShape(pDef);
			body.SetMassFromShapes();

			float Inertia = body.GetInertia();
			MassData md = new MassData();
			md.I = Inertia;
			md.Mass = mass;
			body.SetMass(md);

			InfoBody info = new InfoBody();
			info.image = image;
			info.body = body;
			info.userDate = userDate;

			body.SetUserData(info);

			return info;
		}

		public InfoBody AddCircle(float x, float y, float radius, float angle, float density,
			float friction, float restetution, float mass, Image image, bool IsBullet = true,
			bool IsSensor = false, bool AllowSleep = false, short group_index = 1, object userDate = null)
		{
			BodyDef bDef = new BodyDef();
			bDef.Position.Set(x / metric, y / metric);
			bDef.Angle = angle;
			bDef.AllowSleep = AllowSleep;
			bDef.IsBullet = IsBullet;

			CircleDef pDef = new CircleDef();
			pDef.Restitution = restetution;
			pDef.Friction = friction;
			pDef.Density = density;
			pDef.Radius = radius / metric;
			pDef.Filter.GroupIndex = group_index;
			pDef.IsSensor = IsSensor;

			Body body = world.CreateBody(bDef);
			body.CreateShape(pDef);
			body.SetMassFromShapes();

			float Inertia = body.GetInertia();
			MassData md = new MassData();
			md.I = Inertia;
			md.Mass = mass;
			body.SetMass(md);

			InfoBody info = new InfoBody();
			info.image = image;
			info.body = body;
			info.userDate = userDate;

			body.SetUserData(info);

			return info;
		}
		#endregion
		#region Vert
		public InfoBody AddVert(float x, float y, Vec2[] vert, float angle, float density,
			float friction, float restetution, Bitmap image, object userDate = null)
		{
			float max_w = vert[0].X;
			float max_h = vert[0].Y;

			for (int i = 0; i < vert.Length; i++)
			{
				if (vert[i].X > max_w)
					max_w = vert[i].X;

				if (vert[i].Y > max_h)
					max_h = vert[i].Y;

				vert[i].X /= 2;
				vert[i].Y /= 2;

				vert[i].X /= metric;
				vert[i].Y /= metric;
			}

			Image g_image = new Image(game);
			g_image.SetImage(image);
			g_image.SetWidth(max_w);
			g_image.SetHeight(max_h);

			BodyDef bDef = new BodyDef();
			bDef.Position.Set(x / metric, y / metric);
			bDef.Angle = angle;

			PolygonDef pDef = new PolygonDef();
			pDef.Restitution = restetution;
			pDef.Friction = friction;
			pDef.Density = density;
			pDef.SetAsBox(max_w / metric / 2, max_h / metric / 2);
			pDef.Vertices = vert;

			Body body = world.CreateBody(bDef);
			body.CreateShape(pDef);
			body.SetMassFromShapes();

			InfoBody info = new InfoBody();
			info.image = g_image;
			info.body = body;
			info.userDate = userDate;

			body.SetUserData(info);

			return info;
		}

		public InfoBody AddVert(float x, float y, Vec2[] vert, float angle, float density,
			float friction, float restetution, float mass, Image image, object userDate = null)
		{
			for (int i = 0; i < vert.Length; i++)
			{
				vert[i].X /= 2;
				vert[i].Y /= 2;

				vert[i].X /= metric;
				vert[i].Y /= metric;
			}

			BodyDef bDef = new BodyDef();
			bDef.Position.Set(x / metric, y / metric);
			bDef.Angle = angle;

			PolygonDef pDef = new PolygonDef();
			pDef.Restitution = restetution;
			pDef.Friction = friction;
			pDef.Density = density;
			pDef.SetAsBox(image.GetWidth() / metric / 2, image.GetHeight() / metric / 2);
			pDef.Vertices = vert;

			Body body = world.CreateBody(bDef);
			body.CreateShape(pDef);
			body.SetMassFromShapes();

			float Inertia = body.GetInertia();
			MassData md = new MassData();
			md.I = Inertia;
			md.Mass = mass;
			body.SetMass(md);

			InfoBody info = new InfoBody();
			info.image = image;
			info.body = body;
			info.userDate = userDate;

			body.SetUserData(info);

			return info;
		}

		public InfoBody AddVert(float x, float y, Vec2[] vert, float angle, float density,
			float friction, float restetution, float mass, Image image, bool IsBullet = true,
			bool IsSensor = false, bool AllowSleep = false, short group_index = 1, object userDate = null)
		{
			for (int i = 0; i < vert.Length; i++)
			{
				vert[i].X /= 2;
				vert[i].Y /= 2;

				vert[i].X /= metric;
				vert[i].Y /= metric;
			}

			BodyDef bDef = new BodyDef();
			bDef.Position.Set(x / metric, y / metric);
			bDef.Angle = angle;
			bDef.AllowSleep = AllowSleep;
			bDef.IsBullet = IsBullet;

			PolygonDef pDef = new PolygonDef();
			pDef.Restitution = restetution;
			pDef.Friction = friction;
			pDef.Density = density;
			pDef.SetAsBox(image.GetWidth() / metric / 2, image.GetHeight() / metric / 2);
			pDef.Vertices = vert;
			pDef.Filter.GroupIndex = group_index;
			pDef.IsSensor = IsSensor;

			Body body = world.CreateBody(bDef);
			body.CreateShape(pDef);
			body.SetMassFromShapes();

			float Inertia = body.GetInertia();
			MassData md = new MassData();
			md.I = Inertia;
			md.Mass = mass;
			body.SetMass(md);

			InfoBody info = new InfoBody();
			info.image = image;
			info.body = body;
			info.userDate = userDate;

			body.SetUserData(info);

			return info;
		}
		#endregion

		// Работу с Joint добавлю в следующихх update
	}
}