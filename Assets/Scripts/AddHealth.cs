using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D thingThatBumpedIntoMe)
    {
        DamageDealer damageDealer = thingThatBumpedIntoMe.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        } else {
            FindObjectOfType<Player>().AddHealth(damageDealer);
            Destroy(gameObject);
        }
       
    }
}
