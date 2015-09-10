using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Engine.Input;
using Tao.OpenGl;

namespace Immunity_vs_Invaders
{
    class StartMenuState:IGameObject
    {
        Renderer _renderer = new Renderer();
        Text _title;

        StateSystem _system;
        Engine.Font _generalFont;
        Input _input;
        VerticalMenu _menu;


        public StartMenuState(Engine.Font titleFont, Engine.Font generalFont, Input input, StateSystem system)
        {
            _system = system;
            _input = input;
            _generalFont = generalFont;
            InitializeMenu();

            _title = new Text("Immunity vs. Invaders", titleFont);
            _title.SetColor(new Color(0, 0, 0, 1));
            
            _title.SetPosition(-_title.Width / 2, 300);
        }

        private void InitializeMenu()
        {
            _menu = new VerticalMenu(0, 150, _input);
            Button startGame = new Button(
                delegate (object o, EventArgs e)
                {
                    _system.ChangeState("inner_game");

                },
                new Text("Start", _generalFont));

            Button exitGame = new Button(
                delegate (object o, EventArgs e)
                {
                    System.Windows.Forms.Application.Exit();

                },
                new Text("Exit", _generalFont));

            _menu.AddButton(startGame);
            _menu.AddButton(exitGame);
        }

        void IGameObject.Render()
        {
            Gl.glClearColor(1, 1, 1, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawText(_title);
            _menu.Render(_renderer);
            _renderer.Render();

        }

        void IGameObject.Update(double elapsedTime)
        {
            _menu.HandleInput();
        }
    }
}
