using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoUI
{
    class Textblock : IUIBase
    {
        private SpriteFont m_Font;
        private Vector2 m_TextPosition;
        private Color m_TextColor;

        private string m_Text;

        private float m_TextWidth;
        private float m_TextHeight;

        private int m_WordLength;
        private int m_CharacterLength;

        private List<string> m_WordWrappingLines;
        private bool m_WordWrapping = false;
        private int m_WordWrappingWidth;


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Textblock()
        {
            m_Font = Game1.m_Font;

            m_Text = "";

            m_TextColor = Color.White;

            m_WordWrappingLines = new List<string>();

            m_TextWidth = 0;
            m_TextHeight = 0;
            m_WordLength = 0;
            m_CharacterLength = 0;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Textblock(SpriteFont font)
        {
            m_Font = font;

            m_Text = "";

            m_TextColor = Color.White;

            m_WordWrappingLines = new List<string>();

            m_TextWidth = 0;
            m_TextHeight = 0;
            m_WordLength = 0;
            m_CharacterLength = 0;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Textblock(string text)
        {
            m_Font = Game1.m_Font;

            m_WordWrappingLines = new List<string>();

            m_TextPosition = new Vector2();

            m_TextColor = Color.White;

            m_Text = text;

            CalculateTextProperties();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Textblock(Vector2 position, string text = "")
        {
            m_Font = Game1.m_Font;

            m_WordWrappingLines = new List<string>();

            m_TextColor = Color.White;

            m_TextPosition = position;

            m_Text = text;

            CalculateTextProperties();
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
            if (m_WordWrapping)
            {
                int lineCount = m_WordWrappingLines.Count;
                for (int x=0; x < lineCount; ++x)
                {
                    spriteBatch.DrawString(m_Font, m_WordWrappingLines[x], m_TextPosition + new Vector2(0, x * m_TextHeight), m_TextColor);
                }
            }
            else
            {
                spriteBatch.DrawString(m_Font, m_Text, m_TextPosition, m_TextColor);
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void SetPosition(Vector2 position)
        {
            m_TextPosition = position;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetWidth()
        {
            return m_WordWrapping ? m_WordWrappingWidth : (int)m_TextWidth;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetHeight()
        {
            if (m_WordWrapping)
            {
                return m_WordWrappingLines.Count * (int)m_TextHeight;
            }

            return (int)m_TextHeight;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        private void CalculateTextProperties()
        {
            Vector2 textSize = Game1.m_Font.MeasureString(m_Text);

            m_TextWidth  = textSize.X;
            m_TextHeight = textSize.Y;

            m_WordLength = m_Text.Split(' ').Length;
            m_CharacterLength = m_Text.Length;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        private void SetWordWrappingLines()
        {
            string[] textByWord = m_Text.Split(' ');
            string currentLine  = "";

            m_WordWrappingLines.Clear();

            for (int x=0; x < m_WordLength; ++x)
            {
                string currentWord = textByWord[x];

                if (m_Font.MeasureString(currentLine).X + m_Font.MeasureString(currentWord).X <= m_WordWrappingWidth)
                {
                    currentLine += currentWord + " ";
                }
                else
                {
                    m_WordWrappingLines.Add(currentLine);

                    currentLine = currentWord + " ";
                }
            }

            m_WordWrappingLines.Add(currentLine);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetText(string text)
        {
            m_Text = text;

            CalculateTextProperties();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetTextColor(Color color)
        {
            m_TextColor = color;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetWordWrapping(bool wordWrap, int wrappingWidth = 50)
        {
            m_WordWrapping = wordWrap;

            if (m_WordWrapping)
            {
                m_WordWrappingWidth = wrappingWidth;

                SetWordWrappingLines();
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetWordWrappingWidth(int wrappingWidth)
        {
            m_WordWrapping = true;

            m_WordWrappingWidth = wrappingWidth;
            
            SetWordWrappingLines();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public string Text
        {
            get
            {
                return m_Text;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public float Width
        {
            get
            {
                return m_TextWidth;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public float Height
        {
            get
            {
                return m_TextHeight;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public int WordCount
        {
            get
            {
                return m_WordLength;
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public int CharacterCount
        {
            get
            {
                return m_CharacterLength;
            }
        }


    }
}
