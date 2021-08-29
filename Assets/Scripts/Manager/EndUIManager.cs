using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndUIManager : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] TextMeshProUGUI topText;
    [SerializeField] TextMeshProUGUI dealText;
    [SerializeField] TextMeshProUGUI botText;

    [Header("Results")]
    [SerializeField] GameObject resultsFadeImage;
    [SerializeField] GameObject endPanel;
    [SerializeField] TextMeshProUGUI resultsTopText;
    [SerializeField] TextMeshProUGUI resultsTopFillText;
    [SerializeField] TextMeshProUGUI resultsBotText;
    [SerializeField] TextMeshProUGUI resultsBotFillText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEndText(string top, string deal, string bot)
    {
        topText.text = top;
        dealText.text = deal;
        botText.text = bot;
    }

    public void DisplayDealResultsUI(string yourCase, string deal)
    {
        resultsFadeImage.SetActive(true);
        endPanel.SetActive(true);

        resultsTopText.text = "You won:";
        resultsTopFillText.text = deal;
        resultsBotText.text = "Your case contained:";
        resultsBotFillText.text = yourCase;
    }

    public void DisplayNoDealResultsUI(string caseChosen, string otherCase)
    {
        resultsFadeImage.SetActive(true);
        endPanel.SetActive(true);

        resultsTopText.text = "You won:";
        resultsTopFillText.text = caseChosen;
        resultsBotText.text = "The other case contained:";
        resultsBotFillText.text = otherCase;
    }
}
