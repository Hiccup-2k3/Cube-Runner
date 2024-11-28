using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject mediumTree;
    public GameObject bigTree;
    public GameObject smallTree;
    public GameObject coinObject;
    
    

    public AudioSource aus;
    public AudioClip upScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float spawnTime;
    float p_spawnTime;
    float m_spawnCoinTime;
    bool gamePlay;
    int score;
    int coinGet;
    UIManager uIManager;
    Obtacle[] obstacles;
    Coin coin;
    void Start()
    {
        score = 0;
        coinGet = 10;
        gamePlay = true;
        p_spawnTime = 0;
        uIManager = FindObjectOfType<UIManager>(); 


        obstacles = FindObjectsOfType<Obtacle>(); 
        coin = FindObjectOfType<Coin>(); 

        uIManager.ShowGameOverPanel(false);
        
        m_spawnCoinTime = 0;
        uIManager.SetScoreText($"Score : {score}");
        uIManager.SetCoinText($"Coins : {coinGet}");
    }


    // Update is called once per frame
    void Update()
    {
        if (!gamePlay)
        {
            GameOver();
            
        }

        p_spawnTime -= Time.deltaTime;
        if(p_spawnTime<=0)
        {
            SpawnObtacle();
            p_spawnTime = spawnTime;
        }

        m_spawnCoinTime -= Time.deltaTime;
        if(m_spawnCoinTime<=0)
        {
            SpawnCoin();
            m_spawnCoinTime = Random.Range(1,5);
        }
        
        
            
    }

    

    void SpawnCoin()
    {
        float x = Random.Range(-10.4f, 10.43f);
      
        
        Instantiate(coinObject, new Vector3(x,6.1f,0),Quaternion.identity);
       
    }

    void GameOver()
    {
        uIManager.ShowGameOverPanel(true);
        
        Time.timeScale = 0;

    }

    public void RePlay()
    {
        score = 0;
        gamePlay = true;
        p_spawnTime = 0;
        uIManager.SetScoreText($"Score : {score}");
        uIManager.ShowGameOverPanel(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");

    }

    public void KeepPlaying()
    {
        if (coinGet < 5)
            return;

        
        foreach (Obtacle obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        
        coinGet -= 5;
        gamePlay = true;
        p_spawnTime = 0;
        uIManager.SetScoreText($"Score : {score}");
        uIManager.SetCoinText($"Coins : {coinGet}");
        uIManager.ShowGameOverPanel(false);
        Time.timeScale = 1;
        
       
    }



    void SpawnObtacle()
    {
        int x = Random.Range(1, 4);
        switch(x)
        {
            case 1: 
                Instantiate(smallTree, new Vector3(12.267f, -2.56f, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(mediumTree, new Vector3(12.267f, -2.09f, 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(bigTree, new Vector3(12.267f, -1.607539f, 0), Quaternion.identity);
                break;
        }
    }

    void SetScore(int value)
    {
        score = value;
    }

    int GetSocre()
    {
        return score; 
    }

    void SetCoin(int value)
    {
        coinGet = value;
    }

    public int GetCoin()
    {
        return coinGet;
    }

    public void IncreCoin()
    {
        coinGet++;
        uIManager.SetCoinText($"Coins : {coinGet}");
        aus.PlayOneShot(upScore);
    }

    public void IncreSocre()
    {
        score += 1;
        uIManager.SetScoreText($"Score : {score}");
        aus.PlayOneShot(upScore);
    }

    public void SetGamePlay(bool state)
    {
        gamePlay = state;
    }



















}
