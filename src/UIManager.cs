using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoUI
{
    public class UIManager
    {
        Textblock m_HeaderTextblock;
        Textblock m_SampleTextblock;
        Textblock m_WrappingTextblock;
        Textblock m_DescriptionTextblock;

        Button m_StandAloneButton1;
        Button m_StandAloneButton2;

        Box m_Box;

        DividerLine m_HorizontalDividerLine;
        DividerLine m_VerticalDividerLine;

        Textblock m_CheckboxLabelTextblock;
        Checkbox m_Checkbox;

        Stack m_HorizontalStackExample;
        Stack m_VerticalStackExample;
        Stack m_StackWithinStackExample;


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public UIManager()
        {
            // Textblock Example - Main Header
            m_HeaderTextblock = new Textblock("Welcome to MonoUI");
            m_HeaderTextblock.SetPosition(new Vector2( (Game1.m_ScreenWidth/2) - (m_HeaderTextblock.GetWidth()/2), 10));
            m_HeaderTextblock.SetTextColor(Color.Black);

            // Dividerline Example - Horizontal
            m_HorizontalDividerLine = new DividerLine();
            m_HorizontalDividerLine.SetPosition(new Vector2(10, 40));
            m_HorizontalDividerLine.SetColor(Color.Black);
            m_HorizontalDividerLine.SetLength(980);
            m_HorizontalDividerLine.SetThickness(2);
            m_HorizontalDividerLine.SetIsHorizontal(true);

            // Textblock Example - Single line no wrapping
            m_SampleTextblock = new Textblock(new Vector2(25,50), "Here are some stand alone UI elements.");
            m_SampleTextblock.SetTextColor(Color.Black);

            // Textblock Example - Multiline wrapping paragraph
            m_DescriptionTextblock = new Textblock();
            m_DescriptionTextblock.SetText("All of these UI elements on the left side of the screen have been hard coded into to a specific position. Sometimes thats what you need, so it is important to have this functionality.");
            m_DescriptionTextblock.SetTextColor(Color.Black);
            m_DescriptionTextblock.SetPosition(new Vector2(25, 75));
            m_DescriptionTextblock.SetWordWrapping(true, 100);
            m_DescriptionTextblock.SetWordWrappingWidth(250);

            // Textblock Example - Single line no wrapping
            m_CheckboxLabelTextblock = new Textblock();
            m_CheckboxLabelTextblock.SetText("Below are some common UI elements.");
            m_CheckboxLabelTextblock.SetTextColor(Color.Black);
            m_CheckboxLabelTextblock.SetPosition(new Vector2(25, 200));

            //Button Example - Instantiate all button properties in constructor
            m_StandAloneButton1 = new Button(new Vector2(25, 250), 200, 30, Color.DarkGray, "Button 1", Color.Black);

            // Button Example - Instantiate all button properties individually through methods
            m_StandAloneButton2 = new Button();
            m_StandAloneButton2.SetText("Button 2");
            m_StandAloneButton2.SetPosition(new Vector2(25, 300));
            m_StandAloneButton2.SetWidth(200);
            m_StandAloneButton2.SetHeight(50);
            m_StandAloneButton2.SetBackgroundColor(Color.Green);
            m_StandAloneButton2.SetTextColor(Color.White);
            m_StandAloneButton2.SetClickedColor(Color.Purple);
            m_StandAloneButton2.SetHoverColor(Color.Blue);

            // Checkbox Example
            m_Checkbox = new Checkbox(new Vector2(25, 375));
            m_Checkbox.SetActive(true);

            // Box Example
            m_Box = new Box(new Rectangle(25, 425, 75, 75));
            m_Box.SetColor(Color.Gold);

            // Textblock Example - Multiline wrapping paragraph
            m_WrappingTextblock = new Textblock();
            m_WrappingTextblock.SetText("This is a long paragraph full of words. Hopefully I spelled everything correctly. This is supposed to show that you can create word wrapping paragraphs instead of a single continuous line of text. Note that you can change pretty much all of the properties for each of the UI types. For instance, I have changed the color of the text in this Textblock to blue.");
            m_WrappingTextblock.SetTextColor(Color.Blue);
            m_WrappingTextblock.SetPosition(new Vector2(25, 510));
            m_WrappingTextblock.SetWordWrapping(true, 100);
            m_WrappingTextblock.SetWordWrappingWidth(250);

            // Vertical Divider Line Example
            m_VerticalDividerLine = new DividerLine();
            m_VerticalDividerLine.SetPosition(new Vector2(325, 50));
            m_VerticalDividerLine.SetColor(Color.Black);
            m_VerticalDividerLine.SetLength(650);
            m_VerticalDividerLine.SetThickness(2);
            m_VerticalDividerLine.SetIsHorizontal(false);

            // Stack - Horizontal example
            Textblock horizontalStackText1 = new Textblock();
            horizontalStackText1.SetText("All UI elements on the right side of the screen show off the power of the Stack.");
            horizontalStackText1.SetTextColor(Color.Black);
            horizontalStackText1.SetWordWrapping(true);
            horizontalStackText1.SetWordWrappingWidth(150);

            Textblock horizontalStackText2 = new Textblock();
            horizontalStackText2.SetText("The Stack type allows the user to dynamically add UI elements, and let the Stack figure out how they should be aligned.");
            horizontalStackText2.SetTextColor(Color.Black);
            horizontalStackText2.SetWordWrapping(true);
            horizontalStackText2.SetWordWrappingWidth(150);

            Textblock horizontalStackText3 = new Textblock();
            horizontalStackText3.SetText("The user lets the Stack know if it should be horizontally or vertically aligned. From there, the Stack calculates how to align everything.");
            horizontalStackText3.SetTextColor(Color.Black);
            horizontalStackText3.SetWordWrapping(true);
            horizontalStackText3.SetWordWrappingWidth(150);

            Textblock horizontalStackText4 = new Textblock();
            horizontalStackText4.SetText("Note that the Stack accepts any UI type, so you are able to place Stacks within Stacks. The last example shows a Stack within a Stack within a Stack.");
            horizontalStackText4.SetTextColor(Color.Black);
            horizontalStackText4.SetWordWrapping(true);
            horizontalStackText4.SetWordWrappingWidth(150);

            m_HorizontalStackExample = new Stack();
            m_HorizontalStackExample.SetHorizontal(true);
            m_HorizontalStackExample.SetPosition(new Vector2(350, 50));
            m_HorizontalStackExample.SetPadding(5);
            m_HorizontalStackExample.AddChild(horizontalStackText1);
            m_HorizontalStackExample.AddChild(horizontalStackText2);
            m_HorizontalStackExample.AddChild(horizontalStackText3);
            m_HorizontalStackExample.AddChild(horizontalStackText4);

            // Stack - Vertical example
            Checkbox verticalCheckbox = new Checkbox();
            verticalCheckbox.SetActive(true);

            Textblock verticalStackText1 = new Textblock();
            verticalStackText1.SetText("Here is an example of a vertical stack. Note that the order you add the children is the order they display. In this example, the Textblock is added first followed by the Checkbox.");
            verticalStackText1.SetWordWrapping(true);
            verticalStackText1.SetWordWrappingWidth(625);
            verticalStackText1.SetTextColor(Color.Black);

            Textblock verticalStackText2 = new Textblock();
            verticalStackText2.SetText("The Stack keeps all items aligned. You can control the spacing between elements by setting the Stack's padding.");
            verticalStackText2.SetWordWrapping(true);
            verticalStackText2.SetWordWrappingWidth(400);
            verticalStackText2.SetTextColor(Color.Black);
            
            m_VerticalStackExample = new Stack();
            m_VerticalStackExample.SetHorizontal(false);
            m_VerticalStackExample.SetPosition(new Vector2(350, 250));
            m_VerticalStackExample.SetPadding(10);
            m_VerticalStackExample.AddChild(verticalStackText1);
            m_VerticalStackExample.AddChild(verticalCheckbox);
            m_VerticalStackExample.AddChild(verticalStackText2);

            // Stack - Multiple Stack example
            Textblock firstParagraph = new Textblock();
            firstParagraph.SetText("This example will show how you can place Stacks within Stacks within Stacks. Here we have a horizontal Stack with a vertical Stack in it. The vertical Stack has a horizontal Stack within it. The Stack class is able to manage it all.");
            firstParagraph.SetWordWrapping(true);
            firstParagraph.SetWordWrappingWidth(250);
            firstParagraph.SetTextColor(Color.Black);

            Textblock secondParagraph = new Textblock();
            secondParagraph.SetText("Here is the first vertical paragraph. Under it will be another Textblock followed by a horizontal Stack.");
            secondParagraph.SetWordWrapping(true);
            secondParagraph.SetWordWrappingWidth(300);
            secondParagraph.SetTextColor(Color.Black);

            Textblock thirdParagraph = new Textblock();
            thirdParagraph.SetText("Here is the second vertical paragraph. Lets make it purple for fun. Also, check out how big the padding is between vertical elements.");
            thirdParagraph.SetWordWrapping(true);
            thirdParagraph.SetWordWrappingWidth(200);
            thirdParagraph.SetTextColor(Color.Purple);

            Checkbox horizontalCheckbox = new Checkbox();
            horizontalCheckbox.SetActive(true);
            
            Button stackButton = new Button();
            stackButton.SetText("Stack within Stack within Stack");
            stackButton.SetWidth(300);
            stackButton.SetHeight(25);
            stackButton.SetBackgroundColor(Color.Black);
            stackButton.SetTextColor(Color.White);
            stackButton.SetClickedColor(Color.Red);
            stackButton.SetHoverColor(Color.Blue);
            
            Stack internalStack2 = new Stack();
            internalStack2.SetHorizontal(true);
            internalStack2.SetPadding(15);
            internalStack2.AddChild(horizontalCheckbox);
            internalStack2.AddChild(stackButton);

            Stack internalStack1 = new Stack();
            internalStack1.SetHorizontal(false);
            internalStack1.SetPadding(50);
            internalStack1.AddChild(secondParagraph);
            internalStack1.AddChild(thirdParagraph);
            internalStack1.AddChild(internalStack2);

            m_StackWithinStackExample = new Stack();
            m_StackWithinStackExample.SetHorizontal(true);
            m_StackWithinStackExample.SetPosition(new Vector2(350, 400));
            m_StackWithinStackExample.SetPadding(10);
            m_StackWithinStackExample.AddChild(firstParagraph);
            m_StackWithinStackExample.AddChild(internalStack1);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void Update(GameTime gameTime)
        {
            m_StandAloneButton1.Update(); 
            m_StandAloneButton2.Update();
            m_Checkbox.Update();
            m_HorizontalStackExample.Update();
            m_VerticalStackExample.Update();
            m_StackWithinStackExample.Update();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public void Draw(SpriteBatch spriteBatch)
        {
            m_HeaderTextblock.Draw(spriteBatch);
            m_HorizontalDividerLine.Draw(spriteBatch);
            m_SampleTextblock.Draw(spriteBatch);
            m_WrappingTextblock.Draw(spriteBatch);
            m_DescriptionTextblock.Draw(spriteBatch);
            m_StandAloneButton1.Draw(spriteBatch); 
            m_StandAloneButton2.Draw(spriteBatch);
            m_CheckboxLabelTextblock.Draw(spriteBatch);
            m_HorizontalStackExample.Draw(spriteBatch);
            m_VerticalStackExample.Draw(spriteBatch);
            m_StackWithinStackExample.Draw(spriteBatch);
            m_Checkbox.Draw(spriteBatch);
            m_Box.Draw(spriteBatch);
            m_VerticalDividerLine.Draw(spriteBatch);
        }

    }
}
