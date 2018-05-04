using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInsructions : MonoBehaviour {

    public void InstructionButton()
    {
        Application.LoadLevel("Instructions");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            InstructionButton();
        }
    }
}
