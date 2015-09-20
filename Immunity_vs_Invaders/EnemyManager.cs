using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Immunity_vs_Invaders
{
    class EnemyManager
    {
        List<Enemy> _enemies = new List<Enemy>();
        TextureManager _textureManager;
        int _leftBound;
       

        List<EnemyDef> _upComingEnemies = new List<EnemyDef>();
        private List<Vector> _pathPoints;
        private object enemy;

        public List<Enemy> EnemyList
        {
            get
            {
                return _enemies;
            }
        }
      

        public EnemyManager(TextureManager textureManager, int leftBound)
        {
            _textureManager = textureManager;
            _leftBound = leftBound;

            _upComingEnemies.Add(new EnemyDef("particlesMiddle", 30));
            _upComingEnemies.Add(new EnemyDef("particlesTop", 29.5));
            _upComingEnemies.Add(new EnemyDef("particlesBottom", 29));
            _upComingEnemies.Add(new EnemyDef("particlesBottomMid", 28.5));

            //_upComingEnemies.Add(new EnemyDef("particles", 25));
            //_upComingEnemies.Add(new EnemyDef("particles", 24.5));
            //_upComingEnemies.Add(new EnemyDef("particles", 24));
            //_upComingEnemies.Add(new EnemyDef("particles", 23.5));

            //_upComingEnemies.Add(new EnemyDef("particles", 19));
            //_upComingEnemies.Add(new EnemyDef("particles", 18.5));
            //_upComingEnemies.Add(new EnemyDef("particles", 20));
            //_upComingEnemies.Add(new EnemyDef("particles", 19.5));

            _upComingEnemies.Sort(delegate (EnemyDef firstEnemy, EnemyDef secondEnemy)
           {
               return firstEnemy.LaunchTime.CompareTo(secondEnemy.LaunchTime);

           });

            //Enemy enemy = new Enemy(_textureManager);
            //_enemies.Add(enemy);
        }

        private void UpdateEnemySpawns(double gameTime)
        {
            if (_upComingEnemies.Count ==0)
            {
                return;
            }

            EnemyDef lastElement = _upComingEnemies[_upComingEnemies.Count - 1];

            if(gameTime < lastElement.LaunchTime)
            {
                _upComingEnemies.RemoveAt(_upComingEnemies.Count - 1);
                _enemies.Add(CreateEnemyFromDef(lastElement));
            }
        }

        private Enemy CreateEnemyFromDef (EnemyDef definition)
        {
            Enemy enemy = new Enemy(_textureManager);
            // enemy.SetPosition(definition.StartPosition);

            if (definition.EnemyType == "particlesMiddle")
            {
                List<Vector> _pathPoints = new List<Vector>();
                _pathPoints.Add(new Vector(1400, 0, 0));
                _pathPoints.Add(new Vector(-1400, 0, 0));

                enemy.Path = new Path(_pathPoints, 60);
            }
            else if (definition.EnemyType == "particlesTop")
            {
                List<Vector> _pathPoints = new List<Vector>();
                _pathPoints.Add(new Vector(1400, 200, 0));
                _pathPoints.Add(new Vector(-1400, 200, 0));

                    enemy.Path = new Path(_pathPoints, 60);
               
            }

            else if (definition.EnemyType == "particlesBottom")
            {
                List<Vector> _pathPoints = new List<Vector>();
                _pathPoints.Add(new Vector(1400, -200, 0));
                _pathPoints.Add(new Vector(-1400, -200, 0));
               
                enemy.Path = new Path(_pathPoints, 60);
            }

            else if (definition.EnemyType == "particlesBottomMid")
            {
                List<Vector> _pathPoints = new List<Vector>();
                _pathPoints.Add(new Vector(1400, -100, 0));
                _pathPoints.Add(new Vector(-1400, -100, 0));

                enemy.Path = new Path(_pathPoints, 100);
            }
            else
            {
                System.Diagnostics.Debug.Assert(false, "Unknown enemy type.");
            }
            return enemy;

        }
        public void Update(double elapsedTime, double gameTime)
        {
            UpdateEnemySpawns(gameTime);
            _enemies.ForEach(x => x.Update(elapsedTime));
            CheckForOutOfBounds();
            RemoveDeadEnemies();
        }
        private void CheckForOutOfBounds()
        {
            foreach (Enemy enemy in _enemies)
            {
                if (enemy.GetBoundingBox(0.65, 0.65).Right < _leftBound)
                {
                    enemy.Health = 0;
                }
            }
        }

        public void Render(Renderer renderer)
        {
            _enemies.ForEach(x => x.Render(renderer));

        }

        private void RemoveDeadEnemies()
        {
            for (int i = _enemies.Count -1; i >= 0; i--)
            {
                if (_enemies[i].IsDead)
                {
                    _enemies.RemoveAt(i);
                }
            }
        }
    }
}

