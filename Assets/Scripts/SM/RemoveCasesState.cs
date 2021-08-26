using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCasesState : GameState
{
    [SerializeField] int numCasesToRemove;
    public int NumCasesToRemove { get => numCasesToRemove; set => numCasesToRemove = value; }

    [SerializeField] Case caseSelected;
    public Case CaseSelected => caseSelected;

    public override void Enter()
    {
        base.Enter();

        stateMachine.state = "Remove Cases";

        switch (gameManager.DealerStageIndex)
        {
            case 0:
                uiManager.gameText.text = "Remove 4 Cases";
                numCasesToRemove = 4;
                break;
            case 1:
                uiManager.gameText.text = "Remove 3 Cases";
                numCasesToRemove = 3;
                break;
            case 2:
                uiManager.gameText.text = "Remove 2 Cases";
                numCasesToRemove = 2;
                break;
            case 3:
                uiManager.gameText.text = "Remove 1 Case";
                numCasesToRemove = 1;
                break;
        }

        uiManager.continueButton.onClick.AddListener(EndSelectACase);
    }

    public override void Tick()
    {
        base.Tick();

        RemoveCases();
    }

    public override void Exit()
    {
        base.Exit();

        uiManager.continueButton.onClick.RemoveListener(EndSelectACase);
    }

    // NEEDS WORK
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
                    if (caseSelected != null)
                        caseSelected.CaseSelected();

                    caseSelected = hit.collider.GetComponent<Case>();

                    caseSelected.CaseSelected();
                }
            }
        }
    }

    void EndSelectACase()
    {
        if (numCasesToRemove == 0)
        {
            stateMachine.ChangeState<DealerState>();
        }
    }
}
