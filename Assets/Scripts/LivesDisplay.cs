using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public int lives = 5;
    Text liveText;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        liveText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        liveText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives = lives - damage;
        UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadYouLose();
        }
    }
}
