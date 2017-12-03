using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileReflecter : MonoBehaviour
{
    private Animator animator;
    public float influenceRadius;
    public float reflectPower;

    public float timeBetweenAttacks;
    public float timeLeftToAttack;

    public ParticleSystem OnReflect;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeftToAttack -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timeLeftToAttack <= 0)
        {
            GetComponent<Animator>().SetBool("isAttacking", true);
            ReflectProjectiles();
            timeLeftToAttack = timeBetweenAttacks;
        }
    }

    void ReflectProjectiles()
    {
        Vector2 reflectionCenter = gameObject.transform.position;

        var projectiles = Physics2D.OverlapCircleAll(reflectionCenter, influenceRadius)
            .Where(z => z.gameObject.layer == 10 || z.gameObject.layer == 12).ToArray();

        foreach (var projectile in projectiles)
        {
            Vector2 reflectDirection = projectile.transform.position - transform.position;

            Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(reflectDirection * reflectPower);

            ProjectileRotator prota = projectile.GetComponent<ProjectileRotator>();
            prota.FaceAwayFromDirection(transform.position);

            ProjectileProperties prop = projectile.GetComponent<ProjectileProperties>();
            prop.ChangeToReflected();

            ParticleSystem ps = Instantiate(OnReflect);
            ps.transform.position = projectile.transform.position;
            Destroy(ps, ps.main.startLifetime.constant);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(gameObject.transform.position, influenceRadius);
    }
}
