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
    class InnerGameState : IGameObject
    {
        Renderer _renderer = new Renderer();
        Input _input;
        StateSystem _system;
        PersistentGameData _gameData;
        Font _generalFont;
        Level _level;
        TextureManager _textureManager;

        double _gameTime;

        public InnerGameState(StateSystem system, Input input, TextureManager textureManager, PersistentGameData gameData, Font generalFont)
        {
            _input = input;
            _system = system;
            _gameData = gameData;
            _generalFont = generalFont;
            _textureManager = textureManager;
            OnGameStart();
        }

        public void OnGameStart()
        {
            _level = new Level(_input, _textureManager, _gameData);
            _gameTime = _gameData.CurrentLevel.Time;
            
        }
        void IGameObject.Render()
        {
            Gl.glClearColor(1, 1, 1, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _level.Render(_renderer); //this is key!
            _renderer.Render();
          
        }

        void IGameObject.Update(double elapsedTime)
        {
            _level.Update(elapsedTime);
            _gameTime -= elapsedTime;

            if (_gameTime <= 0)
            {
                OnGameStart();
                _gameData.JustWon = true;
                _system.ChangeState("game_over");
            }
        }
    }
}
