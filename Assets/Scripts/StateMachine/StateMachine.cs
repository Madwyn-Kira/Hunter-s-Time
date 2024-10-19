using UnityEngine;

public abstract class StateMachine
{
    public abstract void EnterState<T>(T controler);
    public abstract void ExitState();

    public abstract void StateUpdate();
}
