using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerEnemy : MonoBehaviour
{
    public int health;
    float moveSpeed = 10f;
    public float stopDistance = 1.5f;
    public int playerDamage;
    //this will be the damage the enemy does to the player
    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerMask;
    public Transform player;
    public float coolDown;
    public Animator atkAnim;
    public float deathCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        coolDown = 3;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopDistance)
        {
            transform.position = this.transform.position;
        }
        #endregion
        #region Damage And Death
        if (health <= 0)
        {
            deathCount -= Time.deltaTime;
        }
        if(health <= 0 && deathCount<= 0) 
        {
            Death();
        }
        #endregion
        if(coolDown >= 0)
        {
            coolDown -= Time.deltaTime;
            atkAnim.ResetTrigger("Attack");
        }
        if(coolDown <= 0 && (transform.position == this.transform.position) && (health > 0))
        {
            Attack();
        }

    }
    public void Damage(int damage)
    {
        health -= damage;
        atkAnim.SetTrigger("Death");
    }
    public void Death()
    {
        Destroy(gameObject);
        
    }
    public void Attack()
    {
        atkAnim.SetTrigger("Attack");
        Collider2D[] player = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);
        foreach (Collider2D hero in player)
        {
            Debug.Log("Hit" + hero.name);
            hero.GetComponent<PlayerController>().Damage(1);
        }
        coolDown = 3;
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
