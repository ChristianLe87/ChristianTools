using System.Collections.Generic;
using ChristianTools.Helpers;
using ChristianTools.Helpers.Enums_Interfaces_Delegates;

namespace Showroom_Shared.Helpers;

public class WK : IDefault
{
	public string WindowTitle { get; } // ToDo: implement
	public double FPS { get; } // ToDo: implement
	public bool IsFullScreen { get; set; } = false; // ToDo: implement
	public bool AllowUserResizing { get; } = false; // ToDo: implement
	public int ScaleFactor { get; set; } = 1; // ToDo: implement
	public int canvasWidth { get; } // ToDo: implement
	public int canvasHeight { get; } // ToDo: implement
	public int AssetSize { get; } // ToDo: implement
	public string GameDataFileName { get; } // ToDo: implement
	public bool isMouseVisible { get; set; } // ToDo: implement
	public string FontFileName { get; }
	public string AtlasTextureFileName { get; } = "Atlas_PNG";

	public WK()
	{
	}
	
	public WK(string WindowTitle, double FPS, bool IsFullScreen, bool AllowUserResizing, int ScaleFactor, int canvasWidth, int canvasHeight, int AssetSize, string GameDataFileName, bool isMouseVisible, Dictionary<string, IScene> scenes)
	{
	}
	
	public static class SceneName
	{
		public static readonly string Menu = "Menu";
	}
	
}