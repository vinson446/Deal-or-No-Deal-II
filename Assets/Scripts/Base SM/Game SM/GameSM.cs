using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSM : StateMachine
{
    public string state;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState<IntroState>();
    }
}
