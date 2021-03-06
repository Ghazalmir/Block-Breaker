using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField] int numOfScenes; //serialized for debigging purposes
	

    private void Start()
    {
        numOfScenes = 0;
    }

    

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    
    public void LoadLevelUpScene() 
    {
        SceneManager.LoadScene("Level Up");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
