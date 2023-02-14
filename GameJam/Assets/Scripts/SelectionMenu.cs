using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenu : MonoBehaviour
{
    public GameObject menuUI;
    public AudioSource popUp;
    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        Pause();
    }

    public void Pause(){
        popUp.Play();
        menuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume(){
        click.Play();
        menuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
