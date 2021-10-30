using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health;
    public int damage;
    public bool isAttackingLight;
    public bool isAttackingHeavy;
    public int stamina = 3;
    public int maxStamina = 3;
    public int stRegenDelay;
    public float attackCharge;
    private int resetCharge = 0;
    public int attackReset;
    public int damageRange;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        isAttackingHeavy = false;
        isAttackingLight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isAttackingHeavy && !isAttackingLight){
            attackCharge += Time.deltaTime;
        }
        //player initiates default attack, either light or heavy depends on the charge ammount
        if (Input.GetKeyUp(KeyCode.Space) && attackCharge >= 2 && stamina >= 2)
        {
            HeavyAttack();
        }
        if(Input.GetKeyUp(KeyCode.Space) && attackCharge <= 1 && stamina <= 1)
        {
            LightAttack();
        }
    }
    public void HeavyAttack()
    {
        //plays attack animation
        //detect any enemies hit in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //deals damage
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit" + enemy.name);
        }
        //has a vulnerability period
        attackReset = 3;
    }
    public void LightAttack()
    {
        attackReset = 1;
    }
}
