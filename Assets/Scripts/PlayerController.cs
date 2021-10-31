using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float health;
    #region Combat Variables
    public int damage;
    public int stamina = 3;
    public int maxStamina = 3;
    public float stRegenDelay;
    public float attackCharge;
    public float attackReset;
    public float deathCountdown;
    public int damageRange;
    public bool isDead;
    #endregion
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public Animator m_Anim;
    public Text hpText;
    public Text staminaText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region Attack Controls
        if (Input.GetKey(KeyCode.Space)) {
            attackCharge += Time.deltaTime;
        }
        //player initiates default attack, either light or heavy depends on the charge ammount
        if (Input.GetKeyUp(KeyCode.Space) && attackCharge >= 1 && stamina >= 2 && attackReset <= 0)
        {
            HeavyAttack();
            attackCharge = 0;
        }
        if (Input.GetKeyUp(KeyCode.Space) && attackCharge < 1 && stamina >= 1 && attackReset <= 0)
        {
            LightAttack();
            attackCharge = 0;
        }
        if (attackReset >= 0)
        {
            attackReset -= Time.deltaTime;
        }
        #endregion
        if (stamina <= 3 && (stRegenDelay >= 0))
        {
            stRegenDelay -= Time.deltaTime;
        }
        if (stRegenDelay <= 0)
        {
            stamina = 3;
            stRegenDelay = 3;
        }
        if(health <= 0)
        {
            deathCountdown -= Time.deltaTime;
        }
        if(deathCountdown <= 0 && (isDead = true))
        {
            Death();
        }
        staminaText.text = "Stamina: " + stamina.ToString();
        hpText.text = "Health: " + health.ToString();


    }
    public void HeavyAttack()
    {
        stamina -= 2;
        attackReset = 2;
        //plays attack animation
        m_Anim.SetTrigger("HeavyAttacking");
        Debug.Log("Heavy Attack!");
        //detect any enemies hit in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //deals damage
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit" + enemy.name);
            if (enemy.CompareTag("defenseEnemy"))
            {
                enemy.GetComponent<DefenseEnemy>().Damage(3);
            }
            else if (enemy.CompareTag("attackEnemy"))
            {
                enemy.GetComponent<AttackerEnemy>().Damage(3);
            }
        }
        //has a vulnerability period
        attackReset = 3;
    }
    public void LightAttack()
    {
        stamina -= 1;
        m_Anim.SetTrigger("LightAttacking");
        Debug.Log("LightAttack!");
        attackReset = 0.5f;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            if (enemy.CompareTag("defenseEnemy"))
            {
                enemy.GetComponent<DefenseEnemy>().Damage(1);
            }
            else if (enemy.CompareTag("attackEnemy"))
            {
                enemy.GetComponent<AttackerEnemy>().Damage(1);
            }

        }
    }
    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            isDead = true;
        }
        if (!isDead)
        {
            m_Anim.SetTrigger("IsDamaged");
        }
        else
        {
            m_Anim.SetTrigger("IsDead");
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
