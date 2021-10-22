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
        isAttackingHeavy = true;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);
        if (hit.collider != null)
        {

        }
        attackReset = 3;
    }
    public void LightAttack()
    {
        isAttackingLight = true;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);
        if(hit.collider != null)
        {

        }
        attackReset = 1;
    }
}
