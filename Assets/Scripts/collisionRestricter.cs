using UnityEngine;

public class CollisionRestricter : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);     // Enemy Ships vs. Invisible Walls
        Physics2D.IgnoreLayerCollision(8, 13, true);    // Enemy Ships vs. Projectile Destroyers
        Physics2D.IgnoreLayerCollision(10, 9, true);    // Enemy Projectiles vs. Invisible Walls
        Physics2D.IgnoreLayerCollision(8, 10, true);    // Enemies vs. Enemy Projectiles
        Physics2D.IgnoreLayerCollision(10, 10, true);   // Enemy Projectiles vs. Enemy Projectiles

        Physics2D.IgnoreLayerCollision(9, 12, true);    // Walls vs. Reflected Projectiles
        Physics2D.IgnoreLayerCollision(12, 12, true);   // Reflected Projectiles vs. Reflected Projectiles

        Physics2D.IgnoreLayerCollision(15, 8, true);    // Star Emits vs. Enemies
        Physics2D.IgnoreLayerCollision(15, 10, true);   // Star Emits vs. Enemy Projectiles
        Physics2D.IgnoreLayerCollision(15, 12, true);   // Star Emits vs. Reflected Projectiles
        Physics2D.IgnoreLayerCollision(15, 9, true);    // Star Emits vs. Invisible Walls
        Physics2D.IgnoreLayerCollision(15, 13, true);   // Star Emits vs. Projectile Destroyers
        Physics2D.IgnoreLayerCollision(15, 0, true);    // Star Emits vs. Defaults
        Physics2D.IgnoreLayerCollision(15, 11, true);    // Star Emits vs. Visible Walls
        Physics2D.IgnoreLayerCollision(15, 15, true);   // Star Emits vs. Defaults

        Physics2D.IgnoreLayerCollision(14, 8, true);    // Star Emitters vs. Enemies
        Physics2D.IgnoreLayerCollision(14, 10, true);   // Star Emitters vs. Enemy Projectiles
        Physics2D.IgnoreLayerCollision(14, 12, true);   // Star Emitters vs. Reflected Projectiles
    }

    // Update is called once per frame
    void Update()
    {

    }
}
