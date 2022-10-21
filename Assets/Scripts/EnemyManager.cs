using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; } = null;

    public event Action<int> OnEnemyCountChanged = delegate {  };

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemySpawnTime = 3f;
    
    private WaitForSeconds enemySpawnWait;
    private List<Vector3> OpenSlots = new List<Vector3>();

    private int enemiesAlive = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        enemySpawnWait = new WaitForSeconds(enemySpawnTime);

        for (int i = 0; i <= 6; i++)
        {
            OpenSlots.Add(new Vector3((i-3) * 1.1f, 0,15f));
        }
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnEnemies());
    }

    private void OnEnemyDeathActions(Transform enemyTransform)
    {
        enemiesAlive--;
        OnEnemyCountChanged?.Invoke(enemiesAlive);
        OpenSlots.Add(enemyTransform.position);
    }

    public IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (OpenSlots.Count > 0)
            {
                var slot = Random.Range(0, OpenSlots.Count);
                var go = Instantiate(enemyPrefab, OpenSlots[slot], Quaternion.identity);
                enemiesAlive++;
                OnEnemyCountChanged?.Invoke(enemiesAlive);
                var deathComponent = go.GetComponent<ProjectileCollision>();
                deathComponent.OnDeath += OnEnemyDeathActions;
                OpenSlots.Remove(OpenSlots[slot]);
            }

            yield return enemySpawnWait;
        }
    }
}
