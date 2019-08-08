using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public int starCost = 100;

    public int GetStartCost()
    {
        return starCost;
    }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    var a = collision.GetComponent<Defender>();
    //    Debug.Log(a.name);
    //}

}
