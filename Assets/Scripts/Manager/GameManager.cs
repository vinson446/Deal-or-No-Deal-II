using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] int selectedCaseIndex;
    public int SelectedCaseIndex { get => selectedCaseIndex; set => selectedCaseIndex = value; }

    [SerializeField] string selectedCase;
    public string SelectedCase { get => selectedCase; set => selectedCase = value; }

    [Header("Debugger")]
    [SerializeField] int dealerStageIndex;
    public int DealerStageIndex { get => dealerStageIndex; set => dealerStageIndex = value; }

    [SerializeField] List<string> casesChecker;
    public List<string> CasesChecker { get => casesChecker; set => casesChecker = value; }
}
