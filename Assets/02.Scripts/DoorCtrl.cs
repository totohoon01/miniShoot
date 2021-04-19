using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
    private int hitCount = 0;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("STONE"))
        {
            hitCount++;
            Debug.Log(hitCount);
            if (hitCount >= 5)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
