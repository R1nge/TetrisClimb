using System.Collections.Generic;
using System.Linq;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisGridService
    {
        public readonly List<int> RowsIndexiesToDelete = new List<int>(10);

        public TetrisData[,] Data = new TetrisData[10, 10];
        //private MAtr

        public void Rotate(bool clockwise)
        {
            if (clockwise)
            {
                RotateClockwise();
            }
            else
            {
                RotateCounterClockwise();
            }
        }

        private void RotateClockwise()
        {
        }

        private void RotateCounterClockwise()
        {
        }

        public void CheckRows()
        {
            RowsIndexiesToDelete.Clear();
            for (int rows = 0; rows < Data.GetLength(0); rows++)
            {
                for (int columns = 0; columns < Data.GetLength(1); columns++)
                {
                    if (Data[rows, columns].TetrisBlockType == TetrisBlockType.None)
                    {
                        break;
                    }

                    RowsIndexiesToDelete.Add(rows);
                }
            }

            if (RowsIndexiesToDelete.Count > 0)
            {
                DeleteRows();
            }


            MoveDownRows();
            RowsIndexiesToDelete.Clear();
        }

        private void DeleteRows()
        {
            for (int i = 0; i < RowsIndexiesToDelete.Count; i++)
            {
                for (int rows = 0; rows < Data.GetLength(0); rows++)
                {
                    for (int columns = 0; columns < Data.GetLength(1); columns++)
                    {
                        if (RowsIndexiesToDelete.Contains(rows))
                        {
                            Data[rows, columns].TetrisBlockType = TetrisBlockType.None;
                        }
                    }
                }
            }

            var max = RowsIndexiesToDelete.Max();
            var min = RowsIndexiesToDelete.Min();

            for (int rowsToDelete = max - 1; rowsToDelete >= min; rowsToDelete--)
            {
                for (int columns = 0; columns < Data.GetLength(1); columns++)
                {
                    if (Data[rowsToDelete, columns].TetrisBlockType != TetrisBlockType.None)
                    {
                        if (rowsToDelete - 1 >= 0)
                        {
                            if (Data[rowsToDelete - 1, columns].TetrisBlockType == TetrisBlockType.None)
                            {
                                Data[rowsToDelete - 1, columns].TetrisBlockType =
                                    Data[rowsToDelete, columns].TetrisBlockType;
                                Data[rowsToDelete, columns].TetrisBlockType = TetrisBlockType.None;
                            }
                        }
                    }
                }
            }
        }

        private void MoveDownRows()
        {
            for (int rows = 0; rows < Data.GetLength(0); rows++)
            {
                for (int columns = 0; columns < Data.GetLength(1); columns++)
                {
                    if (Data[rows, columns].TetrisBlockType != TetrisBlockType.None)
                    {
                        if (rows - 1 >= 0)
                        {
                            if (Data[rows - 1, columns].TetrisBlockType == TetrisBlockType.None)
                            {
                                Data[rows - 1, columns].TetrisBlockType = Data[rows, columns].TetrisBlockType;
                                Data[rows, columns].TetrisBlockType = TetrisBlockType.None;
                            }
                        }
                    }
                }
            }
        }

        public struct TetrisData
        {
            public TetrisBlockType TetrisBlockType;
        }
    }
}