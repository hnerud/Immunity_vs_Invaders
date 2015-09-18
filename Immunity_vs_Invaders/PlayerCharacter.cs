using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Engine.Input;
using Tao.OpenGl;
using System.Windows.Forms;
using System.Drawing;

namespace Immunity_vs_Invaders
{
    class PlayerCharacter:Entity
    {
       //Sprite _phagocyte = new Sprite();
        double _speed = 512;
        Input _input;
        
        double _scale = 2;

        

        int i = 0;
        public void Move(Vector amount)
        {


            amount *= _speed;

            _sprite.SetPosition(_sprite.GetPosition() + amount);


        }



        public PlayerCharacter(TextureManager textureManager, Input input)
        {
           _input = input;
            _sprite.Texture = textureManager.Get("phagocyte");
            _sprite.SetScale(_scale, _scale);
            




        }
        public void Render(Renderer renderer)
        {
            Render_Debug(0, 1, 0);
            renderer.DrawSprite(_sprite);
            

        }

        public void Update(double elapsedTime)
        {
            
        }

       

        internal void OnCollision(Enemy enemy)
        {

        }
       

     

     

    }

}

