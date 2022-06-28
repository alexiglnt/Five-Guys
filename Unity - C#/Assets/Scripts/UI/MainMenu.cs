using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : BasePanel
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Option;
    [SerializeField] private GameObject Quit;
    
    [SerializeField] private Button QuitButton;
    [SerializeField] private Button B_Play;
    [SerializeField] private Button B_Option;
    [SerializeField] private Button B_Quit;

    void Awake()
    {
        // GameMananger.OnGameStateChanged += 
    }

    void Start()
    {
        B_Play.onClick.AddListener(() => { 
            GameManager.Instance.LoadLevel("ChooseCharacters");
            UIManager.Instance.HideMainMenu();        
        });
        B_Option.onClick.AddListener(ActiveOptionMenu);
        B_Quit.onClick.AddListener( ActiveModalQuit);
        QuitButton.onClick.AddListener(Quitter);
    }

    private void ActiveOptionMenu()
    {
        Menu.SetActive(false);
        Option.SetActive(true);
    }

    private void ActiveModalQuit()
    {
        Menu.SetActive(false);
        Quit.SetActive(true);
    }

    public void Quitter()
    {
        Debug.Log("Au revoir");
        Application.Quit();
    }


}
