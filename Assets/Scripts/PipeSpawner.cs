using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject PipeReference;

    public float SpawnRate = 1.0f;
    public float Progress = 0.0f;

    public float LowestPoint = -3.0f;
    public float HighestPoint = 1.0f;

    public bool bCanSpawn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
        GameObject.Find("GameManager").GetComponent<GameManager>().OnGameEnd.AddListener(Stop);
    }

    void Stop()
    {
        bCanSpawn = false;
    }
    void Spawn()
    {
        var offset = Random.Range(LowestPoint, HighestPoint);
        var spawnPosition = transform.position;
        spawnPosition.y += offset;
        Instantiate(PipeReference, spawnPosition, Quaternion.identity);
        
    }

    void Update()
    {
        if (bCanSpawn == false)
        {
            return;
        }

        if (Progress < SpawnRate)
        {
            Progress += Time.deltaTime;
        }
        else
        {
            Progress = 0.0f;
            Spawn();
        }
       
    }
}
