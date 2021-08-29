using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCasesState : GameState
{
    [SerializeField] int numCasesToRemove;
    public int NumCasesToRemove { get => numCasesToRemove; set => numCasesToRemove = value; }

    [SerializeField] Case caseSelected;
    public Case CaseSelected => caseSelected;

    [SerializeField] List<Case> casesToRemove;
    public List<Case> CasesToRemove { get => casesToRemove; set => casesToRemove = value; }

    [SerializeField] List<int> caseIndexesToRemove;
    public List<int> CaseIndexesToRemove { get => caseIndexesToRemove; set => caseIndexesToRemove = value; }

    public override void Enter()
    {
        base.Enter();

        stateMachine.state = "Remove Cases";

        switch (gameManager.DealerStageIndex)
        {
            case 0:
                uiManager.SetGameText("Remove 4 Cases");
                numCasesToRemove = 4;
                break;
            case 1:
                uiManager.SetGameText("Remove 3 Cases");
                numCasesToRemove = 3;
                break;
            case 2:
                uiManager.SetGameText("Remove 2 Cases");
                numCasesToRemove = 2;
                break;
            case 3:
                uiManager.SetGameText("Remove 1 Cases");
                numCasesToRemove = 1;
                break;
        }

        uiManager.ShowContinueUI();
        uiManager.ContinueButton.onClick.AddListener(EndRemoveCases);
        uiManager.ContinueButton.onClick.AddListener(audioManager.PlayRemoveCasesSFX);
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
        uiManager.ContinueButton.onClick.RemoveListener(audioManager.PlayRemoveCasesSFX);
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
            foreach (Case c in casesToRemove)
            {
                c.Removed = true;
                caseSelected.ClearCaseSelected();
            }

            gameManager.DealerStageIndex++;
            uiManager.RemoveCasesUI(caseIndexesToRemove);

            caseIndexesToRemove.Clear();

            stateMachine.ChangeState<DealerState>();
        }
    }
}
