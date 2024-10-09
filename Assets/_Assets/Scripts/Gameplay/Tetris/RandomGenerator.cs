using System;
using System.Collections.Generic;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class RandomGenerator
    {
        private static readonly string[] Tetrominoes = { "I", "J", "L", "O", "S", "T", "Z" };
        private Queue<TetrisBlockType> currentBag;
        private Random random;

        public RandomGenerator()
        {
            random = new Random();
            currentBag = GenerateNewBag();
        }

        private Queue<TetrisBlockType> GenerateNewBag()
        {
            List<string> bag = new List<string>(Tetrominoes);
            for (int i = bag.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (bag[i], bag[j]) = (bag[j], bag[i]);
            }

            var result = new Queue<TetrisBlockType>();
            foreach (var tetromino in bag)
            {
                result.Enqueue((TetrisBlockType)Enum.Parse(typeof(TetrisBlockType), tetromino));
            }

            return new Queue<TetrisBlockType>(result);
        }

        public TetrisBlockType GetNextTetris()
        {
            if (currentBag.Count == 0)
            {
                currentBag = GenerateNewBag();
            }

            return currentBag.Dequeue();
        }
    }
}