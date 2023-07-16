using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject Solo;
    public GameObject Multi;

    public void PlayButton(){
        Solo.SetActive(true);
        Multi.SetActive(true);
    }

    public void ButtonInactivity(){
        if(Solo.activeSelf){
            Solo.SetActive(false);
            Multi.SetActive(false);
        }
    }

    public void SoloButton(){
        SceneManager.LoadScene("Solo");
    }

    public void MultiButton(){
        SceneManager.LoadScene("Multi");
    }

    public void EditButton(){
        SceneManager.LoadScene("Edit");
    }

    public void SettingButton(){
        SceneManager.LoadScene("Option");
    }
    
    public void ExitButton(){
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
