using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Engine.Input;
using System.Windows.Forms;


namespace Immunity_vs_Invaders
{
    class Level
    {
        Input _input;
        PersistentGameData _gameData;
        PlayerCharacter _playerCharacter;
        TextureManager _textureManager;

        public Level (Input input, TextureManager textureManager, PersistentGameData gameData)
        {
            _input = input;
            _gameData = gameData;
            _textureManager = textureManager;
            _playerCharacter = new PlayerCharacter(_textureManager);
        }

        public void Update(double elapsedTime)
        {
            _playerCharacter.Move(_input.MousePosition.X, _input.MousePosition.Y);




         
          
        }
        public void Render(Renderer renderer)
        {
            _playerCharacter.Render(renderer);

        }
    }
}
