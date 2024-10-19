using UnityEngine;
using UnityEngine.AI;

public abstract class EntityController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private Animator _entityAnimator;

    public NavMeshAgent NavAgent { get { return _navMeshAgent; } }
    public Animator EntityAnimator { get { return _entityAnimator; } }

    protected HealthController _healthController;
    protected StateMachine _currentState;

    public virtual void InitializeEntity<T>(T settings)
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _entityAnimator = GetComponent<Animator>();
        _healthController = GetComponent<HealthController>();
    }

    public virtual void ChangeState(StateMachine _state)
    {
        if (_currentState != null)
            _currentState.ExitState();

        _currentState = _state;
        _currentState.EnterState(this);
    }
}
