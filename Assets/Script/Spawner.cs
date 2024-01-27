using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnObject;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        SpawnObject.transform.position = transform.position;
    }
}
