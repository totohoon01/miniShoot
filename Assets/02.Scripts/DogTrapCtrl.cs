using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTrapCtrl : MonoBehaviour
{
    private Rigidbody rd;
    private int triActive = Animator.StringToHash("triActive");
    private Animator anim;
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("PLAYER"))
        {
            Invoke("Push", 1.5f);
            Destroy(this.gameObject, 5.0f);
        }
    }
    void Push()
    {
        rd.AddRelativeForce(Vector3.forward * 4000.0f);
    }
}
