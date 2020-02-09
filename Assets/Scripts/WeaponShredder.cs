using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShredder : MonoBehaviour
{
    

  void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I am destroying");
        Destroy(collision.gameObject);
    }
}
