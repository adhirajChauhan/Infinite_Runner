using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private bool spawningObject = false;

    public static ObjectSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnGround()
    {
        ObjectPooler.instance.SpawnFromPool("ground", new Vector3(0, 0, 4400f), Quaternion.identity);
    }
}
