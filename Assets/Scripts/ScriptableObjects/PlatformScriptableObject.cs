using UnityEngine;

[CreateAssetMenu(fileName = "NewPlatform", menuName = "Create Platform Object")]
public class PlatformScriptableObject : ScriptableObject
{
    public int MaxEnemiesOnPlatform = 5;
    public float TimeToSpawnEnemy = 8f;
}
