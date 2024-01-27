using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnObject;

    private void Start()
    {
        SpawnObject.transform.position = transform.position;
    }
}
