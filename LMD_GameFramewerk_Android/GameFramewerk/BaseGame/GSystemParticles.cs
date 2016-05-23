using System;
using System.Collections.Generic;
using Android.Graphics;
using LMD_GameFramewerk_Android.GameFramewerk.UI;
using Color = System.Drawing.Color;
using PointF = System.Drawing.PointF;

namespace LMD_GameFramewerk_Android.GameFramewerk.BaseGame
{
	public class GSystemParticles : ISystemParticles
	{
		private List<Particle> particles;
		private IGame game;
		private Random random;

		public GSystemParticles(IGame game)
		{
			this.game = game;
			particles = new List<Particle>();
		}

		public void Add(float x, float y, ParticleParameters[] parameterses)
		{
			foreach (var param in parameterses)
			{
				for (int i = 0; i < param.Size; i++)
				{
					particles.Add(new Particle(game, x, y, param));
				}
			}
		}

		public void DrawAndStep(float dt)
		{
			for (int i = 0; i < particles.Count; i++)
			{
				particles[i].Step(dt);
				particles[i].Draw();

				if (particles[i].Dead)
				{
					particles[i].Dispose();
					particles.Remove(particles[i]);
				}
			}
		}

		public void Dispose()
		{
			for (int i = 0; i < particles.Count; i++)
				particles[i].Dispose();
			particles.Clear();
		}


		public class Particle : ParticleParameters
		{
			public bool Dead;
			protected IGame game;
			protected float x;
			protected float y;
			protected float vel_x;
			protected float vel_y;

			public Particle(IGame game, float x, float y, ParticleParameters parameters)
			{
				Dead = false;

				this.game = game;
				this.Type = parameters.Type;
				this.width = parameters.width;
				this.height = parameters.height;
				this.Alpha = parameters.Alpha;
				this.AngularVelocity = parameters.AngularVelocity;
				this.Color = parameters.Color;
				this.Image = parameters.Image;
				this.LinearVelocity = parameters.LinearVelocity;
				this.TTL = parameters.TTL;
				this.VelocityAlpha = parameters.VelocityAlpha;
				this.radius = parameters.radius;
				this.x = x;
				this.y = y;
			}

			public void Step(float dt)
			{
				if (Type != TypeParticle.Image)
				{
					TTL--;
					Alpha -= VelocityAlpha;
					radius -= VelSize;

					if (TTL <= 0) Dead = true;
					if (Alpha <= VelocityAlpha) Dead = true;
					if (radius <= Math.Abs(VelocityAlpha)) Dead = true;

					x += vel_x;
					y += vel_y;
				}
				else
				{
					TTL--;
					Alpha -= VelocityAlpha;
					radius -= VelSize;

					if (TTL <= 0) Dead = true;
					if (radius <= Math.Abs(VelocityAlpha)) Dead = true;
					Image?.Step(dt);
				}
			}

			public void Draw()
			{
				switch (Type)
				{
					case TypeParticle.Circle:
						Matrix _matrix = new Matrix();
					//	_matrix.Translate(x - radius, y - radius);
					//	_matrix.RotateAt(angle, new PointF(x, y));
					//	game.GetGraphics().GetGraphics().Transform = _matrix;

					//	game.GetGraphics().GetGraphics().FillEllipse(new SolidBrush(base.Color.FromArgb((int)Alpha, Color)), 0, 0, radius * 2, radius * 2);
						break;
					case TypeParticle.Image:
						Image.SetWidth(radius * 2);
						Image.SetHeight(radius * 2);
						Image.SetX(x);
						Image.SetY(y);
						Image.SetAngularVelocity(AngularVelocity);
						Image.Draw();
						break;
					case TypeParticle.Vert:
						Matrix matrix = new Matrix();
						matrix.SetTranslate(x, y);
						matrix.SetRotate(angle, x, y);
						game.GetGraphics().GetGraphics().Matrix = matrix;

					//	game.GetGraphics().GetGraphics().DrawPoints(new SolidBrush(base.Color.FromArgb((int)Alpha, Color)), verts);
						break;
				}
			}

			public void Dispose()
			{
				Image?.Dispose();
			}
		}

		public class ParticleParameters
		{
			public float width;
			public float height;
			public float radius;
			public Image Image;
			public int Size;
			public int TTL;
			public float Alpha;
			public Color Color;
			public float VelocityAlpha;
			public float LinearVelocity;
			public float AngularVelocity;
			public TypeParticle Type;
			public PointF[] verts;
			public float angle;
			public float VelSize;

			public ParticleParameters()
			{
				Image = null;
				Size = 1;
				TTL = 100;
				Alpha = 255;
				Color = Color.Aqua;
				VelocityAlpha = 1f;
				LinearVelocity = 2f;
				AngularVelocity = 1f;
				Type = TypeParticle.Circle;
				VelSize = 0.1f;
			}
		}

		public enum TypeParticle
		{
			Image,
			Vert,
			Circle
		}
	}
}