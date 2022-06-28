using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_loup : MonoBehaviour
{
    public GameObject balle;
    public Transform Depart_balle;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            target = GameManager.Player;
    }

    public IEnumerator comp1()
    {
            for(int j=0;j<3;j++)
            {
            yield return new WaitForSeconds(0.1f);
            GameObject new_b=Instantiate(balle,Depart_balle.position, Quaternion.identity);
            new_b.GetComponent<balle>().shot(target);
            }
    }
}
