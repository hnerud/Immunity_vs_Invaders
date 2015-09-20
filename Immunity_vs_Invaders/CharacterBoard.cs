using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Immunity_vs_Invaders
{
    class CharacterBoard
    {
        Sprite _phagocyte = new Sprite();

        Renderer _renderer = new Renderer();
        Level _level;

        public CharacterBoard(TextureManager textureManager)
        {
            
            _phagocyte.Texture = textureManager.Get("phagocyte");
            //_phagocyte.SetScale(2, 2);
            _phagocyte.SetPosition(0, 325);
           //_phagocyte.SetColor(new Color(1, 1, 1, 0));

        }

        public void Update(double elapsed)
        {

        }
        public void Render(Renderer renderer)
        {
          
            renderer.DrawSprite(_phagocyte);

        }

        public void ChangeColor(int x, int y, int z, int a)
        {
            
            _phagocyte.SetColor(new Color(x, y, z, a));
        }



    }
    }
