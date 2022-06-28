using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{

    #region Singleton
    
    public static PlayerStats instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
        
        maxHealth = 100;
        health = maxHealth;
        attack = 10;
        defense = 10;
        speed = 1;
        luck = 0;
        DontDestroyOnLoad(instance.gameObject);
    }
    #endregion
    public float health;
    public float maxHealth;
    public int attack;
    public int defense;
    public int speed;
    public int luck;

    public Image life_bar;

    public Animator m_Animator;

    public GameObject hand;

    private bool oui = false;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        attack = 10;
        defense = 10;
        speed = 1;
        luck = 0;
        DontDestroyOnLoad(this.gameObject);
    }  

    public void TakeDamage(int damage)
    {
        health -= damage;
        life_bar.fillAmount = health * (1 / maxHealth);
        if (health <= 0 && !oui)
        {
            oui = true;
            gameObject.GetComponent<TopDownPlayerController>().body.velocity = new Vector2(0,0);

            Debug.Log("Game Over");
            m_Animator.SetBool("Death", true);
            
            GameManager.Instance.UnLoadLevel(GameManager._currentLevelName);
            Destroy(this.gameObject);
            GameManager.Instance.LoadLevel("Mort");
        }
    }
    
    public void Destroy_Player()
    {
        Destroy(gameObject);
    }
}
