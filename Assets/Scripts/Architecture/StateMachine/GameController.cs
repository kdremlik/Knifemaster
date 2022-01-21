using Architecture.StateMachine.States;
using InputSystemScripts;
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

        [SerializeField] private MenuView menuView;
        [SerializeField] private GameView gameView;

        private InputSystem inputSystem;

        private UnityAction toGameStateTransition;
        
        private void Start()
        {
            toGameStateTransition = () => ChangeState(gameState);
            menuState = new MenuState(toGameStateTransition, menuView);
            gameState = new GameState(gameView);
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
