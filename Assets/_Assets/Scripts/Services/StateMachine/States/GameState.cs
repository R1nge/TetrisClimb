using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IAsyncState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerFactory _playerFactory;
        private readonly TetrisFactory _tetrisFactory;

        public GameState(GameStateMachine stateMachine, UIStateMachine uiStateMachine, PlayerFactory playerFactory, TetrisFactory tetrisFactory)
        {
            _stateMachine = stateMachine;
            _uiStateMachine = uiStateMachine;
            _playerFactory = playerFactory;
            _tetrisFactory = tetrisFactory;
        }

        public async UniTask Enter()
        {
            await _uiStateMachine.SwitchState(UIStateType.Game);
            _tetrisFactory.CreateRandom(Vector2.up);
            _playerFactory.Create(Vector3.zero);
        }

        public async UniTask Exit()
        {
        }
    }
}