using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;

public class UserLogin : MonoBehaviour {

    string createUserURL = "http://localhost/UnityGame/index.php";
    public GameObject usernameObj;
    public GameObject passwordObj;

    public string username;
    string password;

    public Button yourButton;
    public Text successText;

    // Use this for initialization
    void Start () {
        successText.text = "";
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        if (username != "" && password != "")
        {
            StartCoroutine(CheckUser(username, password));
            //usernameObj.GetComponent<InputField>().text = "";
            //passwordObj.GetComponent<InputField>().text = "";
        }

    }

        // Update is called once per frame
        void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (usernameObj.GetComponent<InputField>().isFocused)
            {
                passwordObj.GetComponent<InputField>().Select();
            }
        }
       
        username = usernameObj.GetComponent<InputField>().text;
        password = passwordObj.GetComponent<InputField>().text;
    }

    IEnumerator CheckUser(string username, string password)
    {
        Debug.Log("checking user");
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        WWW msg = new WWW(createUserURL, form);

        yield return msg;

        string statusMsg = msg.text;

        Debug.Log("statusMsg is " + statusMsg);
        if (statusMsg.Contains("invalid credentials"))
        {
            Debug.Log("Failed to login");
            //statusMsg = "Invalid Credentials";
            successText.text = statusMsg;
        }
        else if(username.Contains("Faculty")){
            Application.LoadLevel("ResultsPage");
        }
        else
        {
            PlayerPrefs.SetString("username",username);
            Application.LoadLevel("Start Menu");
        }
    }
}
