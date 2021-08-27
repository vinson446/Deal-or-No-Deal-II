using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCaseState : GameState
{
    [SerializeField] int selectedCaseNum;
    public int SelectedCaseNum { get => selectedCaseNum; set => selectedCaseNum = value; }

    [SerializeField] Case caseSelected;
    public Case CaseSelected => caseSelected;

    public override void Enter()
    {
        base.Enter();

        stateMachine.state = "Select a Case";

        uiManager.GameText.text = "Choose your Case";

        uiManager.ContinueButton.onClick.AddListener(EndChooseCase);
    }

    public override void Tick()
    {
        base.Tick();

        ChooseCase();
    }

    public override void Exit()
    {
        base.Exit();

        uiManager.ContinueButton.onClick.RemoveListener(EndChooseCase);
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
                    if (caseSelected != null)
                        caseSelected.CaseChosen();

                    caseSelected = hit.collider.GetComponent<Case>();

                    caseSelected.CaseChosen();
                }
            }
        }
    }

    void EndChooseCase()
    {
        if (selectedCaseNum != -1)
        {
            caseSelected.ClearCaseSelected();

            gameManager.SelectedCaseIndex = selectedCaseNum;

            stateMachine.ChangeState<RemoveCasesState>();
        }
    }
}
