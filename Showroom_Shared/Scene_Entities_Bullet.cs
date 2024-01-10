
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Showroom_CrossPlatform.UI;
using ChristianTools.Helpers.Enums_Interfaces_Delegates;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Showroom_Shared.Helpers;

namespace Showroom_Shared.Scenes
{

    public class Scene_Entities_Bullet : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Camera camera { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        
        public void Initialize(Viewport viewport)
        {
            this.UIs = new List<IUI>()
            {
                new Label(
                    rectangle: new Rectangle(10, 10, 250, 50),
                    text: "Click somewhere",
                    textAlignment: Label.TextAlignment.Midle_Center,
                    tag: ""
                ),
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "<- Entities",
                    tag: "goToEntities",
                    OnClickAction: null//() => Game1.ChangeToScene(WK.Scene.Entities)
                ),
            };

            this.entities = new List<IEntity>();
            this.dxUpdateSystem = (Viewport viewport, InputState lastInputState, InputState inputState, IScene scene) => UpdateSystem(lastInputState, inputState);

        }

        public void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            if (lastInputState?.Mouse_LeftButton == ButtonState.Released && inputState.Mouse_LeftButton == ButtonState.Pressed)
            {
                Bullet bullet = new Bullet(
                    direction: inputState.Mouse_Position().ToVector2(),
                    steps: 3,
                    imageFromAtlas: new Rectangle(0,0,64,64),
                    timeToDeactivate: new TimeSpan(0, 0, 2)
                );
                
                entities.Add(bullet);
            }
        }
    }
}