using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerScoreList : MonoBehaviour
{

    public GameObject playerScoreEntryPrefab;

    ScoreManagerTest scoreManager;
    List<string> username = new List<string>();
    List<string> semester = new List<string>();
    List<string> studentId = new List<string>();
    List<string> email = new List<string>();
    string val;


    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManagerTest>();

        


    }

    // Update is called once per frame
    void Update()
    {
        if (scoreManager == null)
        {
            Debug.LogError("You forgot to add the score manager component to a game object!");
            return;
        }

        

        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);  
            Destroy(c.gameObject);
        }

        string[] names = scoreManager.GetPlayerNames();

        print("length is "+names.Length);
        foreach (string name in names)
        {
           print(name);
            GameObject go = Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);

            string[] eachValue = name.Split('|');
             Debug.Log("size is: "+eachValue.Length);
            foreach (var value in eachValue)
            {
               
                val = value.ToString();

                 if (val.Contains("username"))
                {
                    string[] vals = val.Split(':');
                    go.transform.Find("Username").GetComponent<Text>().text = vals[1];

                }
                if (val.Contains("semester"))
                {
                    string[] vals = val.Split(':');
                    go.transform.Find("Semester").GetComponent<Text>().text = vals[1];

                }
                if (val.Contains("studentId"))
                {
                   string[] vals = val.Split(':');
                    go.transform.Find("StudentId").GetComponent<Text>().text = vals[1];

                }
                if (val.Contains("score"))
                {
                    string[] vals = val.Split(':');
                    go.transform.Find("Score").GetComponent<Text>().text = vals[1];

                }


            }
           
        }

      
    }
}
