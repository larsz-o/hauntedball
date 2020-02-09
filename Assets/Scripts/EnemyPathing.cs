using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       MoveEnemy();
    }
    private void MoveEnemy()
    {
         if (waypointIndex <= waypoints.Count - 1)
        {
            Vector3 targetPosition = waypoints[waypointIndex].transform.position;
            float movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
            {
                waypointIndex++;
            }
        } else
        {
            Destroy(gameObject); 
        }
    }
}
