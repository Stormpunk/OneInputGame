using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemysToSpawn;
    public Transform[] spawnPoint;
    public List<GameObject> spawnedObjects;
    public int spawnCount;
    private int objIndex;
    private int spawnIndex;
    public bool mustSpawnObject;
    float startIn = 1;
    float every = 2;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            objIndex = Random.Range(0, enemysToSpawn.Length);
            GameObject go = Instantiate(enemysToSpawn[objIndex], spawnPoint[spawnIndex].position, Quaternion.identity);
            spawnedObjects.Add(go);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Gizmos.DrawSphere(spawnPoint[i].position, 0.5f);
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
