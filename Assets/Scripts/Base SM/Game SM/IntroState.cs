using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroState : GameState
{
    List<int> caseNums = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

    public override void Enter()
    {
        base.Enter();

        stateMachine.state = "Intro";

        uiManager.GameText.text = "Welcome to Deal or No Deal II";

        ShowContinueUI();
        uiManager.ContinueButton.onClick.AddListener(EndIntro);
    }

    public override void Tick()
    {
        base.Tick();
    }

    public override void Exit()
    {
        base.Exit();

        uiManager.ContinueButton.onClick.RemoveListener(EndIntro);
    }

    public void EndIntro()
    {
        uiManager.DisableInputFields();
        ShuffleCases();

        stateMachine.ChangeState<ChooseCaseState>();
    }

    void ShuffleCases()
    {
        for (int i = 0; i < 12; i++)
        {
            int index = Random.Range(0, caseNums.Count - 1);

            gameManager.Cases.Add(i, uiManager.InputFields[index].text);
            gameManager.CasesChecker.Add(uiManager.InputFields[index].text);

            caseNums.Remove(index);
        }
    }
}
