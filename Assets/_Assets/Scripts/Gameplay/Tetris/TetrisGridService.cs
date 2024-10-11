using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisGridService
    {
        public readonly List<int> RowsIndexiesToDelete = new List<int>(10);
        private TetrisBlockType _playerTetrisBlockType;
        private Vector2Int _tetrisCurrentPosition;
        private Vector2Int _tetrisSpawnPosition = new(4, 9);

        public TetrisData[,] Data = new TetrisData[10, 10];

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
            bool canBeDeleted = false;
            for (int rows = 0; rows < Data.GetLength(0); rows++)
            {
                for (int columns = 0; columns < Data.GetLength(1); columns++)
                {
                    var maxOccupiedCol = 0;
                    for (int col = 0; col < Data.GetLength(1); col++)
                    {
                        if (Data[rows, col].TetrisBlockType == TetrisBlockType.None)
                        {
                            maxOccupiedCol = col - 1;
                            break;
                        }
                    }

                    if (Data[rows, maxOccupiedCol + 1].TetrisBlockType == TetrisBlockType.None)
                    {
                        break;
                    }

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
        }

        public void CreateNewTetris(TetrisBlockType blockType)
        {
            _playerTetrisBlockType = blockType;
            switch (blockType)
            {
                case TetrisBlockType.None:
                    break;
                case TetrisBlockType.I:
                    Data[_tetrisSpawnPosition.y, _tetrisSpawnPosition.x].TetrisBlockType = TetrisBlockType.I;
                    Data[_tetrisSpawnPosition.y - 1, _tetrisSpawnPosition.x].TetrisBlockType = TetrisBlockType.I;
                    Data[_tetrisSpawnPosition.y - 2, _tetrisSpawnPosition.x].TetrisBlockType = TetrisBlockType.I;
                    Data[_tetrisSpawnPosition.y - 3, _tetrisSpawnPosition.x].TetrisBlockType = TetrisBlockType.I;
                    break;
                case TetrisBlockType.J:
                    break;
                case TetrisBlockType.L:
                    break;
                case TetrisBlockType.O:
                    break;
                case TetrisBlockType.S:
                    break;
                case TetrisBlockType.T:
                    Data[_tetrisSpawnPosition.y, _tetrisSpawnPosition.x].TetrisBlockType = TetrisBlockType.T;
                    Data[_tetrisSpawnPosition.y, _tetrisSpawnPosition.x - 1].TetrisBlockType = TetrisBlockType.T;
                    Data[_tetrisSpawnPosition.y, _tetrisSpawnPosition.x + 1].TetrisBlockType = TetrisBlockType.T;
                    Data[_tetrisSpawnPosition.y - 1, _tetrisSpawnPosition.x].TetrisBlockType = TetrisBlockType.T;
                    _tetrisCurrentPosition = _tetrisSpawnPosition;
                    break;
                case TetrisBlockType.Z:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(blockType), blockType, null);
            }
        }

        public void UpdatePlayerTetrisPosition(Vector2Int input)
        {
            switch (_playerTetrisBlockType)
            {
                case TetrisBlockType.None:
                    break;
                case TetrisBlockType.I:
                    break;
                case TetrisBlockType.J:
                    break;
                case TetrisBlockType.L:
                    break;
                case TetrisBlockType.O:
                    break;
                case TetrisBlockType.S:
                    break;
                case TetrisBlockType.T:

                    Data[_tetrisCurrentPosition.y, _tetrisCurrentPosition.x].TetrisBlockType = TetrisBlockType.None;
                    Data[_tetrisCurrentPosition.y, _tetrisCurrentPosition.x - 1].TetrisBlockType = TetrisBlockType.None;
                    Data[_tetrisCurrentPosition.y, _tetrisCurrentPosition.x + 1].TetrisBlockType = TetrisBlockType.None;
                    Data[_tetrisCurrentPosition.y - 1, _tetrisCurrentPosition.x].TetrisBlockType = TetrisBlockType.None;

                    if (input.x == 1)
                    {
                        if (Data[_tetrisCurrentPosition.y, _tetrisCurrentPosition.x + 1].TetrisBlockType ==
                            TetrisBlockType.None)
                        {
                            _tetrisCurrentPosition.x++;
                        }
                    }
                    else
                    {
                        if (Data[_tetrisCurrentPosition.y, _tetrisCurrentPosition.x - 1].TetrisBlockType ==
                            TetrisBlockType.None)
                        {
                            _tetrisCurrentPosition.x--;
                        }
                    }

                    Data[_tetrisCurrentPosition.y, _tetrisCurrentPosition.x].TetrisBlockType = TetrisBlockType.T;
                    Data[_tetrisCurrentPosition.y, _tetrisCurrentPosition.x - 1].TetrisBlockType = TetrisBlockType.T;
                    Data[_tetrisCurrentPosition.y, _tetrisCurrentPosition.x + 1].TetrisBlockType = TetrisBlockType.T;
                    Data[_tetrisCurrentPosition.y - 1, _tetrisCurrentPosition.x].TetrisBlockType = TetrisBlockType.T;
                    break;
                case TetrisBlockType.Z:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
            _tetrisCurrentPosition.y--;
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