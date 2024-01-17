using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools.Entities
{
    public class Scene : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Camera camera { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }

        public virtual void Initialize()
        {
            this.camera = new Camera();
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState: lastInputState, inputState: inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
        }

        public void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            // UIs
            {
                if (this.UIs != null)
                    foreach (var ui in this.UIs)
                        ui.dxUpdateSystem(lastInputState: lastInputState, inputState: inputState);
            }
         

            // Entities
            {
                if (this.entities != null)
                    for (int i = 0; i < this.entities.Count; i++)
                        if (this.entities[i].dxUpdateSystem != null)
                            this.entities[i].dxUpdateSystem(lastInputState: lastInputState, inputState: inputState);
            }
          

            // Camera
            {
                if (camera != null)
                    if (this.entities != null)
                        if (this.entities.Where(x => x.tag == "player").Count() > 0)
                            this.camera.MoveCamera(this.entities.Where(x => x.tag == "player").FirstOrDefault().rigidbody.rectangle.Center);
            
                if (camera != null)
                    this.camera.UpdateCamera();
            }
        }

        public void DrawSystem(SpriteBatch spriteBatch)
        {
            // UIs
            if (this.UIs != null)
                foreach (var ui in this.UIs)
                    ui.dxDrawSystem(spriteBatch: spriteBatch);

            // Entities
            if (this.entities != null)
                for (int i = 0; i < this.entities.Count; i++)
                    if (this.entities[i].dxDrawSystem != null)
                        this.entities[i].dxDrawSystem(spriteBatch: spriteBatch);
        }
    }
}