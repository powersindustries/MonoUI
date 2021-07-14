using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoUI
{
    class Circle : IUIBase
    {
        private Texture2D m_Texture;
        private Vector2 m_Position;
        private Color m_Color;

        private int m_Diameter;


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Circle()
        {
            m_Position = new Vector2();

            m_Color = Color.White;

            m_Diameter = 0;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Circle(Vector2 position, Color color, int diameter)
        {
            m_Position = position;

            m_Color = color;

            m_Diameter = diameter;

            SetCircleTexture();
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
            spriteBatch.Draw(m_Texture, m_Position, m_Color);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void SetPosition(Vector2 position)
        {
            m_Position = position;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetWidth()
        {
            return m_Diameter;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetHeight()
        {
            return m_Diameter;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetDiameter(int diameter)
        {
            m_Diameter = diameter;

            SetCircleTexture();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetColor(Color color)
        {
            m_Color = color;

            SetCircleTexture();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        private void SetCircleTexture()
        {
            if (m_Diameter == 0)
            {
                return;
            }
            
            Texture2D circleTexture = new Texture2D(Game1.m_MainGraphicsDevice, m_Diameter, m_Diameter);
            float circleRadius = m_Diameter / 2;
            
            Color[] colorData = new Color[m_Diameter * m_Diameter];
            
            for (int x=0; x < m_Diameter; ++x)
            {
                for (int y=0; y < m_Diameter; ++y)
                {
                    Vector2 currentPosition = new Vector2(x - circleRadius, y - circleRadius);
                    int currentIndex = (x * m_Diameter) + y;
                    
                    if (currentPosition.LengthSquared() <= (circleRadius * circleRadius))
                    {
                        colorData[currentIndex] = Color.White;
                    }
                    else
                    {
                        colorData[currentIndex] = Color.Transparent;
                    }
                }
            }

            circleTexture.SetData(colorData);

            m_Texture = circleTexture;
        }

    }
}
