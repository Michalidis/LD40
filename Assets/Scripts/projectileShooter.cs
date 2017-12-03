using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectile;

    public float shootingInterval;
    public float shootingPower;
    private float lastShotTime;

    private SoundPlayer BoomBox;

    public Vector2 shootingDirection = new Vector2(-1, 0);

    // Use this for initialization
    void Start()
    {
        lastShotTime = shootingInterval;
        BoomBox = GameObject.Find("BoomBox").GetComponent<SoundPlayer>();
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

        BoomBox.PlaySound(SoundPlayer.SoundType.ProjectileShootSound, transform.position);

        StartCoroutine(FixOrientation(_projectile));
    }

    IEnumerator FixOrientation(GameObject pr)
    {
        yield return new WaitForSeconds(0.02f);
        if (pr != null)
            pr.GetComponent<ProjectileRotator>().FaceVelocity();
    }
}
