using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gun;

    private GameObject projectileParent;
    private Animator animator;
    private AtackSpawner myLaneSpawner;

    void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();

        projectileParent = GameObject.Find("Projectile");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectile");
        }

        SetMyLaneSpawner();
    }

    void Update()
    {
        if (myLaneSpawner == null)
            return;
        else if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMyLaneSpawner()
    {
        AtackSpawner[] spawnerArray = GameObject.FindObjectsOfType<AtackSpawner>();

        foreach (AtackSpawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
    }

    bool IsAttackerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        foreach (Transform attacker in myLaneSpawner.transform)
        {
            if (attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}