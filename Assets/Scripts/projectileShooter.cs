using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectile;

    public float shootingInterval;
    public float shootingPower;
    private float lastShotTime;

    private Vector2 shootingDirection = new Vector2(-1, 0);

    // Use this for initialization
    void Start()
    {
        lastShotTime = shootingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        lastShotTime -= delta;

        if (lastShotTime <= 0)
        {
            lastShotTime = shootingInterval + lastShotTime;
            Shoot();
        }

    }

    private void Shoot()
    {
        GameObject _projectile = Instantiate(projectile);
        _projectile.transform.position = transform.position;
        _projectile.GetComponent<Rigidbody2D>().AddForce(shootingDirection * shootingPower);

        //projectile _projectileScript = _projectile.GetComponent<projectile>();
        //_projectileScript.speed = gameObject.GetComponent<enemyMovement_1>().speed * 3;
        //_projectileScript.movementDirection = new Vector2(-1, 0);
    }
}
