using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] Dictionary<int, string> cases = new Dictionary<int, string>();
    public Dictionary<int, string> Cases => cases;

    [SerializeField] int caseIndex;
    public int CaseIndex { get => caseIndex; set => caseIndex = value; }

    [SerializeField] int dealerStageIndex;
    public int DealerStageIndex => dealerStageIndex;

    [Header("Debugger")]
    public List<string> casesChecker;

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
