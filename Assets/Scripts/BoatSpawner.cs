using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    //Inspector Variables
    [Header("Spawner Area")]
    public Vector3 spawnRange = new Vector3();
    [Header("Boat Prefab")]
    public GameObject Boat;

    //Basic Variables 
    [HideInInspector]
    public Vector3 posA;
    [HideInInspector]
    public Vector3 posB;
    [HideInInspector]
    public GameObject boatInst;

    void Awake()
    {
        //sets range for boats to spawn inside of
        posA = new Vector3((transform.position.x + (spawnRange.x / 2)), (transform.position.y + (spawnRange.y / 2)), (transform.position.z + (spawnRange.z / 2)));
        posB = new Vector3((transform.position.x - (spawnRange.x / 2)), (transform.position.y - (spawnRange.y / 2)), (transform.position.z - (spawnRange.z / 2)));
    }

    private void Start()
    {
        //spawns boat on start of game (For testing remove later)
        SpawnBoat(posA, posB);
    }

    void Update()
    {
        //Deletes boat and Spawns a new one (For Temporary Debugging)
        if (Input.GetKeyDown(KeyCode.Space)){
            //error catching
            if(boatInst != null)
            {
                Destroy(boatInst);
            }
            SpawnBoat(posA, posB);
        }

    }

    //Boat Spawn function
    void SpawnBoat(Vector3 posMin, Vector3 posMax)
    {
        //creates instance of the Boat prefab and spawns it randomly inside the box
        boatInst = Instantiate(Boat, new Vector3(Random.Range(posMin.x, posMax.x), -1, Random.Range(posMin.z, posMax.z)), transform.rotation);
        //rotates boat to face the correct direction
        boatInst.transform.Rotate(-90,0,180);
    }

    //draws bounding box gizmo
    void OnDrawGizmosSelected()
    {
    #if UNITY_EDITOR
        Gizmos.color = new Color(1, 0, 0, 1F);
        Gizmos.DrawWireCube(transform.position, spawnRange);
        Gizmos.color = new Color(0, 1, 0, 1F);
        Gizmos.DrawSphere(new Vector3((transform.position.x + (spawnRange.x / 2)), (transform.position.y + (spawnRange.y / 2)), (transform.position.z + (spawnRange.z / 2))), 0.10f);
        Gizmos.DrawSphere(new Vector3((transform.position.x - (spawnRange.x / 2)), (transform.position.y - (spawnRange.y / 2)), (transform.position.z - (spawnRange.z / 2))), 0.10f);
#endif
    }
}
