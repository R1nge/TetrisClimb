using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisGridView : MonoBehaviour
    {
        [SerializeField] private Image gridCellPrefab;
        private Image[,] _gridCells;
        [Inject] private TetrisGridService _tetrisGridService;

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var randomTetrisType = (TetrisBlockType)6; //(TetrisBlockType) Random.Range(0, 7);
                _tetrisGridService.CreateNewTetris(randomTetrisType);
            }

            if (Time.frameCount % 60 == 0)
            {
                _tetrisGridService.CheckRows();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _tetrisGridService.UpdatePlayerTetrisPosition(Vector2Int.left);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _tetrisGridService.UpdatePlayerTetrisPosition(Vector2Int.right);
            }

            UpdateView(ref _tetrisGridService.Data);
        }

        private void UpdateView(ref TetrisGridService.TetrisData[,] tetrisData)
        {
            for (int row = 0; row < tetrisData.GetLength(0); row++)
            {
                for (int column = 0; column < tetrisData.GetLength(1); column++)
                {
                    UpdateColors(_tetrisGridService.Data[row, column].TetrisBlockType, row, column);
                }
            }
        }

        private void UpdateColors(TetrisBlockType tetrisBlockType, int row, int column)
        {
            switch (tetrisBlockType)
            {
                case TetrisBlockType.None:
                    _gridCells[row, column].color = Color.white;
                    break;
                case TetrisBlockType.I:
                    _gridCells[row, column].color = Color.cyan;
                    break;
                case TetrisBlockType.J:
                    _gridCells[row, column].color = Color.blue;
                    break;
                case TetrisBlockType.L:
                    _gridCells[row, column].color = Color.yellow;
                    break;
                case TetrisBlockType.O:
                    _gridCells[row, column].color = Color.green;
                    break;
                case TetrisBlockType.S:
                    _gridCells[row, column].color = Color.red;
                    break;
                case TetrisBlockType.T:
                    _gridCells[row, column].color = Color.magenta;
                    break;
                case TetrisBlockType.Z:
                    _gridCells[row, column].color = Color.gray;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tetrisBlockType), tetrisBlockType, null);
            }
        }

        private void Init()
        {
            _gridCells = new Image[10, 10];
            for (int row = 0; row < _gridCells.GetLength(1); row++)
            {
                for (int column = 0; column < _gridCells.GetLength(0); column++)
                {
                    _gridCells[row, column] = Instantiate(gridCellPrefab, new Vector3(column * 100, row * 100, 0),
                        Quaternion.identity, transform);
                }
            }
        }
    }
}