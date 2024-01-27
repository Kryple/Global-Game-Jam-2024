using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<Spawner> spawnObjects;
    public void RespawnAll()
    {
        foreach (Spawner sp in spawnObjects)
        {
            sp.SpawnPlayer();
        }
    }
}
