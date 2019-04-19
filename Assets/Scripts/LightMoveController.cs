using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMoveController : MonoBehaviour
{
    [HideInInspector]
    public RaycastHit hit;
    public GameObject lighttracker;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            //Turns touch input into Vector2
            Vector2 touchPos = Input.touches[0].position;
            //cast's a ray from camera in the direction of touchPos and casts a second ray to get hit position
            Ray r = Camera.main.ScreenPointToRay(new Vector3(touchPos.x, touchPos.y, 0));
            Physics.Raycast(r, out hit);
            //Draws ray in editor for debugging (Remove Before build)
            Debug.DrawRay(r.origin, r.direction * 10000, Color.yellow);
            //Delay When moving light around (WIP)
            lighttracker.transform.position = Vector3.MoveTowards(lighttracker.transform.position, hit.point, 1);
            //rotate Light to look at lighttracker
            transform.LookAt(lighttracker.transform.position);
        }
    }
}