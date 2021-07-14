using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoUI
{
    abstract class IUIBase
    {
        abstract public void Update();
        abstract public void Draw(SpriteBatch spriteBatch);
        abstract public void SetPosition(Vector2 position);
        abstract public int GetWidth();
        abstract public int GetHeight();
    }
}
