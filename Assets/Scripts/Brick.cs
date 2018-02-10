using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class Brick : MonoBehaviour {
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;//cuantos ladrillos se pueden romper
    public GameObject smoke;
    // Use this for initialization

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
	void Start () {
        isBreakable = (this.tag == "breakable");

        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f); //tercer parametro es el volumen 
        
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount --;
            puffSmoke();
            Destroy(gameObject);
            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }
    void puffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
        // smokePuff.GetComponent<ParticleSystem>().main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
        ParticleSystem.MainModule settings = smokePuff.GetComponent<ParticleSystem>().main;
        settings.startColor = gameObject.GetComponent<SpriteRenderer>().color; 
    }
    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick Sprite Missing");
        }

        } 
}
