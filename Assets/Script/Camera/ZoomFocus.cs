using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomFocus : MonoBehaviour
{
    public Transform player1; // Assign your first player here
    public Transform player2; // Assign your second player here
    public CinemachineVirtualCamera vcam;

    public float minFOV = 15f; // The FOV when players are closest
    public float maxFOV = 90f; // The FOV when players are farthest
    public float maxDistance = 10f; // The maximum distance to consider

    void Update()
    {
        // Calculate the distance between the players
        float distance = Vector3.Distance(player1.position, player2.position);
        // Calculate the desired FOV based on the distance
        float desiredFOV = Mathf.Lerp(minFOV, maxFOV, distance / maxDistance);

        // Smoothly interpolate to the desired FOV
        vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize, desiredFOV, Time.deltaTime);
    }
}
