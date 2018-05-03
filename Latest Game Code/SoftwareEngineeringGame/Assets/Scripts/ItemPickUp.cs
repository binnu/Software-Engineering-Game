using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

    public int value;
    public ScoreManager theSM;

	// Use this for initialization
	void Start () {
        theSM = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            theSM.AddScore(value);
            Destroy(gameObject);
        }
    }
}
