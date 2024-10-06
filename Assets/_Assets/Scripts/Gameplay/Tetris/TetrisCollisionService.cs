using _Assets.Scripts.Services.Factories;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisCollisionService
    {
        private readonly TetrisFactory _tetrisFactory;

        private TetrisCollisionService(TetrisFactory tetrisFactory)
        {
            _tetrisFactory = tetrisFactory;
        }

        public void Collide(TetrisController tetrisController, TetrisController tetrisController1)
        {
            if ((tetrisController.CanMove || tetrisController1.CanMove) &&
                (tetrisController.CanRotate || tetrisController1.CanRotate))
            {
                tetrisController.Block();
                tetrisController1.Block();
                _tetrisFactory.CreateRandom(Vector2.one);
            }
        }
    }
}