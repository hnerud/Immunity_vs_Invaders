﻿using System;
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
        Sprite _character1 = new Sprite();
        Sprite _invader1 = new Sprite();
        Sprite _invader2 = new Sprite();
        Renderer _renderer = new Renderer();
        Text _title;
        SoundManager _soundManager;
        double _count = 3;
        PreciseTimer _time = new PreciseTimer();

        public SplashScreenState(StateSystem system, TextureManager textureManager, Engine.Font titleFont, SoundManager soundManager)
        {
            _system = system;

            //sound
            _soundManager = soundManager;
            _soundManager.MasterVolume(0.01f);

            //title font
            _title = new Text("Immune Cells vs. Invaders", titleFont);
            _title.SetColor(new Color(0, 0, 0, 1));
            _title.SetPosition(-_title.Width / 2, 300);

            // good guys
            _character1.Texture = textureManager.Get("phagocyte");
            _character1.SetScale(2, 2);
            _character1.SetPosition(-150, 100);

            //bad guys
            _invader1.Texture = textureManager.Get("tatoo_dye");
            _invader1.SetScale(2, 2);
            _invader1.SetPosition(200, 100);

            _invader2.Texture = textureManager.Get("parasite");
            _invader2.SetScale(2, 2);
            _invader2.SetPosition(200, 0);

           // _soundManager.PlaySound("intro_music");

        }
        void IGameObject.Render()
        {
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawText(_title);
            _renderer.DrawSprite(_character1);
            _renderer.DrawSprite(_invader1);
            _renderer.DrawSprite(_invader2);
            _renderer.Render();

            
            //Gl.glFinish();


        }

        void IGameObject.Update(double elapsedTime)
        {
           

            _count -= elapsedTime;
            if (_count <= 0)
            {
                _count = 3;
                _system.ChangeState("start_menu");
            }


        }

    }
}
