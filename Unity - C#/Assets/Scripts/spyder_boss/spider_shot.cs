using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_shot : MonoBehaviour
{
    public GameObject balle;
    public Transform Depart_balle;
    public GameObject target;
    private int nbr_balles=1;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameManager.Player;
    }

    private void Update()
    {
        if (target == null)
            target = GameManager.Player;
    }

    public IEnumerator shot()
    {
        if (target == null)
            target = GameManager.Player;

        for (int j=0;j<nbr_balles;j++)
        {
        yield return new WaitForSeconds(0.1f);
        GameObject new_b=Instantiate(balle,Depart_balle.position, Quaternion.identity);
        new_b.GetComponent<balle>().shot(target);
        }
    }

    public void set_nbr_balles(int nbr)
    {
        nbr_balles=nbr;
    }
}
