using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player's Settings")]

    [SerializeField]
    private PlayerScriptableObject _playerPrefab;

    [SerializeField]
    private Transform _playerSpawnPosition;

    public Slider _playerHPBar;

    [Space(5)]
    [Header("Enemy's Settings")]

    [SerializeField]
    private List<EnemyScriptableObject> _enemiesPrefabs = new();

    [Space(5)]
    [Header("Another")]

    [SerializeField]
    private Joystick _joystick;

    public Joystick Joystick { get { return _joystick; } }
    public PlayerController CurrentPlayer { get { return _currentPlayer; } }
    public List<EnemyScriptableObject> EnemyPrefabsCollection { get { return _enemiesPrefabs; } }

    private PlayerController _currentPlayer;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(_playerPrefab.PlayerPrefab, _playerSpawnPosition.position, Quaternion.identity);
        _currentPlayer.InitializeEntity(_playerPrefab);
    }

    public void EndGame()
    {

    }
}
