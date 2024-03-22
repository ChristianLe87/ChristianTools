using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;

namespace ChristianTools.Prefabs
{
    public abstract class BaseScene : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Map map { get; set; }
        public Camera camera { get; set; }
        
        public BaseScene()
        {
            this.entities = new List<IEntity>();
            this.UIs = new List<IUI>();
            this.map = new Map();
            this.camera = new Camera();
        }

        public virtual void Initialize()
        {
        }
    }
}