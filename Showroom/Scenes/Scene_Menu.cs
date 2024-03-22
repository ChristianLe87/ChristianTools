using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom.Scenes
{
    public class Scene_Menu : BaseScene
    {
        public override void Initialize()
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

                new ZeroZeroPoint_UI()
            };

            this.entities = new List<IEntity>()
            {
                new ZeroZeroPoint_Entity(),

                // TL
                new Entity_Numbers(new Rectangle(0, 0, 16, 16), WK.AtlasReferences._1),

                // TR
                new Entity_Numbers(new Rectangle(484, 0, 16, 16), WK.AtlasReferences._3),

                // Center
                new Entity_WASD(ChristianTools.Helpers.MyRectangle.CreateRectangle(new Point(250, 250), 16, 16), WK.AtlasReferences._5, tag: "player"),

                // DL
                new Entity_Numbers(new Rectangle(0, 484, 16, 16), WK.AtlasReferences._7),

                // DR
                new Entity_Numbers(new Rectangle(484, 484, 16, 16), WK.AtlasReferences._9),
            };

            this.camera = new Camera(entities.Find(x => x.tag == "player"));
        }
    }
}