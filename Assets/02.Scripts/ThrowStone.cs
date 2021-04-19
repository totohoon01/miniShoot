using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStone : MonoBehaviour
{
    public GameObject stonePrefab;
    public Transform throwPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowInvoke());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.CompareTag("PLAYER"))
            {
                Throw();
            }
        }

    }
    void Throw()
    {
        Instantiate(stonePrefab, throwPos.position, throwPos.rotation);
    }

    IEnumerator ThrowInvoke()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            if (this.gameObject.CompareTag("DOG"))
            {
                Throw();
            }
        }
    }
}
