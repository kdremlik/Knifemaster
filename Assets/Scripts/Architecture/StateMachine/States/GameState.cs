using Generation;
using InputSystemScripts;
using UI;
using UnityEngine;

namespace Architecture.StateMachine.States
{

    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;
        
        public GameState(GameView gameView, InputSystem inputSystem, LevelGenerator levelGenerator)
        {
                this.gameView = gameView;
                this.inputSystem = inputSystem;
                this.levelGenerator = levelGenerator;
        }
        
        public override void InitState()
        {
            if (gameView != null)
            {
                gameView.ShowView();
                Debug.Log("GAME INIT");
            }
            inputSystem.AddListener(PrintDebug);
            levelGenerator.SpawnShield();
        }

        public override void UpdateState()
        {
            inputSystem.UpdateSystem();
        }

        public override void DestroyState()
        {
            if (gameView != null)
            {
                gameView.HideView();
            }
            inputSystem.RemoveAllListeners();
        }
        
        private void PrintDebug()
        {
            Debug.Log("BUTTON CLICKED");
        }

    }
}
