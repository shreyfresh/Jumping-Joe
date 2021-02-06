using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        FindObjectOfType<MusicPlayer>().Play("Theme");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    
    void Pause(){
        FindObjectOfType<MusicPlayer>().Pause("Theme");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Menu(){
        FindObjectOfType<MusicPlayer>().Play("Theme");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        gameIsPaused = false;
    }

    

}

