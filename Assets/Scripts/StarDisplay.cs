using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    public int stars = 100;
    public Text startText;
    new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        startText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        startText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        if (stars >= amount)
        {
            startText.color = new Color32(255, 255, 0, 255);
            return true;
        }
        else
        {
            startText.color = new Color32(240, 27, 36, 255);
            return false;
        }
            
    }

    public void AddStars(int amount)
    {
        stars = stars + amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars = stars - amount;
            UpdateDisplay();
        }
    }
}
