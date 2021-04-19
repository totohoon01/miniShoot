using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFloor : MonoBehaviour
{

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("PLAYER"))
        {
            Destroy(this.gameObject);
        }
    }
}
