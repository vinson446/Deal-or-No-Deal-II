using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerState : GameState
{
    public override void Enter()
    {
        base.Enter();

        stateMachine.state = "Dealer Offer";

        uiManager.gameText.text = "Your dealer is making you an offer of ";

        ShowDealerUI();
    }

    public override void Tick()
    {
        base.Tick();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
