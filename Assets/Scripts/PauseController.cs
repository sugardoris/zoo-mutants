using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameObject.Find("Music").GetComponent<AudioSource>().Stop();
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        GameObject.Find("Music").GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
