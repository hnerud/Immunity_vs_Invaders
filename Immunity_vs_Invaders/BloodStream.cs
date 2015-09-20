using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Immunity_vs_Invaders
{
    class BloodStream:Entity
    {
       
        Renderer _renderer = new Renderer();

        bool _dead = false;

        public bool IsDead
        {
            get
            {
                return _dead;
            }
        }

        public BloodStream(TextureManager textureManager)
        {
            _sprite.Texture = textureManager.Get("blood_cells");
            _sprite.SetScale(2, 2);
            _sprite.SetPosition(-500, 0);

        }

        public void Update(double elapsed)
        {

        }
        public void Render(Renderer renderer)
        { 
            Render_Debug(0, 0, 1, .65, 7);
            renderer.DrawSprite(_sprite);
            
        }


        internal void OnCollision(Enemy enemy)
        {
           

        }
    }
}
