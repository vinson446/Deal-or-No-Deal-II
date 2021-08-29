using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroState : GameState
{
    public override void Enter()
    {
        base.Enter();

        stateMachine.state = "Intro";

        uiManager.SetGameText("Welcome to Deal or No Deal II,\n" +
            "Fill in your cases");
        uiManager.ShowContinueUI();

        uiManager.ContinueButton.onClick.AddListener(EndIntro);

        uiManager.ContinueButton.onClick.AddListener(audioManager.PlayButtonSFX);
    }

    public override void Tick()
    {
        base.Tick();
    }

    public override void Exit()
    {
        base.Exit();

        uiManager.ContinueButton.onClick.RemoveListener(EndIntro);

        uiManager.ContinueButton.onClick.RemoveListener(audioManager.PlayButtonSFX);
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
            gameManager.CasesChecker.Add(uiManager.InputFields[i].text);
        }

        for (int i = 0; i < 12; i++)
        {
            TMP_InputField tmp = uiManager.InputFields[i];
            string stringTMP = gameManager.CasesChecker[i];

            int randIndex = Random.Range(0, 12);

            uiManager.InputFields[i] = uiManager.InputFields[randIndex];
            uiManager.InputFields[randIndex] = tmp;
            gameManager.CasesChecker[i] = gameManager.CasesChecker[randIndex];
            gameManager.CasesChecker[randIndex] = stringTMP;
        }
    }
}
