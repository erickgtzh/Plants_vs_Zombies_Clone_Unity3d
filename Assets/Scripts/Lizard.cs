using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        // Leave the method if not colliding with defender
        if (obj.GetComponent<Defender>())
        {
            GetComponent<Atacker>().Attack(obj);
        }
    }
}
