using System;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Entities;

namespace ChristianTools.Systems
{
    public class Systems
    {
        public class Update
        {
            public static void Scene(InputState lastInputState, InputState inputState, IScene scene)
            {
                if (scene.UIs != null)
                    foreach (var ui in scene.UIs)
                        ui.Update(lastInputState, inputState);

                if (scene.entities != null)
                    for (int i = 0; i < scene.entities.Count; i++)
                        Systems.Update.Entity(lastInputState, inputState, scene.entities[i]);

                if (scene.dxSceneUpdateSystem != null)
                    scene.dxSceneUpdateSystem(lastInputState, inputState);
            }

            /*public static void PlayerMetroid(InputState lastInputState, InputState inputState, IEntity player, IScene scene, int scaleFactor)
            {
                if (player.characterState.ToString().Contains("Right"))
                    player.characterState = CharacterState.IdleRight;
                else if (player.characterState.ToString().Contains("Left"))
                    player.characterState = CharacterState.IdleLeft;

                if (inputState.Down)
                    player.rigidbody.Move_Y(scaleFactor * 6);
                else if (inputState.Up)
                    player.rigidbody.Move_Y(-scaleFactor * 3);

                if (inputState.Right)
                {
                    player.characterState = CharacterState.MoveRight;
                    player.rigidbody.Move_X(scaleFactor * 2);
                }
                else if (inputState.Left)
                {
                    player.characterState = CharacterState.MoveLeft;
                    player.rigidbody.Move_X(-scaleFactor * 2);
                }


                Tile tile = scene.map.tiles.Where(x => x.rigidbody.rectangle.Intersects(player.rigidbody.rectangleDown)).FirstOrDefault();
                if (tile == null)
                {
                    if (player.characterState.ToString().Contains("Right"))
                        player.characterState = CharacterState.FallRight;
                    else if (player.characterState.ToString().Contains("Left"))
                        player.characterState = CharacterState.FallLeft;
                }
                else
                {
                    player.extraComponents.Set("isJumping", false);
                }

                if (lastInputState.Jump == false && inputState.Jump == true)
                {
                    player.extraComponents.Set("isJumping", true);

                    if (player.characterState.ToString().Contains("Right"))
                        player.characterState = CharacterState.JumpRight;
                    else if (player.characterState.ToString().Contains("Left"))
                        player.characterState = CharacterState.JumpLeft;
                }


                if (player.extraComponents.Get<bool>("isJumping") == true)
                {
                    if (player.characterState.ToString().Contains("Right"))
                        player.characterState = CharacterState.JumpRight;
                    else if (player.characterState.ToString().Contains("Left"))
                        player.characterState = CharacterState.JumpLeft;
                }


                player.animation.Update();
                player.rigidbody.Update(scene.map);
            }*/

            /*public static void Prefab(InputState lastInputState, InputState inputState, Entity prefab)
            {
                if (prefab.isActive == true)
                {
                    if (prefab.dxEntityUpdateSystem != null)
                        prefab.dxEntityUpdateSystem(lastInputState, inputState, prefab);

                    prefab.rigidbody.Update();
                }
            }*/

            public static void Entity(InputState lastInputState, InputState inputState, IEntity entity)
            {
                if (entity.dxEntityUpdateSystem != null)
                    entity.dxEntityUpdateSystem(lastInputState, inputState, entity);
            }
        }

        public class Draw
        {
            public static void Scene(SpriteBatch spriteBatch, IScene scene)
            {
                if (scene.UIs != null)
                    foreach (var ui in scene.UIs)
                        Systems.Draw.UI(spriteBatch, ui);

                if (scene.entities != null)
                    foreach (var entity in scene.entities)
                        Systems.Draw.Entity(spriteBatch, entity);

                if (scene.map != null)
                    scene.map.Draw(spriteBatch);

                if (scene.dxSceneDrawSystem != null)
                    scene.dxSceneDrawSystem(spriteBatch);
            }

            public static void UI(SpriteBatch spriteBatch, IUI ui)
            {
                ui.Draw(spriteBatch);
            }

            /*public static void Prefab(SpriteBatch spriteBatch, Entity prefab)
            {
                if (prefab.isActive == true)
                {
                    if (prefab.dxEntityDrawSystem != null)
                        prefab.dxEntityDrawSystem(spriteBatch, prefab);
                    else
                        spriteBatch.Draw(prefab.animation.GetTexture(prefab.characterState), prefab.rigidbody.rectangle, Color.White);
                }
            }*/

            public static void Entity(SpriteBatch spriteBatch, IEntity entity)
            {
                if (entity.isActive == true)
                {
                    Texture2D texture2D = entity.animation.GetTexture(entity.characterState);
                    Rectangle rectangle = new Rectangle((int)entity.rigidbody.centerPosition.X, (int)entity.rigidbody.centerPosition.Y, texture2D.Width, texture2D.Height);


                    spriteBatch.Draw(
                        texture: texture2D,
                        destinationRectangle: rectangle,
                        sourceRectangle: null,
                        color: Color.White,
                        rotation: (float)Tools.Tools.MyMath.DegreeToRadian(entity.rigidbody.rotationDegree),// always value radians
                        origin: new Vector2(rectangle.Width / 2, rectangle.Height / 2),
                        effects: SpriteEffects.None,
                        layerDepth: 0f
                    );
                }


                if (entity.dxEntityDrawSystem != null)
                    entity.dxEntityDrawSystem(spriteBatch, entity);
            }
        }
    }
}