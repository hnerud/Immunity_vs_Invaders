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
        bool _position;
        PersistentGameData _gameData;
       
        TextureManager _textureManager;
        BloodStream _bloodstream;
        CharacterBoard _characterboard;
        

        static readonly double Recovery = 5;
        double _recoveryTime = Recovery;

       
        

        PlayerManager _playerManager;
        EnemyManager _enemyManager;

        public Level (Input input, TextureManager textureManager, PersistentGameData gameData)
        {
            _input = input;
            _gameData = gameData;
            _textureManager = textureManager;

            _playerManager = new PlayerManager(_textureManager);

            _enemyManager = new EnemyManager(_textureManager, -1300);

            _bloodstream = new BloodStream(_textureManager);

            _characterboard = new CharacterBoard(_textureManager);



        }

        public void Update(double elapsedTime, double gameTime)
        {
            _recoveryTime = Math.Max(0, (_recoveryTime - elapsedTime));

            ColorGauge();


            //is this best spot???
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
              
            }

            if (_input.Mouse.LeftPressed)
            {
                _position = true;
                Recover();
               

            }



            for (int i = 0; i <= _playerManager.PlayerList.Count - 1; i++)
            {
                if (i == _playerManager.PlayerList.Count - 1)
                {
                    _playerManager.PlayerList[i].Move(controlInput * elapsedTime, false);
                }
                else
                {
                    _playerManager.PlayerList[i].Move(controlInput * elapsedTime, true);
                }

                _playerManager.PlayerList[i].Update(elapsedTime);

            }
              



            _enemyManager.Update(elapsedTime, gameTime);

            UpdateCollisions();
            UpdateEnemyProgress();

        }


        

       

        public void Render(Renderer renderer)
        {

            _playerManager.Render(renderer);
            _enemyManager.Render(renderer);
            _bloodstream.Render(renderer);
            _characterboard.Render(renderer);
            

        }

       public bool HasBloodstreamDied() // needs to iterate over enemys??
        {
           return _bloodstream.IsDead;

       }

        private void UpdateEnemyProgress()
        {
            foreach (Enemy enemy in _enemyManager.EnemyList)
            {
                if (enemy.GetBoundingBox(.65,.65).IntersectsWith(_bloodstream.GetBoundingBox(.65,7)))
                {
                    enemy.OnCollision(_bloodstream);
                    _bloodstream.OnCollision(enemy);
                }
            }
        }

        private void UpdateCollisions()
        {
            foreach (PlayerCharacter playerCharacter in _playerManager.PlayerList) 
            {
                foreach (Enemy enemy in _enemyManager.EnemyList)
                {
                    if (playerCharacter.GetBoundingBox(.65, .65).IntersectsWith(enemy.GetBoundingBox(.65,.65)))
                    {
                        playerCharacter.OnCollision(enemy);
                        enemy.OnCollision(playerCharacter);
                    }
                }
            }

        }

        public void Recover()
        {
            if (_recoveryTime > 0)
            {
                _characterboard.ChangeColor(1,1,1,0);
                return;
            }

            else
            {
                _recoveryTime = Recovery;
                _characterboard.ChangeColor(1,1,1,1);
            }

            _playerManager.PlayerList.Add(new PlayerCharacter(_textureManager, _input, _position));
        }

        public void ColorGauge()
        {
            if (_recoveryTime > 0)
            {
                _characterboard.ChangeColor(0, 0, 0, 1);
                
            }

            else
            {
                _characterboard.ChangeColor(1, 1, 1, 1);
            }
        }




    }
}
