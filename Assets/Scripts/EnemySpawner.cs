using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float nextSpawn;
    public float defaultSpawnTime = 20f;
    public GameObject[] ArrayOfEnemies;


    // Use this for initialization
    void Start()
    {

    }

    public int difficulty;
    // Update is called once per frame
    void Update()
    {
        nextSpawn -= Time.deltaTime;
        if (nextSpawn <= 0)
        {
            nextSpawn = defaultSpawnTime / Mathf.Pow(difficulty, 0.42f);
            if (Random.Range(0f, 1f) > Mathf.Min((1 / Mathf.Pow(difficulty, 0.32f)), 0.7f))
            {
                difficulty = difficulty + 1;
                InstantiateEnemy();
            }
        }
    }

    void InstantiateEnemy()
    {
        GameObject enemy = Instantiate(ArrayOfEnemies[Mathf.RoundToInt(Random.Range(0f, ArrayOfEnemies.Length - 1))]);

        enemy.GetComponent<enemyMovement_1>().speed /= (1 / Mathf.Pow(difficulty, 0.15f));
        ProjectileShooter[] ps = enemy.GetComponents<ProjectileShooter>();

        foreach (var _ps in ps)
        {
            _ps.shootingInterval *= (1 / Mathf.Pow(difficulty, 0.25f));
            _ps.shootingPower /= (1 / Mathf.Pow(difficulty, 0.105f));
        }

        enemy.transform.position = transform.position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
