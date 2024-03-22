using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom.Scenes
{
    public class Scene_Menu : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Map map { get; set; }
        public Camera camera { get; set; }

        public void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                new Label(
                    rectangle: new Rectangle(260, 10, 230, 30),
                    "Menu",
                    textAlignment: Label.TextAlignment.Midle_Center
                ),
                new Button(
                    rectangle: new Rectangle(10, 10, 230, 30),
                    text: "Components",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Console.WriteLine("---") //Game1.ChangeToScene(WK.Scene.Components)
                ),
                new Button(
                    rectangle: new Rectangle(10, 50, 230, 30),
                    text: "Entities",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Entities")
                ),
                new Button(
                    rectangle: new Rectangle(10, 90, 230, 30),
                    text: "Helpers",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Console.WriteLine("---") //Game1.ChangeToScene(WK.Scene.Helpers)
                ),
                new Button(
                    rectangle: new Rectangle(10, 130, 230, 30),
                    text: "Tools",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Console.WriteLine("---") //Game1.ChangeToScene(WK.Scene.Tools)
                ),
                new Button(
                    rectangle: new Rectangle(10, 170, 230, 30),
                    text: "UI",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_UI")
                ),
                new Button(
                    rectangle: new Rectangle(10, 210, 230, 30),
                    text: "Systems",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Console.WriteLine("---") //Game1.ChangeToScene(WK.Scene.Systems)
                ),
                new Button(
                    rectangle: new Rectangle(250, 130, 230, 30),
                    text: "Tiles",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Tiles")
                ),
                new Button(
                    rectangle: new Rectangle(250, 170, 230, 30),
                    text: "Camera",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Camera")
                ),
                new Button(
                    rectangle: new Rectangle(250, 210, 230, 30),
                    text: "Scene_Test",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Test")
                ),
            };



            Rectangle _2B = new Rectangle(32, 32, 16, 16);
            this.entities = new List<IEntity>()
            {
                new ZeroZeroPoint(),
                //new Entity_WASD(new Rectangle(400, 50, 16, 16), _2B, tag: "player"),
                new Line(new Point(0,0), new Point(500,500), Color.Red, tag:"mylinecool")
            };

            IEntity entity = entities.Find(x => x.tag == "player");
            this.camera = new Camera(entity);
        }
    }
}