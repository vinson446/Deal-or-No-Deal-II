using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameState : State
{
    protected GameSM stateMachine;

    protected GameManager gameManager;
    protected UIManager uiManager;

    private void Awake()
    {
        stateMachine = GetComponent<GameSM>();

        gameManager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
    }

    protected void ShowDealerUI()
    {
        foreach (Button b in uiManager.DealButtons)
        {
            b.gameObject.SetActive(true);
        }
        uiManager.OfferText.gameObject.SetActive(true);

        uiManager.ContinueButton.gameObject.SetActive(false);
    }

    protected void ShowContinueButton()
    {
        foreach (Button b in uiManager.DealButtons)
        {
            b.gameObject.SetActive(false);
        }
        uiManager.OfferText.gameObject.SetActive(false);

        uiManager.ContinueButton.gameObject.SetActive(true);
    }
}
