using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Obtacle : MonoBehaviour
{
    public float speed;
    

    GameController p_gameController;
    UIManager uiManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p_gameController = FindObjectOfType<GameController>();
        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

        Moving();
        
            
    }

    void KeepPlayingButtonIsPressed()
    {
        Destroy(gameObject);
    }



    void Moving()
    {   
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LimitScene"))
        {
            Destroy(gameObject);

            p_gameController.IncreSocre();
        }
    }
}
