using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Architecture.StateMachine.States
{
    public class MenuState : BaseState
    {
        private MenuView menuView;
        private UnityAction transitionToGameState;

        public MenuState(UnityAction transitionToGameState, MenuView menuView)
        {
            this.menuView = menuView;
            this.transitionToGameState = transitionToGameState;

        }
        public override void InitState()
        {
            if (menuView != null)
            {
                menuView.ShowView();
                Debug.Log("MENU INIT");
            }
            menuView.PlayButton.onClick.AddListener(transitionToGameState);
            
        }

        public override void UpdateState()
        {

        }

        public override void DestroyState()
        {
            if (menuView != null)
                menuView.HideView();
            
            menuView.PlayButton.onClick.RemoveAllListeners();
            
        }
    }
}