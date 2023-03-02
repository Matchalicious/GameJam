using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenu : MonoBehaviour
{
    public GameObject menuUI; //This is the weapon menu UI
    public GameObject bodyMenuUI;
    public AudioSource popUp;
    public AudioSource click;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        Pause();
    }
    //Pauses game world and brings up weapon menu
    public void Pause(){
        popUp.Play();
        menuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    //Brings up body type menu
    public void BodyMenu(){
        click.Play();
        menuUI.SetActive(false);
        bodyMenuUI.SetActive(true);
    }
    //Starts game
    public void Resume(){
        click.Play();
        bodyMenuUI.SetActive(false);
        player.GameStart();
        Time.timeScale = 1f;
    }
}
