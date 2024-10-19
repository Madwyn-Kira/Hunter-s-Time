public class EnemyPatruleState : StateMachine
{
    private EntityController _controller;

    public override void EnterState<T>(T controler)
    {
        _controller = controler as EntityController;
        _controller.EntityAnimator?.SetInteger("State", 1);
    }

    public override void ExitState()
    {

    }

    public override void StateUpdate()
    {
        if (GameManager.Instance.CurrentPlayer == null)
            _controller.ChangeState(new EnemyIdleState());

        _controller.NavAgent.SetDestination(GameManager.Instance.CurrentPlayer.transform.position);
    }
}
