namespace Showroom.Scenes
{
    public class Scene_Tiles : BaseScene
    {
        public override void Initialize()
        {
            this.entities = new List<IEntity>()
            {
                new Entity_Numbers(rectangle: new Rectangle(4 * 16, 2 * 16, 16, 16), imageFromAtlas: WK.AtlasEntitiesReferences.Idel_Down, tag: "player"),
                new ChristianTools.Entities.ZeroZeroPoint_Entity()
            };

            this.UIs = new List<IUI>()
            {
                // Back to menu
                new Button(
                    rectangle: new Rectangle(10, 460, 230, 30),
                    text: "<-- Back to menu",
                    defaultTexture: null,
                    mouseOverTexture: null,
                    tag: "",
                    OnClickAction: () => Game1.ChangeToScene("Scene_Menu")
                ),
                new Button(
                    rectangle: new Rectangle(260, 10, 230, 30),
                    text: "SetPlayerSystem_Move_WASD",
                    defaultTexture: null,
                    mouseOverTexture: null,
                    tag: "",
                    OnClickAction: () => SetPlayerSystem_Move_WASD()
                ),

                new Button(
                    rectangle: new Rectangle(260, 50, 230, 30),
                    text: "SetPlayerSystem_Move_PlatformerPlayer",
                    defaultTexture: null,
                    mouseOverTexture: null,
                    tag: "",
                    OnClickAction: () => SetPlayerSystem_Move_PlatformerPlayer()
                ),
            };


            int[,] mainIntTiles = new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1 },
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1 },
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1 },
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };

            Tile[,] mainTileTiles = Tile.FromInt_ToTile(mainIntTiles, LayerDepth.Main);
            this.map = new Map(mainTiles: mainTileTiles);

            this.camera = new Camera(zoom: 1, entityToFollow: entities.Find(x => x.tag == "player"));
        }

        private void SetPlayerSystem_Move_WASD()
        {
            IEntity entity = this.entities.Find(x => x.tag == "player");
            entity.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.Move_WASD(lastInputState, inputState, entity, 4);
            entity.rigidbody.force = new Vector2();
        }

        private void SetPlayerSystem_Move_PlatformerPlayer()
        {
            IEntity entity = this.entities.Find(x => x.tag == "player");
            entity.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.PlatformerPlayer(lastInputState, inputState, entity);
        }
    }
}