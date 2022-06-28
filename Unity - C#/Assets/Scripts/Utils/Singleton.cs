using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T> // ATTENTION DANS LE TP YA PAS LE '>'
{
    private static T instance;

    protected virtual void Awake()
    {
        if (instance != null)
            Debug.LogError("[Singleton] Trying to instantiate a second instance of a singleton class.");
        else
        {
            instance = (T)this;

            //Destroy(gameObject);
            //Debug.LogError("Yo don't do this bruh");
        }
    }

    protected virtual void OnDestroy() => instance = null;  // => est un shortcut pour écrire instance = null;  en gros ca remplace les {}

    public static T Instance
    {
        get { return instance; }
    }


    public static bool IsInitialized    // avec le type T ca ne marche pas donc jai mis bool vu qu'il renvoie un bouleen
    {
        get
        {
            if (instance != null)
                return true;
            else
                return false;
        }
    }
} // Acollade fin
