﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogueLines;
    public int currentLine;
    private PlayerMovement thePlayer;
    static int count;


    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerMovement>();
 
    }
	
	// Update is called once per frame
	void Update () {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space)) 
        {
            //dBox.SetActive(false);
            //dialogActive = false;
            currentLine++;
        }

        if(currentLine >= dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;
            thePlayer.canMove = true;
            count++;
            Debug.Log("count " + count);
        }
        /*if(count == 10)
        {
            count = 0;
            GameObject.Find("QuitGameButton").SetActive(false);
            Debug.Log("Game Finished");
            Application.LoadLevel("GameOver");
        }*/

        dText.text = dialogueLines[currentLine];
    }
    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
        //Debug.Log("Show Dialogue");
    }
}
