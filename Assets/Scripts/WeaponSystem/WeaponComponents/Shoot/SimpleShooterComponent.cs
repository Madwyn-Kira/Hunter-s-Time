using UnityEngine;

public class SimpleShooterComponent : MonoBehaviour, IShootComponent
{
    private WeaponData _weaponData;

    public void Initialize(WeaponData data)
    {
        _weaponData = data;
    }

    public void Shoot()
    {

    }
}
