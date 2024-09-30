using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trash;
    public float spawnInterval = 0.05f; // Intervalo en segundos para spawnear

    void Start()
    {
        // Llamamos a SpawnObject repetidamente cada 'spawnInterval' segundos
        InvokeRepeating("SpawnTrash", 0f, spawnInterval);
    }

    void SpawnTrash()
    {
        int randomIndex = Random.Range(0, trash.Length);
        Vector3 spawnPosition = this.transform.position; // Posición del spawner
        //Debug.Log("Spawned");

        Instantiate(trash[randomIndex], spawnPosition, Quaternion.identity);
    }
}