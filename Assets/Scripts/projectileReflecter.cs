using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileReflecter : MonoBehaviour
{
    private SoundPlayer BoomBox;
    private Animator animator;
    public float influenceRadius;
    public float deflectPower;

    public float timeBetweenAttacks;
    public float timeLeftToAttack;

    public ParticleSystem OnReflect;

    public int ProjectileSplitCount;
    public float ProjectileSplitChance;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        BoomBox = GameObject.Find("BoomBox").GetComponent<SoundPlayer>();

        Upgrades upgrData = GameObject.Find("Upgrades").GetComponent<Upgrades>();
        deflectPower *= (upgrData.deflect_power + 1);
        influenceRadius *= (upgrData.deflect_radius + 1);
        timeBetweenAttacks = Mathf.Max(timeBetweenAttacks + (upgrData.deflect_rate * timeBetweenAttacks), 0.175f);

        ProjectileSplitChance = upgrData.projectile_split_chance;
        ProjectileSplitCount = (int)upgrData.projectile_split_count;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeftToAttack -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timeLeftToAttack <= 0 && !GetComponent<Animator>().GetBool("isAttacking"))
        {
            GetComponent<Animator>().SetBool("isAttacking", true);
            timeLeftToAttack = Mathf.Max(timeBetweenAttacks, 0);
        }
    }

    public PersistentInfoManager Manager;

    public void DeflectProjectiles()
    {
        Vector2 reflectionCenter = gameObject.transform.position;

        var projectiles = Physics2D.OverlapCircleAll(reflectionCenter, influenceRadius)
            .Where(z => z.gameObject.layer == 10 || z.gameObject.layer == 12).ToArray();

        foreach (var projectile in projectiles)
        {
            Vector2 reflectDirection = projectile.transform.position - transform.position;

            Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(reflectDirection * deflectPower);

            ProjectileRotator prota = projectile.GetComponent<ProjectileRotator>();
            prota.FaceAwayFromDirection(transform.position);

            ProjectileProperties prop = projectile.GetComponent<ProjectileProperties>();
            prop.ChangeToDeflected();

            SplitProjectile(projectile.gameObject, reflectDirection);

            ParticleSystem ps = Instantiate(OnReflect);
            ps.transform.position = projectile.transform.position;
            Destroy(ps.gameObject, 5f);
        }

        Manager.DeflectedProjectilesCount_Current += projectiles.Length;

        if (projectiles.Length > 0)
            BoomBox.PlaySound(SoundPlayer.SoundType.Deflect, transform.position);
        else
            BoomBox.PlaySound(SoundPlayer.SoundType.Swish, transform.position);
    }

    void SplitProjectile(GameObject projectile, Vector2 Direction)
    {
        for (int i = 0; i < ProjectileSplitCount; i++)
        {
            if (Random.Range(0f, 1f) <= ProjectileSplitChance)
            {
                GameObject proj = Instantiate(projectile);
                proj.transform.position = projectile.transform.position;
                proj.name = "Projectile_Split";
                Vector2 v;
                if (i % 2 == 0) v = new Vector2(0, Direction.y / (i + 2));
                else v = new Vector2(Direction.x / (i + 2), 0);
                proj.GetComponent<Rigidbody2D>().AddForce((Direction - v) * deflectPower);
                proj.GetComponent<ProjectileRotator>().FaceAwayFromDirection(transform.position);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(gameObject.transform.position, influenceRadius);
    }
}
