using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore;

    public static UIManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

  

    public void GameStart()
    {
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("RemoveTapGame");
    }
    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();

        gameOverPanel.SetActive(true);
        
        gameOverPanel.GetComponent<Animator>().Play("GameOverAnim");
        //gameOverPanel.GetComponent<Animator>().Play("Diamond");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
