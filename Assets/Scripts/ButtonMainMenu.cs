using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour
{
    public AudioSource click;
    public GameObject first, second;


    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(1280, 720, true);
    }

    public void newgame()
    {
        click.Play();
        SceneManager.LoadScene("Game");
    }

    public void options()
    {
        click.Play();
        first.SetActive(false);
        second.SetActive(true);
    }

    public void back()
    {
        click.Play();
        first.SetActive(true);
        second.SetActive(false);
    }

    public void timeeasy()
    {
        click.Play();
        PlayerPrefs.SetInt("timefull", 90);
    }
    public void timenormal()
    {
        click.Play();
        PlayerPrefs.SetInt("timefull", 180);
    }
    public void spawneasy()
    {
        click.Play();
        PlayerPrefs.SetInt("spawn", 3);
    }
    public void spawnnormal()
    {
        click.Play();
        PlayerPrefs.SetInt("spawn", 5);
    }

}
