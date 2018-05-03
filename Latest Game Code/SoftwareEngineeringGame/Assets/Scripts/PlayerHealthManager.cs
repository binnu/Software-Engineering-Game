using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public  int playerMaxHealth = 50;
    public  int playerCurrentHealth = 0;
    [SerializeField]
    private GameObject gameOverUI;


	// Use this for initialization
	void Start () {
        playerCurrentHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            EndGame();
        }
	}



    public void EndGame()
    {
        Debug.Log("Game Over");
        Application.LoadLevel("GameOver");
        //gameOverUI.SetActive(true);
    }

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
     }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
  