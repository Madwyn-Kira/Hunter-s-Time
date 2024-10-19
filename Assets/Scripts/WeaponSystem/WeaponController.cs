using UnityEngine;

public class WeaponController : MonoBehaviour, IWeapon
{
    [SerializeField]
    private WeaponData weaponData;

    [SerializeField]
    private AmmunitionData ammunitionData;

    private IShootComponent _shootComponent;
    private IReloadComponent _reloadComponent;

    public void Initialize()
    {
        _shootComponent = GetComponent<IShootComponent>();
        _reloadComponent = GetComponent<IReloadComponent>();

        _shootComponent.Initialize(weaponData);
    }

    public void Fire()
    {
        _shootComponent.Shoot();
        _reloadComponent.Reload();
    }
}
