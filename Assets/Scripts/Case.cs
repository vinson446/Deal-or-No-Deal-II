using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    [SerializeField] int caseNum;
    public int CaseNum => caseNum;
    [SerializeField] bool chosen;
    public bool Chosen => chosen;

    [SerializeField] bool selected;
    public bool Selected => selected;

    [SerializeField] bool removed;
    public bool Removed { get => removed; set => removed = value; }

    Renderer rend;
    Color currentMaterial;

    ChooseCaseState chooseCaseState;
    RemoveCasesState removeCasesState;

    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        currentMaterial = rend.material.color;

        chooseCaseState = FindObjectOfType<ChooseCaseState>();
        removeCasesState = FindObjectOfType<RemoveCasesState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ClearCaseSelected()
    {
        selected = false;
    }

    public void CaseChosen()
    {
        if (!selected)
        {
            rend.material.color = Color.green;
            chosen = true;
            selected = true;

            chooseCaseState.SelectedCaseNum = caseNum;
        }
        else
        {
            rend.material.color = currentMaterial;
            chosen = false;
            selected = false;

            chooseCaseState.SelectedCaseNum = -1;
        }
    }

    public void CaseRemoved()
    {
        if (!chosen && !removed)
        {
            if (!selected)
            {
                if (removeCasesState.NumCasesToRemove > 0)
                {
                    rend.material.color = Color.red;
                    selected = true;

                    removeCasesState.NumCasesToRemove--;
                    removeCasesState.CasesToRemove.Add(this);
                    removeCasesState.CaseIndexesToRemove.Add(caseNum);
                }
            }
            else
            {
                rend.material.color = currentMaterial;
                selected = false;

                removeCasesState.NumCasesToRemove++;
                removeCasesState.CasesToRemove.Remove(this);
                removeCasesState.CaseIndexesToRemove.Remove(caseNum);

            }
        }
    }
}
