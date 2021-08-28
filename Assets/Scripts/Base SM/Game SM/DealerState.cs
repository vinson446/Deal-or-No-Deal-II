using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerState : GameState
{
    [SerializeField] string dealerOffer;
    
    public override void Enter()
    {
        base.Enter();

        stateMachine.state = "Dealer Offer";

        uiManager.GameText.text = "Your dealer is making you an offer of ";

        ShowDealerUI();

        uiManager.DealButtons[0].onClick.AddListener(Deal);
        uiManager.DealButtons[1].onClick.AddListener(NoDeal);

    }

    public override void Tick()
    {
        base.Tick();
    }

    public override void Exit()
    {
        base.Exit();

        uiManager.DealButtons[0].onClick.RemoveListener(Deal);
        uiManager.DealButtons[1].onClick.RemoveListener(NoDeal);
    }

    public void Deal()
    {
        gameManager.EndDeal = dealerOffer;

        menuManager.ExitScene(2);
    }

    public void NoDeal()
    {
        if (gameManager.DealerStageIndex < 4)
            stateMachine.ChangeState<RemoveCasesState>();
        else
            menuManager.ExitScene(2);
    }
}
