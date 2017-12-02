﻿using UnityEngine;

public class CollisionRestricter : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);     // Enemy Ships vs. Walls
        Physics2D.IgnoreLayerCollision(10, 9, true);    // Enemy Projectiles vs. Enemies
        Physics2D.IgnoreLayerCollision(8, 10, true);    // Walls vs. Enemy Projectiles
        Physics2D.IgnoreLayerCollision(10, 10, true);   // Enemy Projectiles vs. Enemy Projectiles
    }

    // Update is called once per frame
    void Update()
    {

    }
}
