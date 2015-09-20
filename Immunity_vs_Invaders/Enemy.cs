using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using System.Drawing;

namespace Immunity_vs_Invaders
{
    class Enemy:Entity
    {
        
        //Sprite _tatoo = new Sprite();
        double _scale = 2.0;
        bool _overrun = false;

        int x = 200;
        int y = 0;
        public int Health { get; set; }

        public bool IsDead
        {
            get { return Health == 0; }
        }

      

        public Enemy (TextureManager textureManager)
        {
            Health = 50;
            _sprite.Texture = textureManager.Get("tatoo_dye");
            _sprite.SetScale(_scale, _scale);
            _sprite.SetPosition(x, y);


        }
        public void Update(double elapsed)
        {

        }
        public void Render(Renderer renderer)
        {
            renderer.DrawSprite(_sprite);
            Render_Debug(1, 0, 0, .65, .65);
        }

       

        internal void OnCollision (PlayerCharacter playercharacter)
        {
            

            _sprite.SetPosition(_sprite.GetPosition().X + 100, _sprite.GetPosition().Y);

            
            
        }

        internal void OnCollision(BloodStream bloodstream)
        {
            _overrun = true;

        }

        internal void SetPosition(Vector position)
        {
            _sprite.SetPosition(position);
        }



    }
}
