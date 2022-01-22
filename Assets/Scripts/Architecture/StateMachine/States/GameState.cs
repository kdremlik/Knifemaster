using InputSystemScripts;
using UI;
using UnityEngine;

namespace Architecture.StateMachine.States
{

    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        
        public GameState(GameView gameView, InputSystem inputSystem)
        {
                this.gameView = gameView;
                this.inputSystem = inputSystem;
                
        }
        
        public override void InitState()
        {
            if (gameView != null)
            {
                gameView.ShowView();
                Debug.Log("GAME INIT");
            }
            inputSystem.AddListener(PrintDebug);
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
