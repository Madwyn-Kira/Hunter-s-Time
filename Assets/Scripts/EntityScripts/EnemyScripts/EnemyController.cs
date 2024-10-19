public class EnemyController : EntityController
{
    private EnemyScriptableObject _enemySettings;

    public override void InitializeEntity<T>(T enemySettings)
    {
        base.InitializeEntity(_enemySettings);

        _enemySettings = enemySettings as EnemyScriptableObject;

        base._healthController.Initialize(null, _enemySettings.MaxHealth);
        base._healthController.OnHealthChanged += ChangeHealth;
        base._healthController.OnDeath += Die;

        ChangeState(new EnemyIdleState());
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.StateUpdate();
        }
    }

    private void ChangeHealth(float amount)
    {

    }

    private void Die()
    {

    }

    private void OnDestroy()
    {
        base._healthController.OnHealthChanged -= ChangeHealth;
        base._healthController.OnDeath -= Die;
    }
}
