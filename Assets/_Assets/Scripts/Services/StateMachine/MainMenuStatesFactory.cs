using System;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class MainMenuStatesFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerFactory _playerFactory;

        private MainMenuStatesFactory(UIStateMachine uiStateMachine, PlayerFactory playerFactory)
        {
            _uiStateMachine = uiStateMachine;
            _playerFactory = playerFactory;
        }

        public IAsyncState CreateAsyncState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Init:
                    return new InitState(gameStateMachine, _uiStateMachine);
                case GameStateType.Game:
                    return new GameState(gameStateMachine, _uiStateMachine, _playerFactory);
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}