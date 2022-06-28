using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseCharacters : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> characters;
    bool oui;

    // Boutons
    [SerializeField] private Button B_Baygo;
    [SerializeField] private Button B_PayDay;
    [SerializeField] private Button B_Ninjy;
    [SerializeField] private Button B_Snitch;
    [SerializeField] private Button B_Cosmo;

    void Start()
    {
        oui = false;
        B_Baygo.onClick.AddListener(Characters_Baygo);
        
        B_PayDay.onClick.AddListener(Characters_PayDay);

        B_Ninjy.onClick.AddListener(Characters_Ninjy);

        B_Snitch.onClick.AddListener(Characters_Snitch);

        B_Cosmo.onClick.AddListener(Characters_Cosmo);
    }


    public void Characters_Baygo()
    {
        if (!oui)
        {
            oui = true;
            GameManager.Player = characters[0];
            GameManager.Instance.LoadLevel("SampleScene");
            GameManager.Instance.UnLoadLevel("ChooseCharacters");
        }
    }

    public void Characters_PayDay()
    {
        if (!oui)
        {
            oui = true;
            GameManager.Player = characters[1];
            GameManager.Instance.LoadLevel("SampleScene");
            GameManager.Instance.UnLoadLevel("ChooseCharacters");
        }
    }

    public void Characters_Ninjy()
    {
        if (!oui)
        {
            oui = true;
            GameManager.Player = characters[2];
            GameManager.Instance.LoadLevel("SampleScene");
            GameManager.Instance.UnLoadLevel("ChooseCharacters");
        }
    }
    
    public void Characters_Snitch()
    {
        if (!oui)
        {
            oui = true;
            GameManager.Player = characters[3];
            GameManager.Instance.LoadLevel("SampleScene");
            GameManager.Instance.UnLoadLevel("ChooseCharacters");
        }
    }

    public void Characters_Cosmo()
    {
        if (!oui)
        {
            oui = true;
            GameManager.Player = characters[4];
            GameManager.Instance.LoadLevel("SampleScene");
            GameManager.Instance.UnLoadLevel("ChooseCharacters");
        }
    }
}
