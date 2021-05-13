using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTrajectory : MonoBehaviour
{
    public GameObject a;
    Vector3 traj;
    void Start()
    {
        
    }

    void Update()
    {
        traj.y += 0.1f;
        traj.x += 0.1f;
        a.transform.position = traj;
    }
}
