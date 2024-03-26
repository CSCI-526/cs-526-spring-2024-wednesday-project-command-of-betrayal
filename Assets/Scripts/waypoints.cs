using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class waypoints : MonoBehaviour
{
    public Transform[] waypointTargets; 
    public float speed = 2f;        
    private int waypointIndex = 0;  

    void Start()
    {
       
        transform.position = waypointTargets[waypointIndex].position;
    }

    void Update()
    {
      
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        float distance = Vector3.Distance(transform.position, waypointTargets[waypointIndex].position);

        if (distance > 0.1f)
        {
            
            float step = speed * Time.deltaTime;

          
            transform.position = Vector3.MoveTowards(transform.position, waypointTargets[waypointIndex].position, step);
        }
        else
        {
            
            transform.Rotate(0, 180, 0, Space.Self);

           
            waypointIndex++;

           
            if (waypointIndex >= waypointTargets.Length)
            {
                waypointIndex = 0;
            }
        }
    }
}
