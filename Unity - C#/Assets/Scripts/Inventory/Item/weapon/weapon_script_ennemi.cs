using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon_script_ennemi : MonoBehaviour
{
    public GameObject bullet;
    private GameObject reloading;

    public Arme arme;

    private bool canShoot=true;
    private bool IsReloading;

    public int mun;
    public int magazine;

    public SpriteRenderer mySpriteRenderer;

    public Text Mun_Magazine;

    public GameObject target;

    void Awake()
    {
        mun = arme.Max_mun;
        magazine = arme.magazine_size;
        target = GameManager.Player;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            target = GameManager.Player;

        if (transform.parent.gameObject.transform.Find("detect_area").GetComponent<detect_player>().detect_joueur()==true)
        {
        Vector3 difference =  target.transform.position-transform.position;
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
        if(magazine>0)
        {
            if(canShoot==true)
            {
                StartCoroutine(Shoot());
            }
        }
        else{
            StartCoroutine(Reload());
        }
        }
    }

    IEnumerator Reload()
    {
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
           magazine = arme.magazine_size;
        }
        canShoot = true;
        IsReloading = false;
    }

    IEnumerator Shoot()
    {
        canShoot=false;
        while(magazine>0)
        {
            Destroy(Instantiate(bullet, transform.GetChild(0).transform.position, transform.rotation), arme.bullet_life_time);
            magazine -= 1;
            yield return new WaitForSeconds(arme.fire_rate);
        }
        canShoot=true;
    }
}
