using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenu : MonoBehaviour
{
    public GameObject menuUI;

    // Start is called before the first frame update
    void Start()
    {
        Pause();
    }

    public void Pause(){
        menuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume(){
        menuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
