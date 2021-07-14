using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoUI
{
    class Checkbox : IUIBase
    {
        private Button m_MainButton;

        private bool m_Active;

        private int m_CheckboxWidth  = 25;
        private int m_CheckboxHeight = 25;


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Checkbox()
        {
            m_MainButton = new Button(new Vector2(), m_CheckboxWidth, m_CheckboxHeight, Color.White, "X", Color.Black, Game1.m_Font);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Checkbox(Vector2 position)
        {
            m_MainButton = new Button(position, m_CheckboxWidth, m_CheckboxHeight, Color.White, "X", Color.Black, Game1.m_Font);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void Update()
        {
            if (m_MainButton.MouseLeftClicked)
            {
                m_Active = !m_Active;
            }

            if (m_Active)
            {
                m_MainButton.SetText("X");
            }
            else
            {
                m_MainButton.SetText("");
            }

            m_MainButton.Update();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void Draw(SpriteBatch spriteBatch)
        {
            m_MainButton.Draw(spriteBatch);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void SetPosition(Vector2 position)
        {
            m_MainButton.SetPosition(position);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetWidth()
        {
            return m_CheckboxWidth;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetHeight()
        {
            return m_CheckboxHeight;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetActive(bool isActive)
        {
            m_Active = isActive;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public bool Active
        {
            get
            {
                return m_Active;
            }
        }

    }
}
