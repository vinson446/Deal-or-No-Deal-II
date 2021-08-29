using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndManager : MonoBehaviour
{
    [SerializeField] GameObject[] caseObjs;

    EndUIManager endUIManager;

    int selectedCaseIndex;

    private void Awake()
    {
        endUIManager = FindObjectOfType<EndUIManager>();
    }

    private void Start()
    {
        SetupScene();
    }

    void SetupScene()
    {
        if (SaveInfo.saveInfo.TookDeal)
        {
            caseObjs[0].SetActive(true);
            TextMesh caseNum = caseObjs[0].GetComponentInChildren<TextMesh>();
            caseNum.text = Convert.ToInt32(SaveInfo.saveInfo.LastIndexes[0] + 1).ToString();

            endUIManager.SetEndText("The deal you accepted was: ", SaveInfo.saveInfo.LastCases[1],
                "Click your case to see if you made a good deal");
        }
        else
        {
            caseObjs[1].SetActive(true);
            TextMesh caseNum1 = caseObjs[1].GetComponentInChildren<TextMesh>();
            caseNum1.text = Convert.ToInt32(SaveInfo.saveInfo.LastIndexes[0] + 1).ToString();
            Renderer rend = caseObjs[1].GetComponentInChildren<Renderer>();
            rend.material.color = Color.green;

            caseObjs[2].SetActive(true);
            TextMesh caseNum2 = caseObjs[2].GetComponentInChildren<TextMesh>();
            caseNum2.text = Convert.ToInt32(SaveInfo.saveInfo.LastIndexes[1] + 1).ToString();

            endUIManager.SetEndText("Which case will you choose", "",
                "Your case... or the final case");
        }
    }

    private void Update()
    {
        ChooseCase();
    }

    void ChooseCase()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Case")
                {
                    LastCase selectedCase = hit.collider.GetComponent<LastCase>();
                    DisplayResults(selectedCase.Index);
                }
            }
        }
    }

    void DisplayResults(int chosenCaseIndex)
    {
        if (SaveInfo.saveInfo.TookDeal)
            endUIManager.DisplayDealResultsUI(SaveInfo.saveInfo.LastCases[0], SaveInfo.saveInfo.LastCases[1]);
        else
        {
            if (chosenCaseIndex == 0)
                endUIManager.DisplayNoDealResultsUI(SaveInfo.saveInfo.LastCases[0], SaveInfo.saveInfo.LastCases[1]);
            else
                endUIManager.DisplayNoDealResultsUI(SaveInfo.saveInfo.LastCases[1], SaveInfo.saveInfo.LastCases[0]);
        }
    }
}
