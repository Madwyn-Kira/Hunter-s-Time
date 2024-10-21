using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private PlatformScriptableObject _platformScriptableObject;

    [SerializeField]
    private Transform _enemySpawnPosition;

    public PlatformScriptableObject PlatformScriptableObject { get { return _platformScriptableObject; } }
    public Transform EnemySpawnPosition { get { return _enemySpawnPosition; } }
    public EnemySpawner EnemySpawner { get { return _enemySpawner; } }

    private EnemySpawner _enemySpawner;

    private void Start()
    {
        _enemySpawner = GetComponent<EnemySpawner>();
        _enemySpawner?.Initialize(this);
    }
}
