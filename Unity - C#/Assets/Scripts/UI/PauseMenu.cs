using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region Singleton
    public static PauseMenu instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;

        canShoot = true;
        B_Retry.onClick.AddListener(Retry);
        B_Menu.onClick.AddListener(MainMenu);
        B_Resume.onClick.AddListener(Resume);
    }
    #endregion


    [SerializeField] private Button B_Retry;
    [SerializeField] private Button B_Menu;
    [SerializeField] private Button B_Resume;

    public static bool gameIsPaused = false;

    public bool canShoot;
    

    private void MainMenu()
    {
        Destroy(GameManager.Player);
        Time.timeScale = 1;
        GameManager.Instance.UnLoadLevel(GameManager._currentLevelName);
        UIManager.Instance.HidePause();
        UIManager.Instance.ActiveMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume(); 
            }

            else
            {
                Paused();
            }
                
        }
    }

    void Paused() 
    {
        UIManager.Instance.ActivePause();
        Time.timeScale = 0;
        gameIsPaused = true;
        canShoot = false;
    }

    public void Resume()
    {
        UIManager.Instance.HidePause();
        Time.timeScale = 1;
        gameIsPaused = false;
        canShoot = true;
    }

    public void Retry()
    {
        Destroy(GameManager.Player);
        Time.timeScale = 1;
        GameManager.Instance.UnLoadLevel(GameManager._currentLevelName);
        UIManager.Instance.HidePause();
        GameManager.Instance.LoadLevel("ChooseCharacters");
        canShoot = true;
    }
}
