﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Islander.Entity
{
    class PowerUp : Entity
    {
        private float fadeToggle = 1.0f;

        public PowerUp(Texture2D sprite, Vector2 pos) : base(sprite)
        {
            alpha = 0.5f;
            scale = new Vector2(0.5f);
            position = pos;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            alpha += fadeToggle * (1.0f / 1.0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (alpha >= 1.0f)
            {
                alpha = 1.0f;
                fadeToggle = -1.0f;
            }

            if (alpha <= 0.5f)
            {
                alpha = 0.5f;
                fadeToggle = 1.0f;
            }

        }
    }
}
