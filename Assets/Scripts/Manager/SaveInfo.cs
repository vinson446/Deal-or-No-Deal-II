using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInfo : MonoBehaviour
{
    [SerializeField] bool tookDeal;
    public bool TookDeal { get => tookDeal; set => tookDeal = value; }

    [SerializeField] int[] lastIndexes;
    public int[] LastIndexes { get => lastIndexes; set => lastIndexes = value; }

    [SerializeField] string[] lastCases;
    public string[] LastCases { get => lastCases; set => lastCases = value; }

    public static SaveInfo saveInfo;

    private void Awake()
    {
        if (saveInfo == null)
        {
            saveInfo = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ClearSave()
    {
       for (int i = 0; i < 2; i++)
        {
            lastIndexes[i] = -1;
            lastCases[i] = "";
        }
    }
}
