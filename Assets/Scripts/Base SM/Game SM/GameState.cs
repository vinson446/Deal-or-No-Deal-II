using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameState : State
{
    protected GameSM stateMachine;

    protected GameManager gameManager;
    protected MenuManager menuManager;
    protected GameUIManager uiManager;
    protected AudioManager audioManager;

    private void Awake()
    {
        stateMachine = GetComponent<GameSM>();

        gameManager = FindObjectOfType<GameManager>();
        menuManager = FindObjectOfType<MenuManager>();
        uiManager = FindObjectOfType<GameUIManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }
}
