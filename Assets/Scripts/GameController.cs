using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject message;
    public Text messageText;

    private void Start()
    {
        message.SetActive(false);
    }

    public void ShowIntroMessage()
    {
        messageText.text = "Mutant animals are everywhere.\nWe need you to collect enough coins for a vaccine. Be careful not to get infected!\n\nWelcome to Earth, I guess…";
        message.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartLevel(int level)
    {
        switch(level)
        {
            case 1:
                message.SetActive(false);
                SceneManager.LoadScene("Level1");
                break;
            case 2:
                SceneManager.LoadScene("Level2");
                Time.timeScale = 1f;
                break;
            case 3:
                SceneManager.LoadScene("Level3");
                Time.timeScale = 1f;
                break;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
