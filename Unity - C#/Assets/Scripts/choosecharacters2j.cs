using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choosecharacters2j : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> characters;

    // Boutons
    [SerializeField] private Button B_Baygo;
    [SerializeField] private Button B_PayDay;
    [SerializeField] private Button B_Ninjy;
    [SerializeField] private Button B_Snitch;
    [SerializeField] private Button B_Cosmo;

    void Start()
    {
        B_Baygo.onClick.AddListener( () => { 
            Characters_Baygo(); 
            GameManager.Instance.LoadLevel("SampleScene");
            GameManager.Instance.UnLoadLevel("ChooseCharacters");
        });
        
        B_PayDay.onClick.AddListener( () => {
            Characters_PayDay();
            GameManager.Instance.LoadLevel("SampleScene");
            GameManager.Instance.UnLoadLevel("ChooseCharacters");
        });

        B_Ninjy.onClick.AddListener( () => {
            Characters_Ninjy();
            GameManager.Instance.LoadLevel("SampleScene");
            GameManager.Instance.UnLoadLevel("ChooseCharacters");
        });

        B_Snitch.onClick.AddListener( () => {
            Characters_Snitch();
            GameManager.Instance.LoadLevel("SampleScene");
            GameManager.Instance.UnLoadLevel("ChooseCharacters");
        });


        B_Cosmo.onClick.AddListener( () => {
            Characters_Cosmo();
            GameManager.Instance.LoadLevel("SampleScene");
            GameManager.Instance.UnLoadLevel("ChooseCharacters");
        });
    }


    public void Characters_Baygo()
    {
        GameManager.Player = characters[0];
    }

    public void Characters_PayDay()
    {
        GameManager.Player = characters[1];
    }

    public void Characters_Ninjy()
    {
        GameManager.Player = characters[2];
    }
    
    public void Characters_Snitch()
    {
        GameManager.Player = characters[3];
    }

    public void Characters_Cosmo()
    {
        GameManager.Player = characters[4];
    }
}
