using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoUI
{
    public class Game1 : Game
    {
        static private GraphicsDeviceManager m_Graphics;
        private SpriteBatch m_SpriteBatch;
        private UIManager m_UIManager;

        public static int m_ScreenWidth = 1000;
        public static int m_ScreenHeight = 720;
        public static GraphicsDevice m_MainGraphicsDevice;
        public static KeyboardState m_KeyboardStateOld;
        public static MouseState m_MouseStateOld;
        public static GamePadState m_GamepadStateOld;
        public static SpriteFont m_Font;
        public static Texture2D m_DebugTexture;



        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        public Game1()
        {
            m_Graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        protected override void Initialize()
        {
            // Set Window size
            m_Graphics.GraphicsProfile = GraphicsProfile.HiDef;
            m_Graphics.PreferredBackBufferWidth = m_ScreenWidth;
            m_Graphics.PreferredBackBufferHeight = m_ScreenHeight;
            m_Graphics.ApplyChanges();

            base.Initialize();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        protected override void LoadContent()
        {
            m_SpriteBatch = new SpriteBatch(GraphicsDevice);

            m_MainGraphicsDevice = GraphicsDevice;
            m_Font = Content.Load<SpriteFont>("font");

            m_DebugTexture = new Texture2D(GraphicsDevice, 1, 1);
            m_DebugTexture.SetData<Color>(new Color[] { Color.White });

            m_UIManager = new UIManager();
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        protected override void UnloadContent()
        {
        }

        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState       = Mouse.GetState();
            GamePadState gamepadState   = GamePad.GetState(PlayerIndex.One);

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            m_UIManager.Update(gameTime);

            m_KeyboardStateOld = keyboardState;
            m_MouseStateOld    = mouseState;
            m_GamepadStateOld  = gamepadState;

            base.Update(gameTime);
        }


        // ---------------------------------------------------------------------
        // ---------------------------------------------------------------------
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            m_SpriteBatch.Begin();

            m_UIManager.Draw(m_SpriteBatch);

            m_SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
