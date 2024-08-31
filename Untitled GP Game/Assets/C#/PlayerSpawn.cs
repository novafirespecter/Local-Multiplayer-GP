using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerSpawn : MonoBehaviour
{
    [Header("Menu Spawn Points")]
    [SerializeField] Transform[] menuSpawnPoints;
    //[SerializeField] InputAction joinAction;
    private int numPlayers;
    //function called once on scene start
    private void Start()
    {
        //joinAction.Enable();    //allow players to join on start
        numPlayers = 0;         //will always assume that no one has joined on start
    }
    //automatically called when player joins the game session
   void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Spawn Position: " + menuSpawnPoints[numPlayers].position);
        playerInput.GetComponent<Rigidbody>().position = menuSpawnPoints[numPlayers].position;
        //no longer allow people to join the game when hitting the limit
        if (numPlayers > 3)
        {
            GetComponent<PlayerInputManager>().DisableJoining();
        }
        numPlayers++;   //add one to varible to keep track of number of players
        Debug.Log("Joined");
    }
}