using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    private void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position=waypoints[waypointIndex].position;

    }

    
    private void Update()
    {

        FollowThePath();
    }

    private void FollowThePath()
    {
        if(waypointIndex< waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position==targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject); //temporary -- will use objectpool desing pattern
        }
    }
}
