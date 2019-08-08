using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float timeToFinish = 3f;
    public float waitToLoad = 3f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    public GameObject winLabel;
    new AudioSource audio;

    void Start()
    {
        winLabel.SetActive(false);
        audio.Play();
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;

    }

    public void AttackerKiller()
    {
        timeToFinish--;
        numberOfAttackers--;

        //if (timeToFinish == 0)
        //{
        //    //StartCoroutine(HandleWinCondition());
        //    FindObjectOfType<LevelLoader>().LoadNextScene();
        //    winLabel.SetActive(true);
        //}
        //numberOfAttackers--;
        if (timeToFinish==0) 
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        LevelTimerFinished();
        winLabel.SetActive(true);
        FindObjectOfType<LevelLoader>().LoadNextScene();
        yield return new WaitForSeconds(waitToLoad);
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AtackSpawner[] atackSpawners = FindObjectsOfType<AtackSpawner>();
        foreach(AtackSpawner spawner in atackSpawners)
        {
            spawner.StopSpawning();
        }
    }
}
