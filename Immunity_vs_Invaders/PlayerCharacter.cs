using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Engine.Input;
using Tao.OpenGl;
using System.Windows.Forms;

namespace Immunity_vs_Invaders
{
    class PlayerCharacter
    {
        Sprite _phagocyte = new Sprite();
        double _speed = 512;
        Input _input;
        Level _level;
        int i = 0;
        
        


        public PlayerCharacter(TextureManager textureManager, Input input)
        {
           _input = input;
            _phagocyte.Texture = textureManager.Get("phagocyte");
            _phagocyte.SetScale(2, 2);
            




        }
        public void Render(Renderer renderer)
        {
            renderer.DrawSprite(_phagocyte);

        }

        public void Update(double elapsedTime)
        {
            // used to get times?  ADDED
        }

       

        public void Move(Vector amount)
        {


             amount *= _speed;
            _phagocyte.SetPosition(_phagocyte.GetPosition() + amount);

            //_phagocyte.SetPosition(_phagocyte.GetPosition() + amount);


        }
       

    }

}

