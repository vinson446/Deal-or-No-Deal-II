using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TMP_InputField[] inputFields;
    public TMP_InputField[] InputFields { get => inputFields; set => inputFields = value; }

    [SerializeField] TextMeshProUGUI gameText;
    public TextMeshProUGUI GameText { get => gameText; set => gameText = value; }

    [SerializeField] Button continueButton;
    public Button ContinueButton { get => continueButton; set => continueButton = value; }

    [SerializeField] Button[] dealButtons;
    public Button[] DealButtons { get => dealButtons; set => dealButtons = value; }

    [SerializeField] TMP_InputField offerText;
    public TMP_InputField OfferText { get => offerText; set => offerText = value; }

    GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void RemoveCasesUI(List<int> caseIndexes)
    {
        for (int i = 0; i < caseIndexes.Count; i++)
        {
            var inputFieldColor = inputFields[caseIndexes[i]].colors;
            inputFieldColor.disabledColor = Color.red;
            inputFields[caseIndexes[i]].colors = inputFieldColor;
        }
    }
}
