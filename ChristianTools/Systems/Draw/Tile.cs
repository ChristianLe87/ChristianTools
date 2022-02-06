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
					// Tile texture
					spriteBatch.Draw(tile.texture, tile.rigidbody.rectangle, Color.White);

					// Shadow
					spriteBatch.Draw(tile.texture, tile.rigidbody.rectangle, tile.GetShadow(ChristianTools.Helpers.ChristianGame.GetScene.lights));
				}
			}
		}
	}
}