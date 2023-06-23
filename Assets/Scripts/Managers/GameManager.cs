using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPositions;
    private GameObject tempEnemy;
    private Weapon meleeWeapon = new Weapon("Melee", 1, 0);

    private bool isEnemySpawning;
    [SerializeField] private float enemySpawnRate;

    public ScoreManager scoreManager;
    public PickupSpawner pickupSpawner;
    

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
        Instantiate(enemyPrefab);
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
        return Player;
    }

    public Player Player { get; set; }
}
