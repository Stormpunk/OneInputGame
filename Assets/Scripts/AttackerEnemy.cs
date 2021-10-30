using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerEnemy : MonoBehaviour
{
    public int health;
    public int damage;
    //damage the player deals
    public int playerDamage;
    //this will be the damage the enemy does to the player
    public Transform player;
    public float coolDown;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        coolDown = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
