using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameUIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TMP_InputField[] inputFields;
    public TMP_InputField[] InputFields => inputFields;

    [SerializeField] TextMeshProUGUI gameText;

    [SerializeField] Button continueButton;
    public Button ContinueButton { get => continueButton; set => continueButton = value; }

    [SerializeField] Button[] dealButtons;
    public Button[] DealButtons { get => dealButtons; set => dealButtons = value; }

    [SerializeField] TMP_InputField offerText;
    public TMP_InputField OfferText => offerText;

    GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void DisableInputFields()
    {
        foreach (TMP_InputField i in inputFields)
        {
            i.interactable = false;

            TextMeshProUGUI text = i.GetComponentInChildren<TextMeshProUGUI>();
            text.color = Color.yellow;
        }
    }

    public void SetGameText(string text)
    {
        gameText.text = text;
    }

    public void ShowContinueUI()
    {
        foreach (Button b in dealButtons)
        {
            b.gameObject.SetActive(false);
        }
        offerText.gameObject.SetActive(false);

        continueButton.gameObject.SetActive(true);
    }

    public void RemoveCasesUI(List<int> caseIndexes)
    {
        for (int i = 0; i < caseIndexes.Count; i++)
        {
            var inputFieldColor = inputFields[caseIndexes[i]].colors;
            inputFieldColor.disabledColor = Color.red;
            inputFields[caseIndexes[i]].colors = inputFieldColor;
        }
    }

    public void ShowDealerUI()
    {
        foreach (Button b in dealButtons)
        {
            b.gameObject.SetActive(true);
        }
        offerText.text = "";
        offerText.gameObject.SetActive(true);

        continueButton.gameObject.SetActive(false);
    }
}
