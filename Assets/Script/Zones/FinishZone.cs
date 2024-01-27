using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private Dictionary<string, GameObject> enteredPlayers;

    [SerializeField]
    private int requiredPlayers;

    private void Start()
    {
        enteredPlayers= new Dictionary<string, GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ENETERED: " + enteredPlayers.Count);
        try
        {
            enteredPlayers.Add(collision.gameObject.name, collision.gameObject);
        }
        catch (System.Exception e)
        {
        }
        
        if (enteredPlayers.Count == requiredPlayers)
        {
            Time.timeScale = 0;
            Debug.Log("YOU WIN!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("ENETERED: " + enteredPlayers.Count);
        try
        {
            enteredPlayers.Remove(collision.gameObject.name);
        }
        catch (System.Exception e)
        {

        }
            
    }
}
