using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCtrl : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 800.0f);
        Destroy(this.gameObject, 3.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PLAYER"))
        {
            collision.transform.Translate(new Vector3(-3, 0, 0), Space.World);
            // collision.gameObject.transform.Translate(-new Vector3(5, 0, 0));
        }
    }
}
