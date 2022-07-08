using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameStatus : MonoBehaviour
{
    // config params
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 12;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool AutoPlay = false;
    
    // state vars
    [SerializeField] int currentScore = 0;
    [SerializeField] GameObject[] hearts;
    [SerializeField] int numOfHeartsLeft; // serialized for debugging purposes

    //cached references
     Ball theBall;
     Level level;
     SceneLoader sceneLoader;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1) 
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
        theBall = FindObjectOfType<Ball>();
        numOfHeartsLeft = hearts.Length;
        level = FindObjectOfType<Level>();
        sceneLoader = FindObjectOfType<SceneLoader>();

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        
    }

    public void AddToScore() 
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame() 
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled() 
    {
        return AutoPlay;
    }

    public void loseHearts() 
    {
        if (numOfHeartsLeft >= 1)
        {
            numOfHeartsLeft --;
            Destroy(hearts[numOfHeartsLeft], 0f);
            theBall.Restart();
        }
        else if (numOfHeartsLeft < 1)
        {
            SceneManager.LoadScene("Game Over");
        }
        
    }

    
    
}
