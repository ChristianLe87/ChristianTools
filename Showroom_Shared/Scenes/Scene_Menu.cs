using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Showroom_CrossPlatform.UI;
using ChristianTools.Helpers.Enums_Interfaces_Delegates;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom_Shared.Scenes
{
    public class Scene_Menu : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Camera camera { get; set; }

        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }

        public void Initialize(Viewport viewport)
        {
            //this.camera = new Camera(viewport);

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
                    defaultTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Gray),
                    tag: "goToComponents",
                    OnClickAction: () => Console.WriteLine("---")//Game1.ChangeToScene(WK.Scene.Components)
                ),
                new Button(
                    rectangle: new Rectangle(10, 50, 230, 30),
                    text: "Entities",
                    defaultTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Gray),
                    tag: "goToEntities",
                    OnClickAction: () => Console.WriteLine("---")//Game1.ChangeToScene(WK.Scene.Entities)
                ),
                new Button(
                    rectangle: new Rectangle(10, 90, 230, 30),
                    text: "Helpers",
                    defaultTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Gray),
                    tag: "goToHelpers",
                    OnClickAction: () => Console.WriteLine("---")//Game1.ChangeToScene(WK.Scene.Helpers)
                ),
                new Button(
                    rectangle: new Rectangle(10, 130, 230, 30),
                    text: "Tools",
                    defaultTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Gray),
                    tag: "goToTools",
                    OnClickAction: () => Console.WriteLine("---")//Game1.ChangeToScene(WK.Scene.Tools)
                ),
                new Button(
                    rectangle: new Rectangle(10, 170, 230, 30),
                    text: "UI",
                    defaultTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Gray),
                    tag: "goToUI",
                    OnClickAction: () => Game1.ChangeToScene("UIs")
                ),
                new Button(
                    rectangle: new Rectangle(10, 210, 230, 30),
                    text: "Systems",
                    defaultTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Gray),
                    tag: "goToSystems",
                    OnClickAction: () => Console.WriteLine("---")//Game1.ChangeToScene(WK.Scene.Systems)
                ),
                new Button(
                    rectangle: new Rectangle(250, 210, 230, 30),
                    text: "Others",
                    defaultTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Gray),
                    tag: "goToOthers",
                    OnClickAction: () => Console.WriteLine("---")//Game1.ChangeToScene(WK.Scene.Others)
                ),
            };

            this.entities = new List<IEntity>()
            {
                new Tree(new Point(100, 100), new Rectangle(64, 32, 16, 16), true),
            };

            this.dxUpdateSystem = (Viewport viewport, InputState lastInputState, InputState inputState, IScene scene) => UpdateSystem(viewport, lastInputState, inputState);
            //this.dxDrawSceneSystem = (SpriteBatch spriteBatch, IScene scene, SpriteFont spriteFont) => DrawSystem(spriteBatch, scene, spriteFont);

        }

        public void UpdateSystem(Viewport viewport, InputState lastInputState, InputState inputState)
        {
            //if(camera != null) camera.Update(new Point().ToVector2());
        }
    }
}