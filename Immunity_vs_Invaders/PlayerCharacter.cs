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
    class PlayerCharacter
    {
        Sprite _phagocyte = new Sprite();
        double _speed = 512;

        public PlayerCharacter(TextureManager textureManager)
        {
            _phagocyte.Texture = textureManager.Get("phagocyte");
            _phagocyte.SetScale(2, 2);
        }
        public void Render(Renderer renderer)
        {
            renderer.DrawSprite(_phagocyte);
           
            
        }
        public void Move(Vector amount)
        {
           
            _phagocyte.SetPosition(_phagocyte.GetPosition() + amount);
        }
    }
}
