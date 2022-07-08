using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // cached references
    Level level;

    // state vars
    [SerializeField] int timesHit; // only serialized for debig purposes


    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") {level.CountBreakableBlocks();}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable") 
        {
            timesHit++;
            maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits) {DestroyBlock();}
            else {ShowNextHitSprite();}

        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        //should play on camera
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        // destroy this game object after 0 seconds
        Destroy(gameObject, 0f);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    private void ShowNextHitSprite() 
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];}
        else {Debug.LogError("Block Sprite Missing From Array" + gameObject.name);}
    }
    
}
