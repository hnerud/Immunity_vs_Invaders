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

            _upComingEnemies.Add(new EnemyDef("particles", new Vector(300, 300, 0), 25));
            _upComingEnemies.Add(new EnemyDef("particles", new Vector(300, -300, 0), 30));
            _upComingEnemies.Add(new EnemyDef("particles", new Vector(300, 0, 0), 29));

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
            enemy.SetPosition(definition.StartPosition);

            if (definition.EnemyType == "particles")
            {
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
                if (enemy.GetBoundingBox().Right < _leftBound)
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

