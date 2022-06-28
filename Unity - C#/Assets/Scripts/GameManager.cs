using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//� Garder en m�moire le nouveau du jeu courant
//� Charger et d�charger les diff�rentes niveau de jeu
//� Garder une trace de l��tat courant du jeu
//� G�n�rer d�autres syst�mes persistants

public class GameManager : Singleton<GameManager>
{

    public static bool IsInCinematic;
    
    public static string _currentLevelName = string.Empty;
    List<AsyncOperation> _loadOperations;

    private List<GameObject> _instanciedSystemPrefabs;

    public GameObject[] SystemPrefabs;
    private static GameManager instance;


    public static event Action<GameState> OnGameStateChanged;

    private GameState State;

    public static GameObject Player;

    // M�thode appel�e avant Start()   


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Yo don't do this bruh");
        }
        DontDestroyOnLoad(this.gameObject);
        // LoadLevel("Start");
        _loadOperations = new List<AsyncOperation>();
        Debug.Log(SystemPrefabs.Length.ToString());
        _instanciedSystemPrefabs = new List<GameObject>();      //List<GameObject> _instanciedSystemPrefabs;
        InstantiateSystemPrefabs();
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        Debug.Log("Dans la fonction Load");
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }

        ao.completed += OnLoadOperationComplete;
        _currentLevelName = levelName;

        _loadOperations.Add(ao);
        
    }

    public void UnLoadLevel(string levelName)
    {
        //SceneManager.UnloadSceneAsync(levelName); // ou GameObject.Destroy(GameObject.Find(sceneName))      -->    pas sur de celui ci

        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);

        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName);
            return;
        }

        ao.completed += OnUnloadOperationComplete;
        //_currentLevelName = levelName;
    }

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Load Complete");

        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(_currentLevelName));
    }

    private void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Unload Complete");
    }

    private void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        Debug.Log("InstantiateSystemPrefabs1");
        for (int i = 0; i < SystemPrefabs.Length; i++)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instanciedSystemPrefabs.Add(prefabInstance);
            Debug.Log("InstantiateSystemPrefabs2");
        }
    }

    public enum GameState
    {
        MAINMENU,
        INGAME,
        LOSE,
        PAUSE,
        VICTORY
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.MAINMENU:
                break;
            case GameState.INGAME:
                break;
            case GameState.LOSE:
                break;
            case GameState.PAUSE:
                break;
            case GameState.VICTORY:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    //get scene by name
    public static string GetSceneByName(string sceneName)
    {
        return SceneManager.GetSceneByName(sceneName).name;
    }

    //MoveGameObjectToScene
    public static void Move(GameObject gameObject, string sceneName)
    {
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(sceneName));
        Debug.Log("Normalement c'est d�plac�");
    }

   public void EndCinematic()
    {
        IsInCinematic = false;

        Debug.Log(IsInCinematic);
    }
}
