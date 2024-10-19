using System.Collections;
using UnityEngine;

public class SimpleBowReloadComponent : MonoBehaviour, IReloadComponent
{
    private WeaponData _weaponData;

    public void Initialize(WeaponData weaponData)
    {
        _weaponData = weaponData;
    }

    public void Reload()
    {
        WaitUntilReload();
    }

    private IEnumerator WaitUntilReload()
    {
        yield return new WaitForSeconds(_weaponData.reloadTime);
    }
}
