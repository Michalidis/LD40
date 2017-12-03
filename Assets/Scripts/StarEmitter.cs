using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEmitter : MonoBehaviour
{
    public int count;
    public GameObject star;

    public GameObject high;
    public GameObject low;
    public Vector2 starDirection;
    public float starSpeed;

    public float defaultEmitRate;
    private float timeToEmit;

    private float x, y, z;
    private float high_y, low_y;
    public Queue<GameObject> stars;
    // Use this for initialization
    void Start()
    {
        timeToEmit = defaultEmitRate;
        stars = new Queue<GameObject>();
        for (int i = 0; i < count; i++)
        {
            GameObject _star = Instantiate(star);

            _star.transform.position = high.transform.position;
            _star.transform.localScale /= 4;
            _star.transform.parent = transform;
            _star.name = string.Format("Star {0}", i + 1);
            _star.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            stars.Enqueue(_star);
        }

        Vector3 t = high.transform.position;
        x = t.x;
        z = t.z;

        high_y = t.y;
        low_y = low.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 0)
        {
            timeToEmit -= Time.deltaTime;
            if (timeToEmit <= 0)
            {
                GameObject _star = stars.Dequeue();
                y = Random.Range(low_y, high_y);
                _star.transform.position = transform.position;
                _star.transform.position += new Vector3(0f, y, 0f);
                _star.GetComponent<Rigidbody2D>().AddForce(starSpeed * starDirection * Random.Range(0.5f, 3f));
                timeToEmit = defaultEmitRate;
                count--;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(high.transform.position, 0.3f);
        Gizmos.DrawSphere(low.transform.position, 0.3f);
    }
}
