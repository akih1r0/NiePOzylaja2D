using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public static GameController instance { private set; get; }
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;
    //public Text pozylojScore;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void BirdScore()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        //pozylojScore.text = "Score: " + score;

    }
}
