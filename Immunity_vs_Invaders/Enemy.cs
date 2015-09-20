using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using System.Drawing;

namespace Immunity_vs_Invaders
{
    public class Enemy:Entity
    {
        
        Sprite _tatoo = new Sprite();
        double _scale = 2.0;


        static readonly double HitFlashTime = 0.25;
        double _hitFlashCountDown = 0;

        int x = 200;
        int y = 0;
       

        public int Health { get; set; }

        public bool IsDead
        {
            get { return Health == 0; }
        }

        public Path Path { get; set; }

      

        public Enemy (TextureManager textureManager)
        {
            Health = 50;
            _sprite.Texture = textureManager.Get("tatoo_dye");
            _sprite.SetScale(_scale, _scale);
            _sprite.SetPosition(x, y);


        }
        public void Update(double elapsedTime)
        {
            if (Path != null)
            {
                Path.UpdatePosition(elapsedTime, this);
            }
            if (_hitFlashCountDown != 0)
            {
                _hitFlashCountDown = Math.Max(0, _hitFlashCountDown - elapsedTime);
                double scaledTime = 1 - (_hitFlashCountDown / HitFlashTime);
                _sprite.SetColor(new Engine.Color(1, 1, (float)scaledTime, 1));
            }

        }
        public void Render(Renderer renderer)
        {
            renderer.DrawSprite(_sprite);
            Render_Debug(1, 0, 0, .65, .65);
        }

       

        internal void OnCollision (PlayerCharacter playercharacter)
        {

           
            


            Health = Health - 5;

           //_sprite.SetPosition(_sprite.GetPosition().X -1000, _sprite.GetPosition().Y);

            
            
           // _sprite.SetPosition(_sprite.GetPosition().X + i, _sprite.GetPosition().Y);





        }

        internal void OnCollision(BloodStream bloodstream)
        {
           

        }

        internal void SetPosition(Vector position)
        {
            _sprite.SetPosition(position);
            
        }

        


    }
}
