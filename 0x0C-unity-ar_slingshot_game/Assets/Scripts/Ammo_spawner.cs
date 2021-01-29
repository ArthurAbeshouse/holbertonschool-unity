using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_spawner : MonoBehaviour
{
    private Vector3 SpawnPos;
    public Transform SpawnPlaceHolder;
    public GameObject spawnObject;
    public float newSpawnDuration;

    #region Singleton

    public static Ammo_spawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        SpawnPos = SpawnPlaceHolder.position;
        SpawnNewObject();
    }

    void SpawnNewObject()
    {
        Instantiate(spawnObject, SpawnPos, Quaternion.identity);
    }

    public void NewSpawnRequest()
    {
        Invoke("SpawnNewObject", newSpawnDuration);

    }
}
