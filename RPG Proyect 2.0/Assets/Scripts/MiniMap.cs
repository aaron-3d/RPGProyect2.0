using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform playerLocation;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = playerLocation.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //transform.rotation = Quaternion.Euler(90f, playerLocation.eulerAngles.y,0f); // Hace que el minimapa rote con el jugador
    }
}
