using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float nextSpawn;
    public float defaultSpawnTime;
    private GameObject[] ArrayOfEnemies;

    public List<GameObject> AllEnemies;

    private float spawnRateIncrease;

    // Use this for initialization
    void Start()
    {
        Upgrades ups = GameObject.Find("Upgrades").GetComponent<Upgrades>();

        spawnRateIncrease = ups.enemy_spawn_speed;

        defaultSpawnTime *=
            1 - spawnRateIncrease;

        ArrayOfEnemies = new GameObject[] { AllEnemies[0] };
        GameObject[] _arrayOfEnemies;

        if (ups.Enemy2Unlocked)
        {
            _arrayOfEnemies = new GameObject[ArrayOfEnemies.Length + 1];
            ArrayOfEnemies.CopyTo(_arrayOfEnemies, 0);
            _arrayOfEnemies[ArrayOfEnemies.Length] = AllEnemies[1];
            ArrayOfEnemies = _arrayOfEnemies;
        }

        if (ups.Enemy3Unlocked)
        {
            _arrayOfEnemies = new GameObject[ArrayOfEnemies.Length + 1];
            ArrayOfEnemies.CopyTo(_arrayOfEnemies, 0);
            _arrayOfEnemies[ArrayOfEnemies.Length] = AllEnemies[2];
            ArrayOfEnemies = _arrayOfEnemies;
        }

        if (ups.Enemy4Unlocked)
        {
            _arrayOfEnemies = new GameObject[ArrayOfEnemies.Length + 1];
            ArrayOfEnemies.CopyTo(_arrayOfEnemies, 0);
            _arrayOfEnemies[ArrayOfEnemies.Length] = AllEnemies[3];
            ArrayOfEnemies = _arrayOfEnemies;
        }
    }

    public int difficulty;
    // Update is called once per frame
    void Update()
    {
        nextSpawn -= Time.deltaTime;
        if (nextSpawn <= 0)
        {
            if (Random.Range(0f, 1f) >= Mathf.Max(Mathf.Min((1 / Mathf.Pow(difficulty, 0.32f)), 0.7f) - spawnRateIncrease, 0f))
            {
                difficulty = difficulty + 1;
                InstantiateEnemy();
            }
            defaultSpawnTime -= Mathf.Pow(0.2f, 0.10f) / difficulty;
            defaultSpawnTime = Mathf.Max(defaultSpawnTime, 5f);
            nextSpawn = defaultSpawnTime;
        }
    }

    void InstantiateEnemy()
    {
        GameObject enemy = Instantiate(ArrayOfEnemies[Mathf.RoundToInt(Random.Range(0f, ArrayOfEnemies.Length - 1))]);

        enemyMovement_1 em = enemy.GetComponent<enemyMovement_1>();
        em.speed *= Random.Range(0.7f, 2.05f);
        em.speed /= (1 / Mathf.Pow(difficulty, 0.35f));

        ProjectileShooter[] ps = enemy.GetComponents<ProjectileShooter>();

        foreach (var _ps in ps)
        {
            _ps.shootingInterval *= (1 / Mathf.Pow(difficulty, 0.095f));
            _ps.shootingPower /= (1 / Mathf.Pow(difficulty, 0.08105f));
        }

        enemy.transform.position = transform.position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
