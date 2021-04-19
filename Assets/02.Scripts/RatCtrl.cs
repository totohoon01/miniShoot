using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatCtrl : MonoBehaviour
{
    public float traceDist = 30.0f;
    public float attackDist = 5.0f;
    private Animator anim;
    private Transform ratTr;
    private Transform playerTr;
    private NavMeshAgent nav;

    //Anim Vars
    private int isWalk = Animator.StringToHash("isWalk");
    private int isAttack = Animator.StringToHash("isAttack");
    private int gotHit = Animator.StringToHash("gotHit");


    private int hitCount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        ratTr = GetComponent<Transform>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        CheckDist();
    }

    void CheckDist()
    {
        nav.SetDestination(playerTr.position);
        nav.isStopped = false;
        float dist = Vector3.Distance(ratTr.position, playerTr.position);
        if (dist <= attackDist)
        {
            anim.SetBool(isAttack, true);
        }
        else if (dist <= traceDist)
        {
            anim.SetBool(isAttack, false);
            anim.SetBool(isWalk, true);
        }
        else
        {
            anim.SetBool(isAttack, false);
            anim.SetBool(isWalk, false);
            nav.isStopped = true;
        }


    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("STONE"))
        {
            anim.SetTrigger("gotHit");
            hitCount++;
            if (hitCount >= 5)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
