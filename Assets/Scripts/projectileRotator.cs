using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileRotator : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    float magicConstant = 10000f;
    public void FaceAwayFromDirection(Transform faceAwayFrom)
    {
        Vector3 vectorToTarget = transform.position - faceAwayFrom.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, magicConstant);
    }
}
