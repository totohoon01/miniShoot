using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //플레이어 움직임 파라미터
    private float h;
    private float v;
    private float r;
    private float moveSpeed = 5.0f;
    private float rotateSpeed = 80.0f;

    private Transform tr;
    private Animator anim;
    private Rigidbody rb;
    private readonly int isFall = Animator.StringToHash("isFall");
    private readonly int isMove = Animator.StringToHash("isMove");
    private readonly int triEnd = Animator.StringToHash("triEnd");

    private int hitCount = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        yield return new WaitForSeconds(1.0f);
        rotateSpeed = 50.0f;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        MoveCharacter();
        RotateCharacter();
        SetAnimation();
        PlyaerDie();
    }
    void MoveCharacter()
    {
        Vector3 moveDir = Vector3.forward * v + Vector3.right * h;
        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);
    }
    void RotateCharacter()
    {
        Vector3 rotDir = Vector3.up * r;
        tr.Rotate(rotDir.normalized * Time.deltaTime * rotateSpeed);
    }

    void PlyaerDie()
    {
        if (tr.transform.position.y < -1)
        {
            anim.SetBool(isFall, true);
        }
        if (tr.transform.position.y < -30)
        {
            anim.SetBool(isFall, false);
            gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }

    void SetAnimation()
    {
        if (h != 0 || v != 0)
        {
            anim.SetBool(isMove, true);
        }
        else
        {
            anim.SetBool(isMove, false);
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("RAT"))
        {
            hitCount++;
            tr.Translate(new Vector3(0, 0.7f, -2f), Space.Self);
            if (hitCount > 5)
            {
                hitCount = 0;
                gameObject.transform.position = new Vector3(0, 0, 0);
            }
        }

    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("END"))
        {
            anim.SetTrigger(triEnd);
        }
    }
}
