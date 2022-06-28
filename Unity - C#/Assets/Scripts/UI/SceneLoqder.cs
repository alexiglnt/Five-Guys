using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoqder : MonoBehaviour
{
    //private PauseMenu resume;
    //private GameObject endgame;

    //void Start()
    //{
    //    endgame = GameObject.Find("PauseMenu");
    //    resume = endgame.GetComponent<PauseMenu>();
    //}

    public void QuitGame()  
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void LoadActualScene() // Respawn si mort
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void LoadBeforeScene() // Respawn si mort
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
        Time.timeScale = 1;
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Time.timeScale = 1;
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void LoadRules()
    {
        //DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("Rules");

    }

    public void LoadMainMenu()
    {
        //DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        //resume.Resume();
        SceneManager.LoadScene("Start");
        Time.timeScale = 1;
    }

    public static void LoadLevel_1()
    {
        //DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1;
    }

    public void LoadLevel_2()
    {
        //DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("Level_2");
        Time.timeScale = 1;
    }

    public void LoadLevel_3()
    {
        //DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("Level_3");
        Time.timeScale = 1;
    }

    public void LoadChooseLevel()
    {
        SceneManager.LoadScene("ChosingLevel");
        Time.timeScale = 1;
    }

    public void LoadDead()
    {
        SceneManager.LoadScene("PlayerDead");
        Time.timeScale = 1;
    }

    public void LoadControlles()
    {
        SceneManager.LoadScene("Controlles");
    }
}
