using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public int caseNum;
    public bool selected;

    Renderer rend;
    Color currentMaterial;

    SelectACaseState selectACaseState;
    RemoveCasesState removeCasesState;

    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        currentMaterial = rend.material.color;

        selectACaseState = FindObjectOfType<SelectACaseState>();
        removeCasesState = FindObjectOfType<RemoveCasesState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CaseSelected()
    {
        if (!selected)
        {
            rend.material.color = Color.green;
            selected = true;

            selectACaseState.SelectedCaseNum = caseNum;
        }
        else
        {
            rend.material.color = currentMaterial;
            selected = false;

            selectACaseState.SelectedCaseNum = -1;
        }
    }

    // NEEDS WORK
    public void CaseRemoved()
    {
        if (!selected)
        {
            rend.material.color = Color.red;
            selected = true;
        }
        else
        {
            rend.material.color = currentMaterial;
            selected = false;
        }
    }
}
