using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPoint;

    public void SpawnObject()
    {
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
