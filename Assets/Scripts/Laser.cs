﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float health = 50f;
    private void OnTriggerEnter2D(Collider2D thingThatBumpedIntoMe)
    {
        Debug.Log("triggers");
        DamageDealer damageDealer = thingThatBumpedIntoMe.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        else if (damageDealer)
        {
            ProcessHit(damageDealer);
        }

    }
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
