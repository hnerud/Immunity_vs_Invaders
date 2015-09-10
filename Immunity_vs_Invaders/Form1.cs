using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;
using Engine.Input;
using Tao.OpenGl;
using Tao.DevIl;


namespace Immunity_vs_Invaders
{
    public partial class Form1 : Form
    {

        bool            _fullscreen     = false;
        FastLoop        _fastLoop;
        StateSystem     _system         = new StateSystem();
        Input           _input          = new Input();
        TextureManager  _textureManager = new TextureManager();
        SoundManager    _soundManger    = new SoundManager();

        Engine.Font     _titleFont;
        Engine.Font     _generalFont;



        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();

            _input.Mouse = new Mouse(this, simpleOpenGlControl1);
            _input.Keyboard = new Keyboard(simpleOpenGlControl1);

            _input.Controller = new XboxController(1);

            InitializeDisplay();
            InitializeSounds();
            InitializeTextures();
            InitializeFonts();
            InitializeGameState();

            _fastLoop = new FastLoop(GameLoop);

        }

        private void InitializeGameState()
        {
            _system.AddState("splash", new SplashScreenState(_system, _textureManager, _titleFont, _soundManger));
            _system.AddState("start_menu", new StartMenuState(_titleFont, _generalFont, _input, _system));
            _system.ChangeState("splash");
           
        }
       
        private void InitializeFonts()
        {
            _titleFont = new Engine.Font(_textureManager.Get("title_font"), FontParser.Parse("fonts/title_font.fnt"));
            _generalFont = new Engine.Font(_textureManager.Get("general_font"), FontParser.Parse("fonts/general_font.fnt"));
        }

        private void InitializeTextures()
        {
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            _textureManager.LoadTexture("phagocyte", "sprites/solosis.tga");
            _textureManager.LoadTexture("tatoo_dye", "sprites/munna.tga");
            _textureManager.LoadTexture("parasite", "sprites/weedle.tga");
            _textureManager.LoadTexture("title_font", "fonts/title_font.tga");
            _textureManager.LoadTexture("general_font", "fonts/general_font.tga");
            
        }

        private void InitializeSounds()
        {
            _soundManger.LoadSound("intro_music", "sound/intromusic.wav");
            
        }

        private void InitializeDisplay()
        {
            if(_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                ClientSize = new Size(1280, 720);
            }
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
            
        }
        private void UpdateInput(double elapsedTime)
        {
            _input.Update(elapsedTime);
        }

        private void GameLoop(double elapsedTime)
        {
            UpdateInput(elapsedTime);
            _system.Update(elapsedTime);
            _system.Render();
            simpleOpenGlControl1.Refresh();
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Gl.glViewport(0, 0, this.ClientSize.Width, ClientSize.Height);
        }

        private void Setup2DGraphics(double width, double height)
        {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

    }
}
