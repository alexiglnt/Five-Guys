using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    #region Singleton
    public static PlayerDeath instance;
    
    [SerializeField] private GameObject Menu;
    public GameObject DeathMenuUI;

    [SerializeField] private Button B_Retry;
    [SerializeField] private Button B_Menu;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public static bool gameIsPaused = false;

    public bool canShoot;

    void Start()
    {
        canShoot = true;
        B_Retry.onClick.AddListener(Retry);
        B_Menu.onClick.AddListener(MainMenu);
    }

    private void MainMenu()
    {
        Time.timeScale = 1;
        GameManager.Instance.UnLoadLevel(GameManager._currentLevelName);
        UIManager.Instance.HideDeath();
        UIManager.Instance.ActiveMenu();
    }

    private void Retry()
    {
        Time.timeScale = 1;
        GameManager.Instance.UnLoadLevel(GameManager._currentLevelName);
        UIManager.Instance.HideDeath();
        GameManager.Instance.LoadLevel("ChooseCharacters");
    }
}
