using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float levelTime = 10;
    bool triggeredLevelFinished = false;
    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
