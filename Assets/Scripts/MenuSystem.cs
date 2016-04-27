using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour
{
    public Transform pauseMenu;
    public Transform settingsMenu;
    public Transform forfeitMenu;
    // Update is called once per frame
    public void Pause()
    {
        if (pauseMenu.gameObject.activeInHierarchy == false)
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Resume();
        }
    }
    public void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Settings()
    {
        pauseMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(true);
    }
    public void Forfeit()
    {
        if (forfeitMenu.gameObject.activeSelf == true)
            forfeitMenu.gameObject.SetActive(false);
        else if (forfeitMenu.gameObject.activeSelf == false)
            forfeitMenu.gameObject.SetActive(true);
    }
    public void Back()
    {
        pauseMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
    }
}