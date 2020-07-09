using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemySpawner : MonoBehaviour {

    public List<Transform> enemyPrefabs = new List<Transform>();

    public float spawnSpeed = 2.0f;

    public Transform enemyParent;

    public void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnSpeed);
    }

    // Use this for initialization
    void Start () {

        GetComponent<BoxCollider>().isTrigger = true;        
	}
	
    Vector3 GetRandomBoxPoint()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        Vector3 max = boxCollider.bounds.max;
        Vector3 min = boxCollider.bounds.min;

        return new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z));
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Count > 0)
        {
            UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
            int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Count);
                       
            GameObject enemy = GameObject.Instantiate(enemyPrefabs[randomIndex], GetRandomBoxPoint(), Quaternion.identity).gameObject;
            enemy.GetComponent<Enemy>().spawnerCollider = GetComponent<BoxCollider>();

            enemy.transform.parent = enemyParent;

        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
