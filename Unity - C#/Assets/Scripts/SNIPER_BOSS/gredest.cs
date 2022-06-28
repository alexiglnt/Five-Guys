using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gredest : MonoBehaviour
{
    public GameObject explose;
    public float aliveTime;
    void Start()
    {
        StartCoroutine(vie());
    }

    IEnumerator vie()
    {
        yield return new WaitForSeconds(aliveTime);
        Instantiate(explose,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
