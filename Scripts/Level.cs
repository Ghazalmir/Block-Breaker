using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    //params
    [SerializeField] int breakableBlocks;

    //cached references
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks ++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks --;
        if (breakableBlocks <= 0)
        {
            SceneManager.LoadScene("Level Up");
        }
    }

    public int getBreakableBlocks() 
    {
        return breakableBlocks;
    }
    
    

}
