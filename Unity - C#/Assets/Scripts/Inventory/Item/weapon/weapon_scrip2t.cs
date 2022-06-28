using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon_script_multi_bullets : MonoBehaviour
{
    public GameObject[] bullets;
    private GameObject reloading;

    public Arme arme;

    private bool canShoot;
    private bool IsReloading;

    public int mun;
    public int magazine;

    private bool inv_open;

    public SpriteRenderer mySpriteRenderer;

    public Text Mun_Magazine;

    void Awake()
    {
        mun = arme.Max_mun;
        magazine = arme.magazine_size;
        canShoot = true;
        inv_open = false;
        IsReloading = false;
        reloading = GameObject.Find("Circle");
        reloading.GetComponent<Renderer>().enabled = false;
        Mun_Magazine = GameObject.Find("Magazine/Munition").GetComponent<Text>();
        gameObject.GetComponent<weapon_script_multi_bullets>().enabled = false;

    }
        // Update is called once per frame
    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + 0);

        if (gameObject.transform.localEulerAngles.z > 90 && gameObject.transform.localEulerAngles.z < 270)
        {
            transform.Rotate(180f, 0f, 0f);
        }
        else
        {
            transform.Rotate(0f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.Mouse0) && canShoot==true)
        {
            if (magazine > 0)
            {
                StartCoroutine(Shoot());
            }
            else
            {
                StartCoroutine(Reload());
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && magazine < arme.magazine_size)
        {
            StartCoroutine(Reload());
        }

        if (IsReloading == false)
        {
            if (Inventory.instance.canShoot == false || PauseMenu.instance.canShoot == false)
                canShoot = false;
            else
                canShoot = true;
        }


        Mun_Magazine.text = magazine+ "/" + mun;
    }

    IEnumerator Reload()
    {
        reloading.GetComponent<Renderer>().enabled = true;
        canShoot = false;
        IsReloading = true;
        yield return new WaitForSeconds(arme.reload_time);
        if (mun >= arme.magazine_size )
        {
            mun -= (arme.magazine_size-magazine);
            magazine = arme.magazine_size;
        }
        else if (mun < arme.magazine_size && mun > 0)
        {
            int mun_save = mun;
            mun -= (arme.magazine_size - magazine);
            if (mun < 0)
                mun = 0;

            if (mun+magazine > arme.magazine_size)
            {
                magazine = arme.magazine_size;
            }
            else
            {
                magazine = mun_save + magazine;
            }
            
        }
        else
        {
            Debug.Log("No more bullets");
        }
        canShoot = true;
        IsReloading = false;
        reloading.GetComponent<Renderer>().enabled = false;
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        IsReloading = true;
        Destroy(Instantiate(bullets[0], transform.GetChild(0).transform.position, transform.rotation), arme.bullet_life_time);
        magazine -= 1;
        yield return new WaitForSeconds(arme.fire_rate);
        IsReloading = false;
        canShoot = true;
    }
}
