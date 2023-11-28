using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public void newgame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;

    }

    public void menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }


    


}
