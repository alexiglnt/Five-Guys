using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CHEST : Interactable
{
    public bool isOpen;
    public Animator animator;
    public GameObject[] item;
    public GameObject smoke;
    
    //int random = Random.Range(0, item.Lenght);
    int randomItem;
    int ItemMax = 3;

    int ItemSize = 0;

    public GameObject chest;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        
        // Pour 
        for (int i = 0; i < item.Length; i++)
        {
            ItemSize++;
        }

        Debug.Log("Nombre d'éléments = " + ItemSize + " | Indice du dernier élément du tableau = " + (ItemSize));
        randomItem = Random.Range(0, ItemSize);
        Debug.Log(randomItem);

    }
    
    public void OpenChest()
    {   
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Chest is now open...");
            animator.SetBool("isOpen", isOpen);

            if (isOpen == true)
            {
                Destroy(Instantiate(smoke, new Vector2(transform.position.x, transform.position.y), transform.rotation), 0.5f);
                animator.Play("ChestOpened");

                //Instantiate(item, new Vector2(transform.position.x, transform.position.y - 1), transform.rotation);

                Debug.Log("Random item: " + randomItem);
                Instantiate(item[randomItem], new Vector2(transform.position.x, transform.position.y - 1), transform.rotation);
                // Destroy(smoke);
            }
        }
    }






    //void Start()
    //{
    //}


    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Press E to open chest");

    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            Debug.Log("You opened the chest");
    //        }

    //        // other.gameObject.GetComponent<PlayerController>().hasKey = true;
    //        // Destroy(gameObject);
    //    }
    //}
}
