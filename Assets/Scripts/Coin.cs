using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Coin : MonoBehaviour
{
    public float rotationSpeed ;
    float rotate = 0;
    GameController gameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }
    void Spin()
    {
        rotate +=  rotationSpeed * Time.deltaTime;
        transform.Rotate (0, rotate , 0);
    }
    void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", gameController.GetCoin());
    }   

    public int GetOldCoin()
    {
        return PlayerPrefs.GetInt("Coins");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            Destroy(gameObject);
        if(collision.CompareTag("Player"))
        {
            gameController.IncreCoin();
            Destroy(gameObject);
        }
    }
}
