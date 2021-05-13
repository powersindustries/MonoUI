using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoUI
{
    class DividerLine : IUIBase
    {
        private Rectangle m_LineRectangle;

        private Color m_LineColor;

        private int m_Length;
        private int m_Thickness;

        private bool m_Horizontal;


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public DividerLine()
        {
            m_LineRectangle = new Rectangle();

            m_LineColor = Color.White;

            m_Length    = 0;
            m_Thickness = 0;

            m_Horizontal = true;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public DividerLine(Vector2 position, int length, int thickness, Color color, bool isHorizontal)
        {
            m_LineRectangle = new Rectangle();

            m_LineColor = color;

            m_Length    = length;
            m_Thickness = thickness;

            m_Horizontal = isHorizontal;
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
            spriteBatch.Draw(Game1.m_DebugTexture, m_LineRectangle, m_LineColor);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void SetPosition(Vector2 position)
        {
            m_LineRectangle.X = (int)position.X;
            m_LineRectangle.Y = (int)position.Y;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetWidth()
        {
            return m_LineRectangle.Width;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetHeight()
        {
            return m_LineRectangle.Height;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        private void RotateLine()
        {
            int newWidth  = m_LineRectangle.Height;
            int newHeight = m_LineRectangle.Width;

            m_LineRectangle.Height = newHeight;
            m_LineRectangle.Width  = newWidth;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetLength(int length)
        {
            m_Length = length;
            
            if (m_Horizontal)
            {
                m_LineRectangle.Width = m_Length;
            }
            else
            {
                m_LineRectangle.Height = m_Length;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetThickness(int thickness)
        {
            m_Thickness = thickness;
            
            if (m_Horizontal)
            {
                m_LineRectangle.Height = m_Thickness;
            }
            else
            {
                m_LineRectangle.Width = m_Thickness;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetIsHorizontal(bool isHorizontal)
        {
            if (m_Horizontal != isHorizontal)
            {
                RotateLine();
            }

            m_Horizontal = isHorizontal;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetColor(Color color)
        {
            m_LineColor = color;
        }

    }
}
