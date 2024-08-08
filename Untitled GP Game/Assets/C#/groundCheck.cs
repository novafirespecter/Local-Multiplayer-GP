using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public PlayerMove playerMove;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject == playerMove.gameObject)
        return;

        playerMove.SetGrounded(true);
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject == playerMove.gameObject)
        return;

        playerMove.SetGrounded(false);
    }

        private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject == playerMove.gameObject)
        return;

        playerMove.SetGrounded(true);
    }
}
