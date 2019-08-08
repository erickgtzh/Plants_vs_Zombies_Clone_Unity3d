using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AtackSpawner : MonoBehaviour
{
    bool spawn = true;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;
    public Atacker[] atackerPrefab;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay,maxSpawnDelay));
            SpawnAtacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAtacker()
    {
        var attackerIndex = Random.Range(0, atackerPrefab.Length);
        Spawn(atackerPrefab[attackerIndex]);
    }

    private void Spawn(Atacker atacker)
    {
        Atacker newAttacker = Instantiate(atacker, transform.position, transform.rotation) as Atacker;
        newAttacker.transform.parent = transform;
    }
}
