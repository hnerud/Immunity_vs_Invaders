using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Engine.Input;

namespace Immunity_vs_Invaders
{
    class PlayerManager
    {
        List<PlayerCharacter> _players = new List<PlayerCharacter>();
        TextureManager _textureManager;
        Input _input;

        public List<PlayerCharacter> PlayerList
        {
            get
            {
                return _players;
            }
        }

        public PlayerManager(TextureManager textureManager)
        {
            _textureManager = textureManager;
           
            

            PlayerCharacter player = new PlayerCharacter(_textureManager, _input);
            _players.Add(player);
        }

        public void Update(double elapsedTime)
        {
            _players.ForEach(x => x.Update(elapsedTime));


            //CheckForOutOfBounds();
        }
        //private void CheckForOutOfBounds()
        //{
        //    foreach (PlayerCharacter player in _players)
        //    {
        //        if (player.GetBoundingBox().Right < _leftBound)
        //        {
        //            enemy.Health = 0;
        //        }
        //    }
        //}

        public void Render(Renderer renderer)
        {
            _players.ForEach(x => x.Render(renderer));

        }

        //private void RemoveDeadEnemies()
        //{
        //    for (int i = _enemies.Count - 1; i >= 0; i--)
        //    {
        //        if (_enemies[i].IsDead)
        //        {
        //            _enemies.RemoveAt(i);
        //        }
        //    }
        //}
    }
}


