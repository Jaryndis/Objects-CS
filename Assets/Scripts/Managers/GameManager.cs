using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [SerializeField] private Player playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPositions;
    private GameObject tempEnemy;
    private Weapon meleeWeapon = new Weapon("Melee", 1, 0);

    private Player player;

    private bool isEnemySpawning;
    [SerializeField] private float enemySpawnRate;

    public ScoreManager scoreManager;
    public PickupSpawner pickupSpawner;

    public Action OnGameStart;
    public Action OnGameEnd;

    private bool isPlaying;
    

    public static GameManager GetInstance()
    {
        return _instance;
    }


    void SetSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }

        _instance = this;
    }

    private void Awake()
    {
        SetSingleton();
    }

    private void Start()
    {
        isEnemySpawning = true;
        StartCoroutine(EnemySpawner());
    }

    void FindPlayer()
    {
        try
        {
            var player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
        catch (NullReferenceException e)
        {
            Debug.Log("No player in the scene");
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    void CreateEnemy()
    {
        tempEnemy = Instantiate(enemyPrefab);
        tempEnemy.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        tempEnemy.GetComponent<Enemy>().Weapon = meleeWeapon;
        tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2, 0.25f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CreateEnemy();
        }
    }

    IEnumerator EnemySpawner()
    {
        while (isEnemySpawning)
        {
            yield return new WaitForSeconds(1.0f/enemySpawnRate);
            CreateEnemy();
        }
    }

    public void NotifyDeath(Enemy enemy)
    {
        pickupSpawner.SpawnPickup(enemy.transform.position);
    }

    public Player GetPlayer()
    {
        return player;
    }

    public Player Player { get; set; }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public void StartGame()
    {
        enemySpawnRate = 1;

        player = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
        player.OnDeath += StopGame;
        isPlaying = true;
        
        OnGameStart?.Invoke();
        StartCoroutine(GameStarter());
    }

    private void StopGame()
    {
        EndGame();
    }

    IEnumerator GameStarter()
    {
        yield return new WaitForSeconds(2);
        isEnemySpawning = true;
        StartCoroutine(EnemySpawner());
    }

    public void EndGame()
    {
        enemySpawnRate = 0;
        ScoreManager.SetHighScore();

        StartCoroutine(GameStopper());

    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator GameStopper()
    {
        isEnemySpawning = false;
        yield return new WaitForSeconds(2);
        isPlaying = false;

        foreach (Enemy item in FindObjectsOfType(typeof(Enemy)))
        {
            Destroy(item.gameObject);
        }
        
        OnGameEnd?.Invoke();
    }
}
