using Architecture.StateMachine.States;
using CoreGameplay;
using Generation;
using InputSystemScripts;
using Points;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Architecture.StateMachine
{
    public class GameController : MonoBehaviour
    {
        private BaseState currentlyActiveState;
        private MenuState menuState;
        private GameState gameState;
        private LoseState loseState;
        private KnifeThrower knifeThrower;

        [SerializeField] private MenuView menuView;
        [SerializeField] private GameView gameView;

        private InputSystem inputSystem;

        private UnityAction toGameStateTransition;

        private UnityAction toLoseStateTransition;
        
        [SerializeField]
        private LevelGenerator levelGenerator;
        
        private ShieldMovementController shieldMovementController;
        
        private PointsController pointsController;

        private StageController stageController;

        [SerializeField] private LoseView loseView;
        
        private void Start()
        {
            toGameStateTransition = () => ChangeState(gameState);
            toLoseStateTransition = () => ChangeState(loseState);
            shieldMovementController = new ShieldMovementController();
            knifeThrower = new KnifeThrower();
            inputSystem = new InputSystem();
            pointsController = new PointsController();
            stageController = new StageController();
            menuState = new MenuState(toGameStateTransition, menuView);
            gameState = new GameState(gameView, inputSystem, levelGenerator, shieldMovementController, knifeThrower, pointsController, stageController);
            ChangeState(menuState);

        }

        private void Update()
        {
            currentlyActiveState.UpdateState();
            
        }

        private void OnDestroy()
        {

        }

        private void ChangeState(BaseState newState)
        {
            currentlyActiveState?.DestroyState();
            currentlyActiveState = newState;
            currentlyActiveState?.InitState();
        }
    }
}
