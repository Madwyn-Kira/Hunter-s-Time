using UnityEngine;

public class EnemyAttackState : StateMachine
{
    private EntityController _controller;
    float distanceToPolayer = float.MaxValue;

    public override void EnterState<T>(T controler)
    {
        _controller = controler as EntityController;
        _controller.EntityAnimator?.SetInteger("State", 2);
    }

    public override void ExitState()
    {

    }

    public override void StateUpdate()
    {
        if (GameManager.Instance.CurrentPlayer == null)
        {
            _controller.ChangeState(new EnemyIdleState());
            return;
        }

        distanceToPolayer = Vector3.Distance(_controller.transform.position, GameManager.Instance.CurrentPlayer.transform.position);

        if (distanceToPolayer > _controller.WeaponController.WeaponData.range)
            _controller.ChangeState(new EnemyPatruleState());
    }
}
