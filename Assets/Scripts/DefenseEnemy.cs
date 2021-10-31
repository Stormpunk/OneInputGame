using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseEnemy : MonoBehaviour
{
    public int health;
    float moveSpeed = 5f;
    public float playerDamage = 1f;
    //the damage that will be dealt to the player. 
    public Transform player;
    public float deathDelay;
    public float coolDown;
    public float stopDistance = 1.5f;
    public Animator defAnim;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerMask;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        coolDown = 5;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stopDistance)
        {
            transform.position = this.transform.position;
        }
        if(health <= 0)
        {
            deathDelay -= Time.deltaTime;
        }
        if (coolDown >= 0)
        {
            coolDown -= Time.deltaTime;
            defAnim.ResetTrigger("Attacking");
        }
        if (coolDown <= 0 && (transform.position == this.transform.position))
        {
            Attack();
        }
        if(isDead == true)
        {
            Death();
        }
    }
    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isDead = true;
        }
        if (!isDead)
        {
            defAnim.SetTrigger("TakeDamage");
        }
        else
        {
            defAnim.SetTrigger("Death");
        }
    }
    public void Death()
    {
        if(deathDelay <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Attack()
    {
        defAnim.SetTrigger("Attacking");
        Collider2D[] player = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);
        foreach (Collider2D hero in player)
        {
            Debug.Log("Hit" + hero.name);
            hero.GetComponent<PlayerController>().Damage(3);
        }
        coolDown = 6;
    }
}
