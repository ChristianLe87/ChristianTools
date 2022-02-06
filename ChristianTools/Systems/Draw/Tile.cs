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


				if (tile.dxTileDrawSystem != null)
                {
					tile.dxTileDrawSystem(spriteBatch);
				}
                else
                {
					spriteBatch.Draw(tile.texture, tile.rigidbody.rectangle, Color.White);

					//Texture2D texture = Tools.Tools.Texture.CreateColorTexture(tile.color, tile.texture.Width, tile.texture.Height);
					spriteBatch.Draw(tile.texture, tile.rigidbody.rectangle, tile.color);

					Color color = tile.color;
					color.A--;

					tile.color = color;
				}
					
			}
		}
	}
}