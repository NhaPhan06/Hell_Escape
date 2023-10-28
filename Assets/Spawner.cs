using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objToSpawn = new List<GameObject>();
    public float spawnTime;
    public float currentTimeToSpawn;
    public AudioClip spawnEffect;
    public bool isRandomized;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }
    public void UpdateTimer()
    {
        if (currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnObject();
            currentTimeToSpawn = spawnTime;
        }
    }
    public void SpawnObject()
    {
        ExecuteSpawnEffect();
        int index = isRandomized ? Random.Range(0, objToSpawn.Count) : 0;
        if(objToSpawn.Count > 0 )
        {
            Instantiate(objToSpawn[index], transform.position, transform.rotation);
        }
    }
    private void ExecuteSpawnEffect()
    {
        Instantiate(spawnEffect, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(spawnEffect, transform.position);
    }
}
