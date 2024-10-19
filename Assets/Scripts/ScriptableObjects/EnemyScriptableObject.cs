using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Create Enemy Object")]
public class EnemyScriptableObject : ScriptableObject
{
    public EntityController EnemyPrefab;

    public int MaxHealth = 100;
    public float Speed = 5;
    public float Damage = 4;
}
