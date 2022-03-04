using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
	public partial class Systems
	{
		public partial class Draw
		{
			public static void Tile(SpriteBatch spriteBatch, ITile tile)
			{
				if (tile.isActive == false)
					return;


				if (tile.dxDrawSystem != null)
				{
					tile.dxDrawSystem(spriteBatch);
				}
				else
				{
					if (!true)
					{
						spriteBatch.Draw(texture: tile.texture, destinationRectangle: tile.rigidbody.rectangle, Color.White);
					}
					else
					{
						spriteBatch.Draw(
							texture: tile.texture,
							destinationRectangle: tile.rigidbody.rectangle,
							sourceRectangle: null,
							color: Color.White,
							rotation: 0f,
							origin: new Vector2(),
							effects: SpriteEffects.None,
							layerDepth: (float)tile.layerID / 10f
						);
					}
				}
			}
		}
	}
}