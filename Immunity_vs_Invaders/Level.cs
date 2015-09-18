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
       
        TextureManager _textureManager;

        

        static readonly double Recovery = 3;
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

        }

        public void Update(double elapsedTime, double gameTime)
        {
            _recoveryTime = Math.Max(0, (_recoveryTime - elapsedTime));
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
                if (_input.Keyboard.IsKeyPressed(Keys.Space))
                {

                    Recover();
                    //_playerList.Add(new PlayerCharacter(_textureManager, _input));

                }
            }


                foreach (PlayerCharacter p in _playerManager.PlayerList )
                {

                    Console.WriteLine(_playerManager.PlayerList.Count);

               
                    p.Move(controlInput * elapsedTime);
                

                    p.Update(elapsedTime);

                }



            _enemyManager.Update(elapsedTime, gameTime);

            UpdateCollisions();

        }


        

       

        public void Render(Renderer renderer)
        {

            _playerManager.Render(renderer);
            _enemyManager.Render(renderer);

        }

        //public bool EnemyOverrun() // needs to iterate over enemys??
        //{
        //    return enemy.Overrun;

        //}

        private void UpdateCollisions()
        {
            foreach (PlayerCharacter playerCharacter in _playerManager.PlayerList) 
            {
                foreach (Enemy enemy in _enemyManager.EnemyList)
                {
                    if (playerCharacter.GetBoundingBox().IntersectsWith(enemy.GetBoundingBox()))
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
                return;
            }

            else
            {
                _recoveryTime = Recovery;
            }

            _playerManager.PlayerList.Add(new PlayerCharacter(_textureManager, _input));
        }


    }
}
