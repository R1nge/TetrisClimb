using System;
using System.Collections.Generic;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class RandomGenerator
    {
        private static readonly string[] Tetrominoes = { "I", "J", "L", "O", "S", "T", "Z" };
        private Queue<string> currentBag;
        private Random random;

        public RandomGenerator()
        {
            random = new Random();
            currentBag = GenerateNewBag();
        }

        private Queue<string> GenerateNewBag()
        {
            List<string> bag = new List<string>(Tetrominoes);
            for (int i = bag.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (bag[i], bag[j]) = (bag[j], bag[i]);
            }

            return new Queue<string>(bag);
        }

        public string GetNextTetris()
        {
            if (currentBag.Count == 0)
            {
                currentBag = GenerateNewBag();
            }

            return currentBag.Dequeue();
        }
    }
}