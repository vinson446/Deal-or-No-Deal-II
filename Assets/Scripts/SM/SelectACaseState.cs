using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectACaseState : GameState
{
    [SerializeField] int selectedCaseNum;
    public int SelectedCaseNum { get => selectedCaseNum; set => selectedCaseNum = value; }

    [SerializeField] Case caseSelected;
    public Case CaseSelected => caseSelected;

    public override void Enter()
    {
        base.Enter();

        stateMachine.state = "Select a Case";

        uiManager.gameText.text = "Choose your Case";

        uiManager.continueButton.onClick.AddListener(EndSelectACase);
    }

    public override void Tick()
    {
        base.Tick();

        ChooseACase();
    }

    public override void Exit()
    {
        base.Exit();

        uiManager.continueButton.onClick.RemoveListener(EndSelectACase);
    }

    void ChooseACase()
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
        if (selectedCaseNum != -1)
        {
            gameManager.CaseIndex = selectedCaseNum;

            stateMachine.ChangeState<RemoveCasesState>();
        }
    }
}
