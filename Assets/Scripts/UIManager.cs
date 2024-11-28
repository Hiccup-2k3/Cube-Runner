using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text coinText;
    public GameObject gameOverPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    public void SetScoreText(string txt)
    {
        if(scoreText ) 
            scoreText.text = txt;
    }

    public void SetCoinText(string txt)
    {
        if (coinText)
            coinText.text = txt;
    }

    public void ShowGameOverPanel(bool isShow)
    {
        if(gameOverPanel)
        {
            gameOverPanel.SetActive(isShow);
            
        }
            
    }




}
