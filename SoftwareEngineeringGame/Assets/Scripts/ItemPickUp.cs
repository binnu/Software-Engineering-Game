using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

    public int value;
    public ScoreManager theSM;
    private SFXManager sfxMan;

    // Use this for initialization
    void Start () {
        theSM = FindObjectOfType<ScoreManager>();
        sfxMan = FindObjectOfType<SFXManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            sfxMan.itemPickUp.Play();
            theSM.AddScore(value);
            Destroy(gameObject);
        }
    }
}
