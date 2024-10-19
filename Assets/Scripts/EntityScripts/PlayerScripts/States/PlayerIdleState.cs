public class PlayerIdleState : StateMachine
{
    private EntityController _controller;

    public override void EnterState<T>(T controler)
    {
        _controller = controler as EntityController;
        _controller.EntityAnimator?.SetInteger("State", 0);
    }

    public override void ExitState()
    {

    }

    public override void StateUpdate()
    {
        if (GameManager.Instance.Joystick.Horizontal > 0 || GameManager.Instance.Joystick.Vertical > 0)
            _controller.ChangeState(new PlayerMoveState());
    }
}
