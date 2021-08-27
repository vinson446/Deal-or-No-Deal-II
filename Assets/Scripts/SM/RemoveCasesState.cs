using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCasesState : GameState
{
    [SerializeField] int numCasesToRemove;
    public int NumCasesToRemove { get => numCasesToRemove; set => numCasesToRemove = value; }

    [SerializeField] Case caseSelected;
    public Case CaseSelected => caseSelected;

    [SerializeField] List<int> casesToRemoveThisRound;
    public List<int> CasesToRemoveThisRound { get => casesToRemoveThisRound; set => casesToRemoveThisRound = value; }

    public override void Enter()
    {
        base.Enter();

        stateMachine.state = "Remove Cases";

        switch (gameManager.DealerStageIndex)
        {
            case 0:
                uiManager.GameText.text = "Remove 4 Cases";
                numCasesToRemove = 4;
                break;
            case 1:
                uiManager.GameText.text = "Remove 3 Cases";
                numCasesToRemove = 3;
                break;
            case 2:
                uiManager.GameText.text = "Remove 2 Cases";
                numCasesToRemove = 2;
                break;
            case 3:
                uiManager.GameText.text = "Remove 1 Case";
                numCasesToRemove = 1;
                break;
        }

        uiManager.ContinueButton.onClick.AddListener(EndRemoveCases);
    }

    public override void Tick()
    {
        base.Tick();

        RemoveCases();
    }

    public override void Exit()
    {
        base.Exit();

        uiManager.ContinueButton.onClick.RemoveListener(EndRemoveCases);
    }

    void RemoveCases()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Case")
                {
                    caseSelected = hit.collider.GetComponent<Case>();

                    caseSelected.CaseRemoved();
                }
            }
        }
    }

    void EndRemoveCases()
    {
        if (numCasesToRemove == 0)
        {
            caseSelected.ClearCaseSelected();

            gameManager.DealerStageIndex++;
            uiManager.RemoveCasesUI(casesToRemoveThisRound);

            stateMachine.ChangeState<DealerState>();
        }
    }
}
