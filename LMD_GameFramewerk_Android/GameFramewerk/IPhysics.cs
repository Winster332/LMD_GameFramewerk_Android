using Android.Graphics;
using Box2DX.Common;
using LMD_GameFramewerk_Android.GameFramewerk.UI;
using LMD_GameFramewerk_Android.GameFramewerk.BaseGame.Physics;

namespace LMD_GameFramewerk_Android.GameFramewerk
{
	public interface IPhysics
	{
		/// <summary>
		/// Инициализирует мир
		/// </summary>
		/// <param name="x">Граница мира слева</param>
		/// <param name="y">Граница мира сверху</param>
		/// <param name="width">Граница мира справа</param>
		/// <param name="height">Граница мира снизу</param>
		/// <param name="grav_x">Сила графитации по координате X</param>
		/// <param name="greav_y">Сила графитации по координате Y</param>
		/// <param name="doSleep">Могут ли все объекты находиться в спящем состоянии</param>
		void Initialize(float x, float y, float width, float height, float grav_x, float greav_y, bool doSleep);

		/// <summary>
		/// Очищает ресурсы
		/// </summary>
		void Dispose();

		/// <summary>
		/// Обновляет физический мир
		/// </summary>
		/// <param name="dt">Дельта времени</param>
		/// <param name="iterat">Колличество итераций проверки коллизий. В среднем 20-30</param>
		void Step(float dt, int iterat);

		/// <summary>
		/// Прорисовка мира
		/// </summary>
		void Draw();

		/// <summary>
		/// Возвращает указатель на солвер
		/// </summary>
		/// <returns></returns>
		Solver GetSolver();

		/// <summary>
		/// Добавляет в мир новое тело физической модели - квадрат
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		/// <param name="w">Ширина</param>
		/// <param name="h">Высота</param>
		/// <param name="angle">Угол наклона, в радианах</param>
		/// <param name="density">Упругость</param>
		/// <param name="friction">Сила трения</param>
		/// <param name="restetution">Плотность</param>
		/// <param name="image">Изображение для тела</param>
		/// <returns></returns>
		InfoBody AddRect(float x, float y, float w, float h, float angle, float density,
			float friction, float restetution, Bitmap image, object userDate = null);

		/// <summary>
		/// Добавляет в мир новое тело физической модели - квадрат
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		/// <param name="w">Ширина</param>
		/// <param name="h">Высота</param>
		/// <param name="angle">Угол наклона, в радианах</param>
		/// <param name="density">Упругость</param>
		/// <param name="friction">Сила трения</param>
		/// <param name="restetution">Плотность</param>
		/// <param name="mass">Масса тела</param>
		/// <param name="image">Настроеный класc GImage</param>
		/// <returns></returns>
		InfoBody AddRect(float x, float y, float w, float h, float angle, float density,
			float friction, float restetution, float mass, Image image, object userDate = null);

		/// <summary>
		/// Добавляет в мир новое тело физической модели - квадрат
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		/// <param name="w">Ширина</param>
		/// <param name="h">Высота</param>
		/// <param name="angle">Угол наклона, в радианах</param>
		/// <param name="density">Упругость</param>
		/// <param name="friction">Сила трения</param>
		/// <param name="restetution">Плотность</param>
		/// <param name="mass">Масса тела</param>
		/// <param name="image">Настроеный класc GImage</param>
		/// <param name="IsBullet">Увеличит точность коллизий этого тела</param>
		/// <param name="IsSensor">Объект не реагирует с другими объектами</param>
		/// <param name="AllowSleep">Объект спит</param>
		/// <param name="group_index">Индекс в фильтре коллизий</param>
		/// <returns></returns>
		InfoBody AddRect(float x, float y, float w, float h, float angle, float density,
			float friction, float restetution, float mass, Image image, bool IsBullet = true,
			bool IsSensor = false, bool AllowSleep = false, short group_index = 1, object userDate = null);

		/// <summary>
		/// Добавляет в мир новое тело физической модели - круг
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		/// <param name="radius">Радиус</param>
		/// <param name="angle">Угол наклона, в радианах</param>
		/// <param name="density">Упругость</param>
		/// <param name="friction">Сила трения</param>
		/// <param name="restetution">Плотность</param>
		/// <param name="image">Изображение для тела</param>
		/// <returns></returns>
		InfoBody AddCircle(float x, float y, float radius, float angle, float density,
			float friction, float restetution, Bitmap image, object userDate = null);

		/// <summary>
		/// Добавляет в мир новое тело физической модели - круг
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		/// <param name="radius">Ширина</param>
		/// <param name="angle">Угол наклона, в радианах</param>
		/// <param name="density">Упругость</param>
		/// <param name="friction">Сила трения</param>
		/// <param name="restetution">Плотность</param>
		/// <param name="mass">Масса тела</param>
		/// <param name="image">Настроеный класc GImage</param>
		/// <returns></returns>
		InfoBody AddCircle(float x, float y, float radius, float angle, float density,
			float friction, float restetution, float mass, Image image, object userDate = null);

		/// <summary>
		/// Добавляет в мир новое тело физической модели - круг
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		/// <param name="radius">Ширина</param>
		/// <param name="angle">Угол наклона, в радианах</param>
		/// <param name="density">Упругость</param>
		/// <param name="friction">Сила трения</param>
		/// <param name="restetution">Плотность</param>
		/// <param name="mass">Масса тела</param>
		/// <param name="image">Настроеный класc GImage</param>
		/// <param name="IsBullet">Увеличит точность коллизий этого тела</param>
		/// <param name="IsSensor">Объект не реагирует с другими объектами</param>
		/// <param name="AllowSleep">Объект спит</param>
		/// <param name="group_index">Индекс в фильтре коллизий</param>
		/// <returns></returns>
		InfoBody AddCircle(float x, float y, float radius, float angle, float density,
			float friction, float restetution, float mass, Image image, bool IsBullet = true,
			bool IsSensor = false, bool AllowSleep = false, short group_index = 1, object userDate = null);

		/// <summary>
		/// Добавляет в мир новое тело произвольной физической модели
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		/// <param name="vert">Вершины модели. Описывать вершины необходимо почасовой, 
		/// где координата (0;0) является центром тела</param>
		/// <param name="angle">Угол поворота тела в радианах</param>
		/// <param name="density">Упругость</param>
		/// <param name="friction">Сила трения</param>
		/// <param name="restetution">Плотность</param>
		/// <param name="image">Изображение для тела</param>
		/// <returns></returns>
		InfoBody AddVert(float x, float y, Vec2[] vert, float angle, float density,
			float friction, float restetution, Bitmap image, object userDate = null);

		/// <summary>
		/// Добавляет в мир новое тело произвольной физической модели
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		/// <param name="vert">Вершины модели. Описывать вершины необходимо почасовой, 
		/// где координата (0;0) является центром тела</param>
		/// <param name="angle">Угол поворота тела в радианах</param>
		/// <param name="density">Упругость</param>
		/// <param name="friction">Сила трения</param>
		/// <param name="restetution">Плотность</param>
		/// <param name="mass">Масса тела</param>
		/// <param name="image">Настроеный класc GImage</param>
		/// <returns></returns>
		InfoBody AddVert(float x, float y, Vec2[] vert, float angle, float density,
			float friction, float restetution, float mass, Image image, object userDate = null);

		/// <summary>
		/// Добавляет в мир новое тело произвольной физической модели
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		/// <param name="vert">Вершины модели. Описывать вершины необходимо почасовой, 
		/// где координата (0;0) является центром тела</param>
		/// <param name="angle">Угол поворота тела в радианах</param>
		/// <param name="density">Упругость</param>
		/// <param name="friction">Сила трения</param>
		/// <param name="restetution">Плотность</param>
		/// <param name="mass">Масса тела</param>
		/// <param name="image">Настроеный класc GImage</param>
		/// <param name="IsBullet">Увеличит точность коллизий этого тела</param>
		/// <param name="IsSensor">Объект не реагирует с другими объектами</param>
		/// <param name="AllowSleep">Объект спит</param>
		/// <param name="group_index">Индекс в фильтре коллизий</param>
		/// <returns></returns>
		InfoBody AddVert(float x, float y, Vec2[] vert, float angle, float density,
			float friction, float restetution, float mass, Image image, bool IsBullet = true,
			bool IsSensor = false, bool AllowSleep = false, short group_index = 1, object userDate = null);
	}
}