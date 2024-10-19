public class EnemyDieState : StateMachine
{
    private EntityController _controller;

    public override void EnterState<T>(T controler)
    {
        _controller = controler as EntityController;
        _controller.EntityAnimator?.SetInteger("State", 3);
    }

    public override void ExitState()
    {

    }

    public override void StateUpdate()
    {

    }
}
