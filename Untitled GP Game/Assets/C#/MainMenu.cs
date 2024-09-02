using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     // (OpenAI, 2024)

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("3Steps"); // Change "Level1" to the name of your first level scene
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings"); // Change "Settings" to the name of your settings scene
    }

    public void ExitGame()
    {
        Application.Quit(); // Exit the application
    }

    /* References:
    Webname: ChatGPT
    Author: OpenAI
    Date: 16 March 2024
    Code Version: N/A
    URL: https://chat.openai.com/c/1c2b33fd-d052-427a-b06d-d01d2612b036 
    */
}
