using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyShips : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<ProjectileShooter>().enabled = false;
            collision.gameObject.transform.position *= 200;
            Destroy(collision.gameObject, 5f);
        }
    }
}
