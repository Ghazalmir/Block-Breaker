using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    // cached references 
    GameStatus gameStat;

    void Start()
    {
        gameStat = FindObjectOfType<GameStatus>();

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        gameStat.loseHearts();
    
        
    }

    
}
