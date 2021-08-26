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
        foreach (Button b in uiManager.dealButtons)
        {
            b.gameObject.SetActive(true);
        }
        uiManager.offerText.gameObject.SetActive(true);

        uiManager.continueButton.gameObject.SetActive(false);
    }

    protected void ShowContinueButton()
    {
        foreach (Button b in uiManager.dealButtons)
        {
            b.gameObject.SetActive(false);
        }
        uiManager.offerText.gameObject.SetActive(false);

        uiManager.continueButton.gameObject.SetActive(true);
    }
}
