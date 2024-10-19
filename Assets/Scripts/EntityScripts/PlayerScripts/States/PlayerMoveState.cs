using UnityEngine;

public class PlayerMoveState : StateMachine
{
    private EntityController _controller;
    private float _changeAnimationsBySpeed = 6;

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
        float xPosition = -GameManager.Instance.Joystick.Vertical;
        float yPosition = GameManager.Instance.Joystick.Horizontal;

        if (xPosition != 0 || yPosition != 0)
        {
            Vector3 moveDirection = new Vector3(xPosition, 0, yPosition);
            Vector3 movePosition = _controller.transform.position + moveDirection;
            _controller.NavAgent.SetDestination(movePosition);

            if(Mathf.Abs(_controller.NavAgent.velocity.x) >= _changeAnimationsBySpeed 
                || Mathf.Abs(_controller.NavAgent.velocity.z) >= _changeAnimationsBySpeed)
                _controller.EntityAnimator?.SetInteger("State", 2);
            else
                _controller.EntityAnimator?.SetInteger("State", 1);
        }
        else
        {
            _controller.NavAgent.SetDestination(_controller.transform.position);
        }

        if (GameManager.Instance.Joystick.Horizontal == 0 || GameManager.Instance.Joystick.Vertical == 0)
            _controller.ChangeState(new PlayerIdleState());
    }
}
