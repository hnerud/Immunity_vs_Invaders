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
        Renderer _renderer;

        public Level (Input input, TextureManager textureManager, PersistentGameData gameData)
        {
            _input = input;
            _gameData = gameData;
            _textureManager = textureManager;
            _playerCharacter = new PlayerCharacter(_textureManager, _input);
        }

        public void Update(double elapsedTime)
        {
            // Get controls and apply to player character
            double _x = _input.Controller.LeftControlStick.X;
            double _y = _input.Controller.LeftControlStick.Y * -1;
            Vector controlInput = new Vector(_x, _y, 0);

            if (Math.Abs(controlInput.Length()) < 0.0001)
            {
                // If the input is very small, then the player may not be using 
                // a controller;, they might be using the keyboard.
                if (_input.Keyboard.IsKeyHeld(Keys.Left))
                {
                    controlInput.X = -1;
                }

                if (_input.Keyboard.IsKeyHeld(Keys.Right))
                {
                    controlInput.X = 1;
                }

                if (_input.Keyboard.IsKeyHeld(Keys.Up))
                {
                    controlInput.Y = 1;
                }

                if (_input.Keyboard.IsKeyHeld(Keys.Down))
                {
                    controlInput.Y = -1;
                }
                if (_input.Keyboard.IsKeyPressed(Keys.Space))
                {
                    Render(_renderer);

                }
            }

            _playerCharacter.Move(controlInput * elapsedTime);



             
        }
        public void Render(Renderer renderer)
        {
            _playerCharacter.Render(renderer);

        }
    }
}
