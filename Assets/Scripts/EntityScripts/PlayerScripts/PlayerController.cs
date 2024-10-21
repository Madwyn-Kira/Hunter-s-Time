using UnityEngine;

public class PlayerController : EntityController
{
    [SerializeField]
    private WeaponController PlayersWeapon;

    public override WeaponController WeaponController { get { return PlayersWeapon; } }

    private PlayerScriptableObject _playerScriptableObject;

    public override void InitializeEntity<T>(T playerSettings)
    {
        base.InitializeEntity(playerSettings);

        _playerScriptableObject = playerSettings as PlayerScriptableObject;

        base._healthController.Initialize(GameManager.Instance._playerHPBar, _playerScriptableObject.MaxHealth);
        base._healthController.OnHealthChanged += ChangeHealth;
        base._healthController.OnDeath += Die;

        ChangeState(new PlayerIdleState());

        PlayersWeapon.Initialize();
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
        ChangeState(new PlayerDieState());
    }

    public void DestroyPlayer()
    {
        GameManager.Instance.EndGame();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        base._healthController.OnHealthChanged -= ChangeHealth;
        base._healthController.OnDeath -= Die;
    }
}
