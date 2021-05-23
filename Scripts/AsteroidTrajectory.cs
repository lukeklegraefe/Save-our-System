﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTrajectory : MonoBehaviour
{
    public GameObject a;
    private Vector3 traj;

    void Start()
    {
        traj.x = -350;
        traj.y = -100;
    }

    void Update()
    {
        traj.y += 0.05f;
        traj.x += 0.05f;
        a.transform.position = traj;
    }
}
