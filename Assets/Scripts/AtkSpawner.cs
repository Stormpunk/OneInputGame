using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSpawner : MonoBehaviour
{
    public float spawnTime;
    public float maxSpawntime;
    public GameObject atkPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            Object.Instantiate(atkPrefab, spawnPoint);
            spawnTime = maxSpawntime;
        }
    }
}
