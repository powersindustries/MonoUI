using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace MonoUI
{
    class Button : IUIBase
    {
        private SpriteFont m_Font;

        private Rectangle m_ButtonRectangle;
        private Rectangle m_BoarderRectangle;

        private Color m_DefaultBackgroundColor;
        private Color m_CurrentBackgroundColor;
        private Color m_ClickColor;
        private Color m_HoverColor;
        private Color m_ButtonTextColor;

        private Vector2 m_TextPosition;

        private string m_ButtonText;

        private int m_BoarderRectangleOffset = 2;
        private int m_ButtonWidth;
        private int m_ButtonHeight;

        private bool m_Hovering     = false;
        private bool m_LeftClicked  = false;
        private bool m_RightClicked = false;
        private bool m_LeftHeld     = false;
        private bool m_RightHeld    = false;


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Button()
        {
            m_Font = Game1.m_Font;

            m_ButtonWidth  = 10;
            m_ButtonHeight = 10;

            m_ButtonRectangle  = new Rectangle(0, 0, m_ButtonWidth, m_ButtonHeight);
            m_BoarderRectangle = new Rectangle(0, 0, m_ButtonWidth, m_ButtonHeight);

            m_DefaultBackgroundColor = Color.Gray;
            m_CurrentBackgroundColor = m_DefaultBackgroundColor;
            m_ClickColor = Color.White;
            m_HoverColor = Color.Black;

            UpdateTextPosition();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Button(Vector2 position, int width, int height, Color backgroundColor)
        {
            m_Font = Game1.m_Font;

            m_ButtonWidth  = width;
            m_ButtonHeight = height;

            m_ButtonRectangle  = new Rectangle((int)position.X, (int)position.Y, m_ButtonWidth, m_ButtonHeight);
            m_BoarderRectangle = new Rectangle((int)position.X + m_BoarderRectangleOffset, (int)position.Y + m_BoarderRectangleOffset, width, height);

            m_DefaultBackgroundColor = backgroundColor;
            m_CurrentBackgroundColor = m_DefaultBackgroundColor;
            m_ClickColor = Color.White;
            m_HoverColor = Color.Black;

            UpdateTextPosition();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Button(Vector2 position, int width, int height, Color backgroundColor, string text, Color textColor)
        {
            m_Font = Game1.m_Font;

            m_ButtonText      = text;
            m_ButtonTextColor = textColor;

            m_ButtonWidth  = width;
            m_ButtonHeight = height;

            m_ButtonRectangle  = new Rectangle((int)position.X, (int)position.Y, m_ButtonWidth, m_ButtonHeight);
            m_BoarderRectangle = new Rectangle((int)position.X + 2, (int)position.Y + 2, m_ButtonWidth, m_ButtonHeight);

            m_DefaultBackgroundColor = backgroundColor;
            m_CurrentBackgroundColor = m_DefaultBackgroundColor;
            m_ClickColor = Color.White;
            m_HoverColor = Color.Black;

            UpdateTextPosition();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void Update()
        {
            MouseState mouseState = Mouse.GetState();
            Point currentMousePoint = new Point(mouseState.X, mouseState.Y);

            // Set states
            if (m_ButtonRectangle.Contains(currentMousePoint))
            {
                m_Hovering     = true;
                m_LeftHeld     = mouseState.LeftButton  == ButtonState.Pressed;
                m_RightHeld    = mouseState.RightButton == ButtonState.Pressed;
                m_LeftClicked  = mouseState.LeftButton  == ButtonState.Pressed && Game1.m_MouseStateOld.LeftButton == ButtonState.Released;
                m_RightClicked = mouseState.RightButton == ButtonState.Pressed && Game1.m_MouseStateOld.RightButton == ButtonState.Released;
            }
            else
            {
                m_Hovering     = false;
                m_LeftHeld     = false;
                m_RightHeld    = false;
                m_LeftClicked  = false;
                m_RightClicked = false;
            }

            // Set background state Styling
            if (m_LeftHeld || m_RightHeld)
            {
                m_CurrentBackgroundColor = m_ClickColor;
            }
            else
            {
                m_CurrentBackgroundColor = m_DefaultBackgroundColor;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (m_Hovering)
            {
                spriteBatch.Draw(Game1.m_DebugTexture, m_BoarderRectangle, m_HoverColor);
            }

            spriteBatch.Draw(Game1.m_DebugTexture, m_ButtonRectangle, m_CurrentBackgroundColor);

            if (m_Font != null && m_ButtonText != null)
            {
                spriteBatch.DrawString(m_Font, m_ButtonText, m_TextPosition, m_ButtonTextColor);
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void SetPosition(Vector2 position)
        {
            m_ButtonRectangle.X = (int)position.X;
            m_ButtonRectangle.Y = (int)position.Y;

            m_BoarderRectangle.X = (int)position.X + m_BoarderRectangleOffset;
            m_BoarderRectangle.Y = (int)position.Y + m_BoarderRectangleOffset;

            UpdateTextPosition();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetWidth()
        {
            return m_ButtonWidth;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetHeight()
        {
            return m_ButtonHeight;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        private void UpdateTextPosition()
        {
            if (m_ButtonText == "" || m_ButtonText == null)
            {
                return;
            }

            Vector2 textSize = m_Font.MeasureString(m_ButtonText);

            if (textSize.X > m_ButtonWidth)
            {
                SetWidth((int)textSize.X);
            }

            if (textSize.Y > m_ButtonHeight)
            {
                SetHeight((int)textSize.Y);
            }

            m_TextPosition = new Vector2(
                m_ButtonRectangle.X + (( m_ButtonRectangle.Width - textSize.X) / 2),
                m_ButtonRectangle.Y + (( m_ButtonRectangle.Height - textSize.Y) / 2)
            );
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetText(string text)
        {
            m_ButtonText = text;

            UpdateTextPosition();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetTextColor(Color color)
        {
            m_ButtonTextColor = color;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetWidth(int width)
        {
            m_ButtonWidth = width;

            m_ButtonRectangle.Width  = m_ButtonWidth;
            m_BoarderRectangle.Width = m_ButtonWidth;

            UpdateTextPosition();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetHeight(int height)
        {
            m_ButtonHeight = height;

            m_ButtonRectangle.Height  = m_ButtonHeight;
            m_BoarderRectangle.Height = m_ButtonHeight;

            UpdateTextPosition();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetBackgroundColor(Color backgroundColor)
        {
            m_DefaultBackgroundColor = backgroundColor;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetClickedColor(Color clickColor)
        {
            m_ClickColor = clickColor;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetHoverColor(Color hoverColor)
        {
            m_HoverColor = hoverColor;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public bool Hovering
        {
            get
            {
                return m_Hovering;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public bool MouseLeftClicked
        {
            get
            {
                return m_LeftClicked;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public bool MouseLeftHeld
        {
            get
            {
                return m_LeftHeld;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public bool MouseRightClicked
        {
            get
            {
                return m_RightClicked;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public bool MouseRightHeld
        {
            get
            {
                return m_RightHeld;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public string Text
        {
            get
            {
                return m_ButtonText;
            }
        }

    }
}
