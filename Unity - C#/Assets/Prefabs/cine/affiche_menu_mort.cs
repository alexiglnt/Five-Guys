using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class affiche_menu_mort : MonoBehaviour
{
    public void afficher_menu()
    {
        UIManager.Instance.ActiveDeath();
    }
}
