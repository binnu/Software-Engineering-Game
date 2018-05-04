using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public  int playerMaxHealth = 50;
    public  int playerCurrentHealth = 0;
    [SerializeField]
    private GameObject gameOverUI;
    private SFXManager sfxMan;



    // Use this for initialization
    void Start () {
        playerCurrentHealth = playerMaxHealth;
        sfxMan = FindObjectOfType<SFXManager>();
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
        GameObject.Find("QuitGameButton").SetActive(false);
        Debug.Log("Game Over");
        Application.LoadLevel("GameOver");
       
    }

    public void HurtPlayer(int damageToGive)
    {
        sfxMan.playerHurt.Play();
        playerCurrentHealth -= damageToGive;
     }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
  