using UnityEngine;

public class EnemyPatruleState : StateMachine
{
    private EntityController _controller;
    float distanceToPolayer = float.MaxValue;

    public override void EnterState<T>(T controler)
    {
        _controller = controler as EntityController;

        _controller.NavAgent.isStopped = false;
        _controller.EntityAnimator?.SetInteger("State", 1);
    }

    public override void ExitState()
    {
        _controller.NavAgent.isStopped = true;
    }

    public override void StateUpdate()
    {
        if (GameManager.Instance.CurrentPlayer == null)
        {
            _controller.ChangeState(new EnemyIdleState());
            return;
        }

        _controller.NavAgent.SetDestination(GameManager.Instance.CurrentPlayer.transform.position);

        distanceToPolayer = Vector3.Distance(_controller.transform.position, GameManager.Instance.CurrentPlayer.transform.position);

        if (distanceToPolayer <= _controller.WeaponController.WeaponData.range)
            _controller.ChangeState(new EnemyAttackState());
    }
}
