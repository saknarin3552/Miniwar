using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrtNPCred : MonoBehaviour
{
    Animator anmin;
    SpriteRenderer sr;

    [SerializeField] int speed = 1;
    [SerializeField] Transform Player;
    [SerializeField] float closeDistance = 5f;
    [SerializeField] float longDistance = 7f;

    float distanceToPlayer = Mathf.Infinity;
    void Start()
    {
        anmin = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        DetectPlayer();
    }

    public void DetectPlayer()
    {
        distanceToPlayer = Vector2.Distance(Player.position, transform.position);
        if (distanceToPlayer <= longDistance)
        {
            anmin.SetInteger("NPCState", 1);
            sr.flipX = true;

            if (distanceToPlayer <= closeDistance)
            {
                anmin.SetInteger("NPCState", 2);

                FollowPlayer();
            }
        }
        else
        {
            anmin.SetInteger("NPCState", 0);
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closeDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, longDistance);
    }
}
