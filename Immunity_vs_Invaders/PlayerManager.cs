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
        bool _position;
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
           
            

            PlayerCharacter player = new PlayerCharacter(_textureManager, _input, _position);
            _players.Add(player);
        }

        public void Update(double elapsedTime)
        {
            _players.ForEach(x => x.Update(elapsedTime));


           
        }
        

        public void Render(Renderer renderer)
        {
            _players.ForEach(x => x.Render(renderer));

        }

       

    }
}


