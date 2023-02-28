using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxIdle : BaseState
{
    private float _accel;
    public FoxIdle(FoxMain stateMachine) : base("Idle", stateMachine){}
    public override void Enter()
    {
        base.Enter();
        _accel = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
