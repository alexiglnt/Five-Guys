using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private static UIManager instance;
    
    [SerializeField] private GameObject MainMenu;
    //[SerializeField] private GameObject ChooseCharacters;
    [SerializeField] private GameObject Death;
    [SerializeField] private GameObject Victory;
    [SerializeField] private GameObject Pause;


    public void HideMainMenu()
    {
        MainMenu.SetActive(false);
    }

    public void ActiveMenu()
    {
        MainMenu.SetActive(true);
    }

    public void ActiveDeath()
    {
        Death.SetActive(true);
    }

    public void HideDeath()
    {
        Death.SetActive(false);
    }

    public void ActiveVictory()
    {
        Victory.SetActive(true);
    }
    
    public void HideVictory()
    {
        Victory.SetActive(false);
    }
    
    public void HidePause()
    {
        Pause.SetActive(false);
    }
    
    public void ActivePause()
    {
        Pause.SetActive(true);
    }
}
