using UI;

namespace Architecture.StateMachine.States
{

    public class GameState : BaseState
    {
        private GameView gameView;

        public GameState(GameView gameView)
        {
                this.gameView = gameView;
        }
        
        public override void InitState()
        {
            if (gameView != null)
            {
                gameView.ShowView();
            }
        }

        public override void UpdateState()
        {
            
        }

        public override void DestroyState()
        {
            if (gameView != null)
            {
                gameView.HideView();
            }
        }
    }
}
