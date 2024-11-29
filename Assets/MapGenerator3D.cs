using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MapGenerator3D : MonoBehaviour
{
    public Vector2 genCount;
    [SerializeField] private GameObject _tile;
    [SerializeField] private float maxHeight;
    [SerializeField] private float noiseScale;
    [SerializeField] private Terrain terrain;
    float[,] mesh = new float[500, 500];
    //List<Vector3> vertex = new List<Vector3>();

    private void Start()
    {
        GenerateTerrain();
        
        //terrain.terrainData.SetHeights(0,0,GenerateTerrain());
        
        
        
        
    }

    private void Generate()
    {
        for (int x = 0; x < genCount.x; x++)
        {
            for (int z = 0; z < genCount.y; z++)
            {
                float coordX = x * noiseScale;
                float coordZ = z * noiseScale;
                float noise = Mathf.PerlinNoise(coordX, coordZ);

                int heigth = Mathf.RoundToInt(noise * maxHeight);
                Vector3 pos = new Vector3(x, heigth, z);

                GameObject tile = Instantiate(_tile,pos,Quaternion.identity);
            }
        }
    }
    private void GenerateTerrain()
    {
        int res = terrain.terrainData.heightmapResolution;
        float[,] mesh = new float[res,res];

        for (int x = 0; x < res; x++)
        {
            for (int z = 0; z < res; z++)
            {
                mesh[x,z] = Mathf.PerlinNoise(x * noiseScale, z * noiseScale) * maxHeight;
            }
        }
        terrain.terrainData.SetHeights(0,0,mesh);
    }

    

}
