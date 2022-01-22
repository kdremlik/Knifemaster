using CoreGameplay;
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
        private ShieldMovementController shieldMovementController;
        
        public GameState(GameView gameView, InputSystem inputSystem, LevelGenerator levelGenerator, ShieldMovementController shieldMovementController)
        {
                this.gameView = gameView;
                this.inputSystem = inputSystem;
                this.levelGenerator = levelGenerator;
                this.shieldMovementController = shieldMovementController;
        }
        
        public override void InitState()
        {
            if (gameView != null)
            {
                gameView.ShowView();
                Debug.Log("GAME INIT");
            }
            var startShield = levelGenerator.SpawnShield();
            shieldMovementController.InitializeShield(startShield);
            
            inputSystem.AddListener(PrintDebug);
            levelGenerator.SpawnKnife();
            
        }

        public override void UpdateState()
        {
            inputSystem.UpdateSystem();
            shieldMovementController.UpdateController();
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
