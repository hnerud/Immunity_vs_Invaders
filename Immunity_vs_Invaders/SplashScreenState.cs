using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Tao.OpenGl;


namespace Immunity_vs_Invaders
{
    class SplashScreenState : IGameObject
    {
        StateSystem _system;
        double _delayInSeconds = 3;
        public SplashScreenState(StateSystem system)
        {
            _system = system;

        }
        void IGameObject.Render()
        {
            Gl.glClearColor(1, 0, 0, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glFinish();
        }

        void IGameObject.Update(double elapsedTime)
        {
            _delayInSeconds -= elapsedTime;
            if (_delayInSeconds <=0)
            {
                _delayInSeconds = 3;
            }
        }
    }
}
