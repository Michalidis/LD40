using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProperties : MonoBehaviour
{
    public Animator ani;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToDeflected()
    {
        int prevLayer = gameObject.layer;
        if (prevLayer != 12)
        {
            gameObject.layer = 12;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = ani.runtimeAnimatorController;
            foreach (var tr in gameObject.GetComponentsInChildren<TrailRenderer>())
            {
                tr.enabled = !tr.enabled;
            }
        }

    }

}
