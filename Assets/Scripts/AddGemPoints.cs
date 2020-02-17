using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGemPoints : MonoBehaviour
{
       private void OnTriggerEnter2D(Collider2D thingThatBumpedIntoMe)
    {
        DamageDealer damageDealer = thingThatBumpedIntoMe.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        } else {
            int points = damageDealer.GetDamage();
            FindObjectOfType<GameSession>().AddToScore(points);
            Destroy(gameObject);
        }
       
    }
}
