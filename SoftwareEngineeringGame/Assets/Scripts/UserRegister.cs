using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;

public class UserRegister : MonoBehaviour
{

    string createUserURL = "http://localhost/UnityGame/register.php";
    public GameObject usernameObj;
    public GameObject passwordObj;
    public GameObject confPasswordObj;
    public GameObject semesterObj;
    public GameObject studentIdObj;
    public GameObject emailObj;


    string username;
    string password;
    string confPassword;
    string semester;
    string studentId;
    string email;
    public Button yourButton;
    public Text successText;


    void Start()
    {
        successText.text = "";
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }
    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        if (username != "" && password != "" && confPassword != "" && semester != "" && studentId != "" && email != "")
        {

                Debug.Log("inside loop for creating user");
                Debug.Log("username " + username);
                StartCoroutine(CreateUser(username, password, confPassword, semester, studentId, email));
                usernameObj.GetComponent<InputField>().text = "";
                passwordObj.GetComponent<InputField>().text = "";
                confPasswordObj.GetComponent<InputField>().text = "";
                semesterObj.GetComponent<InputField>().text = "";
                studentIdObj.GetComponent<InputField>().text = "";
                emailObj.GetComponent<InputField>().text = "";
            
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Tab))
        {

            if (usernameObj.GetComponent<InputField>().isFocused)
            {
                emailObj.GetComponent<InputField>().Select();
            }
            if (emailObj.GetComponent<InputField>().isFocused)
            {
                passwordObj.GetComponent<InputField>().Select();
            }
            if (passwordObj.GetComponent<InputField>().isFocused)
            {
                confPasswordObj.GetComponent<InputField>().Select();
            }
            if (confPasswordObj.GetComponent<InputField>().isFocused)
            {
                semesterObj.GetComponent<InputField>().Select();
            }
            if (semesterObj.GetComponent<InputField>().isFocused)
            {
                studentIdObj.GetComponent<InputField>().Select();
            }


        }


        username = usernameObj.GetComponent<InputField>().text;
        password = passwordObj.GetComponent<InputField>().text;
        confPassword = confPasswordObj.GetComponent<InputField>().text;
        semester = semesterObj.GetComponent<InputField>().text;
        studentId = studentIdObj.GetComponent<InputField>().text;
        email = emailObj.GetComponent<InputField>().text;

    }

    IEnumerator CreateUser(string username, string password,string confPassword, string semester, string studentId, string email)
    {
        Debug.Log("creating user");
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        form.AddField("confPassword", confPassword);
        form.AddField("semester", semester);
        form.AddField("studentId", studentId);
        form.AddField("email", email);

        WWW msg = new WWW(createUserURL, form);


        yield return msg;

        string statusMsg = msg.text;
        Debug.Log("statusMsg is" + statusMsg);
        successText.text = statusMsg;
    }
}
