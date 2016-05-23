using System;

namespace LMD_GameFramewerk_Android.GameFramewerk
{
	public interface IFileIO
	{
		void SetDataXMLFile(string path, object obj);
		object GetDataXMLFile(string path, Type type);
	}
}