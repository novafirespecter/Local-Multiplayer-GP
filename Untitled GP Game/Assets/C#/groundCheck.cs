using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    //(Potato Code, 2022)
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
// Name: PotatoHead
// Title: How To Make a Rigidbody Play Controller with Unity's Input System
// Source: Youtube
// Date: 15 May 2022