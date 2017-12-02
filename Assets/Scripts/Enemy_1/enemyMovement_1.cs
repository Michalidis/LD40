using UnityEngine;

public class enemyMovement_1 : MonoBehaviour
{
    public float speed;
    public Vector2 movementDirection;

    private Rigidbody2D _rigidbody2D;
    // Use this for initialization
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + movementDirection * speed);
    }
}
