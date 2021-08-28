using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] Dictionary<int, string> cases = new Dictionary<int, string>();
    public Dictionary<int, string> Cases => cases;

    [SerializeField] int selectedCaseIndex;
    public int SelectedCaseIndex { get => selectedCaseIndex; set => selectedCaseIndex = value; }

    [SerializeField] string selectedCase;
    public string SelectedCase { get => selectedCase; set => selectedCase = value; }

    [SerializeField] string endDeal;
    public string EndDeal { get => endDeal; set => endDeal = value; }

    [Header("Debugger")]
    [SerializeField] int dealerStageIndex;
    public int DealerStageIndex { get => dealerStageIndex; set => dealerStageIndex = value; }

    [SerializeField] List<string> casesChecker;
    public List<string> CasesChecker { get => casesChecker; set => casesChecker = value; }

    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
