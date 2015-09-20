using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Engine;
using System.Drawing;

namespace Immunity_vs_Invaders
{
    public class Entity
    {
        protected Sprite _sprite = new Sprite();
        double _resize = 0.65;

        int _x;
        int _y;
        int _z;



        public RectangleF GetBoundingBox(double scaleWidth, double scaleHeight)
        {
            double _scaleWidth = scaleWidth;
            double _scaleHeight = scaleHeight;
            float width = (float)(_sprite.Texture.Width *  _scaleWidth);
            float height = (float)(_sprite.Texture.Height * _scaleHeight);

            return new RectangleF((float)_sprite.GetPosition().X - width / 2,
            (float)_sprite.GetPosition().Y - height / 2,
            width, height);

        }
        protected void Render_Debug(int x, int y, int z, double scalew, double scaleh)
        {
            _x = x;
            _y = y;
            _z = z;

            double _scalew = scalew;
            double _scaleh = scaleh;



            Gl.glDisable(Gl.GL_TEXTURE_2D);

            RectangleF bounds = GetBoundingBox(_scalew, _scaleh);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            {
                Gl.glColor3f(_x, _y, _z);
                Gl.glVertex2f(bounds.Left, bounds.Top);
                Gl.glVertex2f(bounds.Right, bounds.Top);
                Gl.glVertex2f(bounds.Right, bounds.Bottom);
                Gl.glVertex2f(bounds.Left, bounds.Bottom);
            }

            Gl.glEnd();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
        }


    }


}
