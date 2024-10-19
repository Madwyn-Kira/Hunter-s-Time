using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Create Player Object")]
public class PlayerScriptableObject : ScriptableObject
{
    public PlayerController PlayerPrefab;

    public int MaxHealth = 100;
    public float Speed = 9;
    public float Damage = 4;
}
