using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coffee.UIEffects;

public class DealerState : GameState
{
    UIShiny dealVFX;
    UIShiny noDealVFX;

    private void Start()
    {
        dealVFX = uiManager.DealButtons[0].GetComponent<UIShiny>();
        noDealVFX = uiManager.DealButtons[1].GetComponent<UIShiny>();
    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.state = "Dealer Offer";

        uiManager.SetGameText("Your dealer is making you an offer of ");
        uiManager.ShowDealerUI();

        StartCoroutine(ShowDealerUI());

        uiManager.DealButtons[0].onClick.AddListener(Deal);
        uiManager.DealButtons[1].onClick.AddListener(NoDeal);

        uiManager.DealButtons[0].onClick.AddListener(audioManager.PlayButtonSFX);
        uiManager.DealButtons[1].onClick.AddListener(audioManager.PlayButtonSFX);
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

        uiManager.DealButtons[0].onClick.RemoveListener(audioManager.PlayButtonSFX);
        uiManager.DealButtons[1].onClick.RemoveListener(audioManager.PlayButtonSFX);
    }

    public void Deal()
    {
        SaveInfo.saveInfo.TookDeal = true;
        SaveInfo.saveInfo.LastIndexes[0] = gameManager.SelectedCaseIndex;
        SaveInfo.saveInfo.LastCases[0] = gameManager.SelectedCase;
        SaveInfo.saveInfo.LastCases[1] = uiManager.OfferText.text;

        menuManager.ExitScene(2);
    }

    public void NoDeal()
    {
        if (gameManager.DealerStageIndex < 4)
            stateMachine.ChangeState<RemoveCasesState>();
        else
        {
            int lastCaseIndex = -1;

            Case[] cases = FindObjectsOfType<Case>();
            for (int i = 0; i < cases.Length; i++)
            {
                if (!cases[i].Chosen && !cases[i].Removed)
                {
                    lastCaseIndex = cases[i].CaseNum;
                    break;
                }
            }

            SaveInfo.saveInfo.TookDeal = false;
            SaveInfo.saveInfo.LastIndexes[0] = gameManager.SelectedCaseIndex;
            SaveInfo.saveInfo.LastCases[0] = gameManager.SelectedCase;
            SaveInfo.saveInfo.LastIndexes[1] = lastCaseIndex;
            SaveInfo.saveInfo.LastCases[1] = gameManager.CasesChecker[lastCaseIndex];

            menuManager.ExitScene(2);
        }
    }

    IEnumerator ShowDealerUI()
    {
        uiManager.DealButtons[0].interactable = false;
        dealVFX.enabled = false;
        uiManager.DealButtons[1].interactable = false;
        noDealVFX.enabled = false;

        yield return new WaitForSeconds(3);

        audioManager.PlayDealerCallSFX();

        yield return new WaitForSeconds(3);

        uiManager.DealButtons[0].interactable = true;
        dealVFX.enabled = true;
        uiManager.DealButtons[1].interactable = true;
        noDealVFX.enabled = true;
    }
}
