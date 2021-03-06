﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMoveController : MonoBehaviour
{
    [HideInInspector]
    public RaycastHit hit;
    [HideInInspector]
    public int layerMask = (1<<9);
    public GameObject lighttracker;


    // Update is called once per frame
    void Update()
    {
        //PC Control
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Turns touch input into Vector2
            Vector2 touchPos = Input.mousePosition;
            RayCastLight(touchPos.x, touchPos.y);
        }
        //Mobile Control
        if (Input.touchCount > 0)
        {
            //Turns touch input into Vector2
            Vector2 touchPos = Input.touches[0].position;
            RayCastLight(touchPos.x, touchPos.y);
        }

    }

    void RayCastLight(float PosX, float PosY)
    {
        //cast's a ray from camera in the direction of touchPos and casts a second ray to get hit position
        Ray r = Camera.main.ScreenPointToRay(new Vector3(PosX, PosY, 0));
        Physics.Raycast(r, out hit, Mathf.Infinity, ~layerMask);
        //Draws ray in editor for debugging (Remove Before build)
        Debug.DrawRay(r.origin, r.direction * 10000, Color.yellow);
        if (hit.transform != null)
        {
            //Delay When moving light around (WIP)
            lighttracker.transform.position = Vector3.MoveTowards(lighttracker.transform.position, hit.point, 1);
            //rotate Light to look at lighttracker
            transform.LookAt(lighttracker.transform.position);
        }
    }

}
