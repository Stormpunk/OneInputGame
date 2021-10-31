using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefSpawner : MonoBehaviour
{
    public float spawnTime;
    public float maxSpawnTime;
    public GameObject defPrefab;
    public Transform spawnPointDEF;
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
            Object.Instantiate(defPrefab, spawnPointDEF);
            spawnTime = maxSpawnTime;
        }
    }
}
