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
        private KnifeThrower knifeThrower;
        
        public GameState(GameView gameView, InputSystem inputSystem, LevelGenerator levelGenerator,
            ShieldMovementController shieldMovementController, KnifeThrower knifeThrower)
        {
                this.gameView = gameView;
                this.inputSystem = inputSystem;
                this.levelGenerator = levelGenerator;
                this.shieldMovementController = shieldMovementController;
                this.knifeThrower = knifeThrower;
        }
        
        public override void InitState()
        {
            if (gameView != null)
            {
                gameView.ShowView();
                Debug.Log("GAME INIT");
            }
            
            PrepareNewShield();
            PrepareNewKnife();
            inputSystem.AddListener(knifeThrower.Throw);
            
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

        private void PrepareNewKnife()
        {
            var newKnife = levelGenerator.SpawnKnife();
            knifeThrower.SetKnife(newKnife);
        }
        private void PrepareNewShield()
        {
            var newShield = levelGenerator.SpawnShield();
            shieldMovementController.InitializeShield(newShield,PrepareNewKnife, PrepareNewShield);
            
        }
    }
}
