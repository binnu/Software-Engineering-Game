using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour {

   

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Game End");
        GameObject.Find("QuitGameButton").SetActive(false);
        Application.LoadLevel("GameOver");

        yield return null;

      
    }
}
