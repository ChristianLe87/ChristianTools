﻿using System;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shared;
using System.Linq;

namespace ChristianTools.Systems
{
    public class Systems
    {
        public class Update
        {
            public static void All(InputState lastInputState, InputState inputState, IScene scene)
            {
                if (scene.UIs != null)
                    foreach (var ui in scene.UIs)
                        ui.Update(lastInputState, inputState);

                if (scene.entities != null)
                    for (int i = 0; i < scene.entities.Count; i++)
                        scene.entities[i].Update(lastInputState, inputState);
            }

            internal static void Player(InputState lastInputState, InputState inputState, IEntity player, IScene scene, int scaleFactor)
            {
                if (inputState.Down)
                    player.rigidbody.Move_Y(scaleFactor);
                else if (inputState.Up)
                    player.rigidbody.Move_Y(-scaleFactor);

                if (inputState.Right)
                    player.rigidbody.Move_X(scaleFactor);
                else if (inputState.Left)
                    player.rigidbody.Move_X(-scaleFactor);

                player.animation.Update();
                player.rigidbody.Update(scene.map);
            }

            public static void Entity(InputState lastInputState, InputState inputState, IEntity entity)
            {
                entity.Update(lastInputState, inputState);
            }
        }

        public class Draw
        {
            public static void All(SpriteBatch spriteBatch, IScene scene)
            {
                if (scene.UIs != null)
                    foreach (var ui in scene.UIs)
                        ui.Draw(spriteBatch);

                if (scene.entities != null)
                    foreach (var entity in scene.entities)
                        entity.Draw(spriteBatch);

                if (scene.map != null)
                    scene.map.Draw(spriteBatch);
            }

            public static void Entity(SpriteBatch spriteBatch, IEntity entity)
            {
                spriteBatch.Draw(entity.animation.GetTexture(entity.characterState), entity.rigidbody.rectangle, Color.White);
            }

            public static void EntityWithRotation(SpriteBatch spriteBatch, IEntity entity)
            {
                spriteBatch.Draw(
                    texture: entity.animation.GetTexture(entity.characterState),
                    destinationRectangle: new Rectangle((int)entity.rigidbody.centerPosition.X, (int)entity.rigidbody.centerPosition.Y, entity.rigidbody.rectangle.Width, entity.rigidbody.rectangle.Height),
                    sourceRectangle: null,
                    color: Color.White,
                    rotation: (float)Tools.Tools.MyMath.DegreeToRadian(entity.rigidbody.rotationDegree),// always value radians
                    origin: new Vector2(entity.rigidbody.rectangle.Width / 2, entity.rigidbody.rectangle.Height / 2),
                    effects: SpriteEffects.None,
                    layerDepth: 0f
                );
            }
        }
    }
}