using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Move(); 
    }

    private void Move()
    {
       var deltaX = Input.GetAxis("Horizontal");
       Debug.Log("this is deltaX: " + deltaX);
       Debug.Log("this is my current position " + transform.position.x);
       float newXPos = transform.position.x + deltaX;
               Debug.Log("this is newXPos: " + newXPos);
       transform.position = new Vector2(newXPos, transform.position.y);
    }
}
