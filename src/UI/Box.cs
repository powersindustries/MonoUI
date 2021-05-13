using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoUI
{
    class Box : IUIBase
    {
        private Rectangle m_Rectangle;

        private Color m_Color;


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Box()
        {
            m_Rectangle = new Rectangle();

            m_Color = Color.White;
        }
        
        
        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Box(Rectangle rectangle)
        {
            m_Rectangle = rectangle;

            m_Color = Color.White;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Box(Vector2 position, int width, int height, Color color)
        {
            m_Rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            m_Color = color;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void Update()
        {
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.m_DebugTexture, m_Rectangle, m_Color);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void SetPosition(Vector2 position)
        {
            m_Rectangle.X = (int)position.X;
            m_Rectangle.Y = (int)position.Y;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetWidth()
        {
            return m_Rectangle.Width;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetHeight()
        {
            return m_Rectangle.Height;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetColor(Color color)
        {
            m_Color = color;
        }

    }
}
