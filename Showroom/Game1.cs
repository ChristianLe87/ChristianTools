namespace Showroom;

public class Game1 : ChristianGame
{
    public Game1(WK wk) : base(scenes, startScene: "Scene_Zeldamon", wk)
    {
    }

    private static Dictionary<string, IScene> scenes = new Dictionary<string, IScene>()
    {
        { "Scene_Test", new Scene_Test() },
        { "Scene_Menu", new Scene_Menu() },
        { "Scene_UI", new Scene_UI() },
        { "Scene_Camera", new Scene_Camera() },
        { "Scene_Entities", new Scene_Entities() },
        { "Scene_Tiles", new Scene_Tiles() },
        { "Scene_Zeldamon", new Scene_Zeldamon() },
        { "Scene_Platformer", new Scene_Platformer() },
    };
}