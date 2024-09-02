using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 
public class LevelTeleportation : MonoBehaviour
{
    // public GameObject Player;
    // public GameObject TeleportTo;
    // public GameObject StartTeleporter;
 
    // private void OnTriggerEnter(Collider collision)
    // {
    //     if (collision.gameObject.CompareTag("Teleporter"))
    //     {
    //         Player.transform.position = TeleportTo.transform.position;
    //     }
 
    //     if (collision.gameObject.CompareTag("SecondTeleporter"))
    //     {
    //         Player.transform.position = StartTeleporter.transform.position;
    //     }
    // }

public Transform player, destination;
 public GameObject playerg;
 
 void OnTriggerEnter(Collider other){
  if(other.CompareTag("Player")){
//    playerg.SetActive(false);
   other.GetComponent<Transform>().position = destination.position;
//    playerg.SetActive(true);

   Debug.Log("Spawn");
  }
 }
}
