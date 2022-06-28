using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] string target;
    [SerializeField] GameObject Fin;
    bool oui = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameManager._currentLevelName == "Lvl2" && !oui)
        {
            GameManager.Instance.UnLoadLevel(GameManager._currentLevelName);
            Destroy(GameManager.Player);
            GameManager.Instance.LoadLevel("fin");
        }
        else if (collision.gameObject.tag == "Player" && !oui)
        {
            oui = true;
            GameManager.Instance.UnLoadLevel(GameManager._currentLevelName);
            GameManager.Instance.LoadLevel(target);
        }
    }
}
