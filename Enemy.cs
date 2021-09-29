using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //public float speed = 3f;

    //[SerializeField] private float attackDamage = 10f;
    //[SerializeField] private float attackSpeed = 1f;

    //private float canAttack;

    //private Transform target;

    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    //public HpBarEnemy hpBar;

    void Start()
    {
        currentHealth = maxHealth;
        //hpBar.SetHealth(currentHealth, maxHealth);
    }

    /*private void FixedUpdate()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }*/

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        animator.SetBool("IsDead", true);

        Destroy(gameObject, 1f);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHealth.health -= 0.5f;
    }

}
