using UnityEngine;

public class Bullet : MonoBehaviour
{
    //(OpenAI, 2024)
    public float damageAmount = 50f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Deal damage to the enemy
            PlayerHealth enemy = other.GetComponent<PlayerHealth>();
            if (enemy != null)
            {
                Debug.Log("Got shot");
                enemy.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
        }
    }
}
 /* References:
    Webname: ChatGPT
    Author: OpenAI
    Date: 30 April 2024
    Code Version: N/A
    URL: https://chat.openai.com/c/1c2b33fd-d052-427a-b06d-d01d2612b036 
    */
