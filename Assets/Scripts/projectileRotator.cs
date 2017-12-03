using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(ProjectileProperties))]
public class ProjectileRotator : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public ParticleSystem onBounce;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        int colLayer = collision.gameObject.layer;
        if (colLayer == 10 || colLayer == 11 || colLayer == 12)
        {
            FaceVelocity();
            if (colLayer == 11)
                EmitParticle(collision.contacts, onBounce);
        }
        else
            Destroy(gameObject);
    }

    void EmitParticle(ContactPoint2D[] targetPositions, ParticleSystem toEmit)
    {
        foreach (var pos in targetPositions)
        {
            ParticleSystem ps = Instantiate(toEmit);
            ps.transform.position = pos.point;
            Destroy(ps, 5f);
        }
    }

    float magicConstant = 10000f;

    public void FaceAwayFromDirection(Vector3 faceAwayFrom)
    {
        Vector3 vectorToTarget = transform.position - faceAwayFrom;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, magicConstant);
    }

    public void FaceVelocity()
    {
        Vector2 v = rigidBody.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
