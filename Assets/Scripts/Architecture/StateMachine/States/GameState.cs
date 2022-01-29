using CoreGameplay;
using Generation;
using InputSystemScripts;
using Points;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Architecture.StateMachine.States
{

    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;
        private ShieldMovementController shieldMovementController;
        private KnifeThrower knifeThrower;
        private PointsController pointsController;
        private StageController stageController;

        public GameState(GameView gameView, InputSystem inputSystem, LevelGenerator levelGenerator,
            ShieldMovementController shieldMovementController, KnifeThrower knifeThrower, PointsController pointsController, StageController stageController)
        {
                this.gameView = gameView;
                this.inputSystem = inputSystem;
                this.levelGenerator = levelGenerator;
                this.shieldMovementController = shieldMovementController;
                this.knifeThrower = knifeThrower;
                this.pointsController = pointsController;
                this.stageController = stageController;
        }
        
        public override void InitState()
        {
            if (gameView != null)
            {
                gameView.ShowView();
                Debug.Log("GAME INIT");
            }
            pointsController.InitSystem();
            PrepareNewShield();
            PrepareNewKnife();
            stageController.InitController();
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
            IncresePoints();
        }

        private void IncresePoints()
        {
            pointsController.IncresePoints();
            gameView.UpdatePoints(pointsController.CurrentPoints);
        }
        
        private void PrepareNewShield()
        {
            var nextStageType = stageController.NextStage();
            var newShield = levelGenerator.SpawnShield(nextStageType);
            gameView.UpdateStage(stageController.CurrentStage);
            
            
            UnityAction onShieldHit = gameView.DecreaseAmmo;
            onShieldHit += PrepareNewKnife;
            
            
            shieldMovementController.InitializeShield(newShield,onShieldHit, PrepareNewShield);
            gameView.SpawnAmmo(newShield.KnivesToWin);
            
        }
    }
}
