using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacker : MonoBehaviour
{
    [Range(0f, 5f)] float currentSpeed;
    private GameObject currentTarget;
    public float seenEverySeconds;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().AttackerKiller();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (currentTarget==false)
        {
            GetComponent<Animator>().SetBool("isAttacking",false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);

        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget==false)
        {
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
