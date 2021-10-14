using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using System;

namespace ExtendedInput
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // First we declare some Listener Objects
        private readonly GamePadListener _gamePadListener1;
        private readonly GamePadListener _gamePadListener2;
        private readonly KeyboardListener _keyboardListener;
        private readonly MouseListener _mouseListener;

        // Then we declare some listner settings things that can
        // be used to instantiate the listener objects mentioned above.
        private GamePadListenerSettings gplsobj1;
        private GamePadListenerSettings gplsobj2;
        private KeyboardListenerSettings kblsobj;
        private MouseListenerSettings mlsobj;





        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;



            gplsobj1 = new GamePadListenerSettings(PlayerIndex.One);
            gplsobj2 = new GamePadListenerSettings(PlayerIndex.Two);
            kblsobj = new KeyboardListenerSettings();
            mlsobj = new MouseListenerSettings();
            _gamePadListener1 = new GamePadListener(gplsobj1);
            _gamePadListener2 = new GamePadListener(gplsobj2);
            _keyboardListener = new KeyboardListener(kblsobj);
            _mouseListener = new MouseListener(mlsobj);
            Components.Add(new InputListenerComponent(this, _gamePadListener1));
            Components.Add(new InputListenerComponent(this, _gamePadListener2));
            Components.Add(new InputListenerComponent(this, _keyboardListener));
            Components.Add(new InputListenerComponent(this, _mouseListener));


        }

        public void handleButtonDownInput(Object sender, GamePadEventArgs args)
        {
            System.Console.WriteLine(args.Button.ToString());
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _gamePadListener1.ButtonDown += handleButtonDownInput;
            // _gamePadListener1.ButtonUp += handle game pad button up input
            // How would you bind four smash bros to 4 controllers?

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
