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
        private KnifeThrower knifeThrower;

        [SerializeField] private MenuView menuView;
        [SerializeField] private GameView gameView;

        private InputSystem inputSystem;

        private UnityAction toGameStateTransition;
        
        [SerializeField]
        private LevelGenerator levelGenerator;
        
        private ShieldMovementController shieldMovementController;
        
        private PointsController pointsController;
        
        private void Start()
        {
            toGameStateTransition = () => ChangeState(gameState);
            shieldMovementController = new ShieldMovementController();
            knifeThrower = new KnifeThrower();
            inputSystem = new InputSystem();
            pointsController = new PointsController();
            menuState = new MenuState(toGameStateTransition, menuView);
            gameState = new GameState(gameView, inputSystem, levelGenerator, shieldMovementController, knifeThrower, pointsController);
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
