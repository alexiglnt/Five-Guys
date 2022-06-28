using UnityEngine;
using System.Collections;
using System;

public class pylones_gestion : MonoBehaviour
{
	public SpriteRenderer[] objects;
    public float intervalle;
    float chrono;

	void Start ()
	{
        chrono=intervalle;
	}


	void FixedUpdate ()
	{
    if(objects.Length>0)
    {
        chrono-=Time.deltaTime;
        if(chrono<0)
        {
          int lequel=UnityEngine.Random.Range(0,objects.Length);
          objects[lequel].GetComponent<pylone_activation>().activate(lequel);
          chrono=intervalle;
        }
    }
  }

  public void remove(int index)
  {
    objects[index] = objects[objects.Length - 1]; //the order notmatter
    Array.Resize(ref objects, objects.Length - 1);
  }

  public bool sans_defense()
  {
    if(objects.Length>0)
    {
      return false;
    }
    else
    {
      return true;
    }
  }
}
