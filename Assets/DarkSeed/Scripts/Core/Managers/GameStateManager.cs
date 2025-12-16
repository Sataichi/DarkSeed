using System.Collections.Generic;
using DarkSeed.Core.GameStates;
using UnityEngine;
using Zenject;

namespace DarkSeed.Core.Managers
{
    public class GameStateManager : MonoBehaviour
    {
        private List<IGamePausable> _pausables;
        private List<IGameStartable> _startables;
        private List<IGameEndable> _endables;

        [Inject]
        private void Construct(List<IGamePausable> pausables, List<IGameStartable> startables,
            List<IGameEndable> endables)
        {
            _pausables = pausables;
            _startables = startables;
            _endables = endables;
        }

        [ContextMenu("Start Game")]
        public void StartGame()
        {
            foreach (var startable in _startables)
                startable.OnGameStarted();
        }

        [ContextMenu("Pause Game")]
        public void PauseGame()
        {
            foreach (var pausable in _pausables)
                pausable.IsGamePaused = true;
        }

        [ContextMenu("Resume Game")]
        public void ResumeGame()
        {
            foreach (var pausable in _pausables)
                pausable.IsGamePaused = false;
        }

        [ContextMenu("End Game")]
        public void EndGame()
        {
            foreach (var endable in _endables)
                endable.OnGameEnded();
        }
    }
}