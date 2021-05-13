using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoUI
{
    class Stack : IUIBase
    {
        private Vector2 m_BeginningPosition;
        private Vector2 m_EndingPosition;

        private bool m_Horizontal;

        private List<IUIBase> m_Children;
        private int m_ChildCount;

        private int m_Padding;

        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Stack()
        {
            m_BeginningPosition = new Vector2();
            m_EndingPosition    = new Vector2();

            m_Horizontal = true;

            m_Padding = 0;

            m_Children = new List<IUIBase>();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void Update()
        {
            for (int x=0; x < m_ChildCount; ++x)
            {
                IUIBase currentChild = m_Children[x];
                currentChild.Update();
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int x=0; x < m_ChildCount; ++x)
            {
                IUIBase currentChild = m_Children[x];
                currentChild.Draw(spriteBatch);
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override void SetPosition(Vector2 position)
        {
            m_BeginningPosition = position;
            m_EndingPosition    = m_BeginningPosition;

            UpdateChildPositions();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetWidth()
        {
            return (int)(m_EndingPosition.X - m_BeginningPosition.X);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public override int GetHeight()
        {
            return (int)(m_EndingPosition.Y - m_BeginningPosition.Y);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void AddChild(IUIBase child)
        {
            child.SetPosition(m_EndingPosition);
            
            m_Children.Add(child);
            m_ChildCount++;

            if (m_Horizontal)
            {
                m_EndingPosition += new Vector2(child.GetWidth() + m_Padding, 0);
            }
            else
            {
                m_EndingPosition += new Vector2(0, child.GetHeight() + m_Padding);
            }
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetHorizontal(bool isHorizontal)
        {
            m_Horizontal = isHorizontal;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void SetPadding(int padding)
        {
            m_Padding = padding;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        private void UpdateChildPositions()
        {
            for (int x=0; x < m_ChildCount; ++x)
            {
                IUIBase child = m_Children[x];
                child.SetPosition(m_EndingPosition);
            
                if (m_Horizontal)
                {
                    m_EndingPosition += new Vector2(child.GetWidth() + m_Padding, 0);
                }
                else
                {
                    m_EndingPosition += new Vector2(0, child.GetHeight() + m_Padding);
                }
            }
        }

    }
}
