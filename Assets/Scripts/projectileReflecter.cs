using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class projectileReflecter : MonoBehaviour
{

    public float influenceRadius;
    public float reflectPower;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ReflectProjectiles();
    }

    void ReflectProjectiles()
    {
        Vector2 reflectionCenter = gameObject.transform.position;

        var projectiles = Physics2D.OverlapCircleAll(reflectionCenter, influenceRadius)
            .Where(z => z.gameObject.layer == 10).ToArray();

        foreach (var projectile in projectiles)
        {
            Vector2 reflectDirection = projectile.transform.position - transform.position;

            Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(reflectDirection * reflectPower);

            projectileRotator prota = projectile.GetComponent<projectileRotator>();
            prota.FaceAwayFromDirection(transform);
        }
    }
}
