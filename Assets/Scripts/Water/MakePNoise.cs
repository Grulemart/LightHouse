using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePNoise : MonoBehaviour
{

    public float power = 3;
    public float scale = 1;
    public float timeScale = 1;

    private float xOffset;
    private float yOffset;
    private MeshFilter filter;

    void Start()
    {
        filter = GetComponent<MeshFilter>();
        MakeNoise();
    }

    // Update is called once per frame
    void Update()
    {
        MakeNoise();
        xOffset += Time.fixedDeltaTime * timeScale;
        yOffset += Time.fixedDeltaTime * timeScale;
    }

    void MakeNoise()
    {
        Vector3[] verticies = filter.mesh.vertices;

        for(int i = 0; i < verticies.Length; i++)
        {
            verticies[i].y = CalculateHeight(verticies[i].x, verticies[i].z) * power;
        }

        filter.mesh.vertices = verticies;
    }

    float CalculateHeight(float x, float y)
    {

        float xCord = x * scale + xOffset;
        float yCord = y * scale + yOffset;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}
