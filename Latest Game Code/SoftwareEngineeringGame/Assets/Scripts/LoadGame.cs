using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour {

    public void PlayButton()
    {
        
        Application.LoadLevel("FirstScreen");
    }

        // Update is called once per frame
        void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
           
         PlayButton();
        }
     }
}
