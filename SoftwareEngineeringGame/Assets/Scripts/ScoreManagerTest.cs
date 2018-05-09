using UnityEngine;
using System.Collections.Generic;
using System.Linq;

using System.Collections;


public class ScoreManagerTest : MonoBehaviour
{


    Dictionary<string, Dictionary<string, int>> playerScores;

     int changeCounter = 0;
    string createUserURL = "http://localhost/UnityGame/getResults.php";
    public string[] data;
    string username;
    string semester;
    string studentId;
    string email;
    string val;


    void Start()
    {

        StartCoroutine(GetResults("Faculty"));

    }


    IEnumerator GetResults(string user)
    {
        Debug.Log("getting results");
        WWWForm form = new WWWForm();
        form.AddField("user", user);
       

        WWW getData = new WWW(createUserURL, form);

        yield return getData;
        print("getdata val is "+getData);
        string itemsDataString = getData.text;
     
        data = itemsDataString.Split(';');
        print("data size is: " + data.Length);

        //foreach (var item in data)
            for(int i = 0; i<data.Length-1; i++)
        {
            string eachLine = data[i].ToString();
          
            SetScore(eachLine, 1);

        }
       

        

    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));

        return value;
    }


    void Init()
    {
        if (playerScores != null)
            return;

        playerScores = new Dictionary<string, Dictionary<string, int>>();
    }

    
        public void SetScore(string val, int value)
    {
        Init();
        changeCounter++;

        if (playerScores.ContainsKey(val) == false)
        {
            playerScores[val] = new Dictionary<string, int>();
        }
      
    }

    public string[] GetPlayerNames()
    {
        Init();
        return playerScores.Keys.ToArray();

    }

}
