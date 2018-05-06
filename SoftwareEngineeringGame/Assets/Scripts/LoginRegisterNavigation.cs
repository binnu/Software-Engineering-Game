using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginRegisterNavigation : MonoBehaviour {

    public void LoginButton()
    {

        Application.LoadLevel("Login");
    }

    public void RegisterButton()
    {

        Application.LoadLevel("Register");
    }
}
