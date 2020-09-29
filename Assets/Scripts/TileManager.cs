using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tileprefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tilelength = 4473f;
    private int amtOfTilesonScreen = 3;
    private float safezone = 4473f;

    private List<GameObject> _activeTiles;
    void Start()
    {
        _activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amtOfTilesonScreen; i++)
        {
            SpawnTile();
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Running out of spawnned tiles, spawn them after player reaches certain point
        if (playerTransform.position.z - safezone > (spawnZ - amtOfTilesonScreen * tilelength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    void SpawnTile()
    {
        GameObject go;
        go = Instantiate(tileprefabs[Random.Range(0,3)]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tilelength;
        _activeTiles.Add(go);
    }

    void DeleteTile()
    {
        Destroy(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }
}
