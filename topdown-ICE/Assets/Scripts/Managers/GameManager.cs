using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject playerPrefab;
    public GameObject activePlayer;
    public bool isPlaying = false;
    public ScriptableInteger life;
    public ScriptableInteger coin;
    public EnemySpawner spawner;

    public List<GameObject> items;

    public UnityAction OnGameOverAction;

    

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }    
    }

    
    // Start is called before the first frame update
    void Start()
    {
       items = new List<GameObject>(); 
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void spawnPlayer()
    {
        activePlayer = Instantiate(playerPrefab);
    }

    public Vector3 getPlayerPosition()
    {
        if (activePlayer != null)
        {
        return activePlayer.transform.position;
        }
        return Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        isPlaying = true;
        spawnPlayer();
    }

    internal void retry()
    {
        life.reset();
        coin.reset();
        spawner.clearEnemies();
        ObjectPool.GetInstance().deactivateAllObject();
        clearAllItem();
    }

    public void pauseGame()
    {
        isPlaying = false;
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        isPlaying = true;
        Time.timeScale = 1;
    }

    internal void gameOver()
    {
        isPlaying = false;
        OnGameOverAction?.Invoke();
    }

    internal void addItem(GameObject gameObject)
    {
        items.Add(gameObject);
    }

    public void clearAllItem()
    {
        foreach(GameObject go in items)
        {
            Destroy(go);
        }
        items.Clear();
    }
}
