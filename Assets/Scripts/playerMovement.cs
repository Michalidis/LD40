using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rigidbody2D;
    // Use this for initialization
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        speed *= (GameObject.Find("Upgrades").GetComponent<Upgrades>().movement_speed + 1);
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        _rigidbody2D.MovePosition(_rigidbody2D.position + movement * speed * Time.deltaTime);
    }
}
