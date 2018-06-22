using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class HighscoreBehaviourScript : MonoBehaviour {
    // Use this for initialization
    public TMP_Text scoreText;
    public TMP_Text listboard;
    public TMP_InputField inputField;
    public Button confirmButton;
    List<Record> record;
    Record newRecord;

    private static String namePlaceholder = "Your name";


    

    private void saveTofile()
    {
        string path = "Assets/record.txt";
        string temp="";
        foreach (Record r in record)
            {
            if (r.name != namePlaceholder)
            {
                temp +=r.name + "|" + r.score + ",";
                Debug.Log("item added");
            }
            }
            System.IO.File.WriteAllText(path,temp);
    }

    void Start () {

        Time.timeScale = 1f;


        int score = StaticScoreClass.ScoreInformation;
        Debug.Log("Score is "+score);
        record = new List<Record>();

        scoreText.text = "Your Score: " + score.ToString();

        string path = "Assets/record.txt";
        if (!System.IO.File.Exists(path))
        {
            Debug.Log("not found record.txt, create new file");
            string temp = "";
            System.IO.File.WriteAllText(path,temp);


        }

            string allLines = System.IO.File.ReadAllText(path);
            string[] lines = allLines.Split(',');
            foreach(string line in lines)
            {
                if (line.Length>2)
                {
                    string[] thisline = line.Split('|');
                 record.Add(new Record(thisline[0], Int32.Parse(thisline[1])));
              }
            }

        newRecord = new Record(namePlaceholder, score);
        record.Add(newRecord);

        record.Sort((x, y) => y.score.CompareTo(x.score));


        printList();



    }
	
	// Update is called once per frame
	void Update () {
        bool btn0 = Input.GetKey("joystick button 1");
        bool btn1 = Input.GetKey("joystick button 0");
        bool btn2 = Input.GetKey("joystick button 3");
        if (btn0)
        {
            Debug.Log("button 0 pressed, go to play scene");
            gotoPlayScene();
        }
        if (btn1)
        {
            Debug.Log("button 1 pressed, go to menu scene");
            gotoMenuScene();
        }
        if (btn2)
        {
            Debug.Log("button 3 pressed, quit");
            Quitgame();
        }
    }

    public void gotoPlayScene()
    {
        saveTofile();
        SceneManager.LoadScene("RunnerScene", LoadSceneMode.Single);
    }
    public void gotoMenuScene()
    {
        saveTofile();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void confirmName()
    {
        newRecord.name = inputField.text;
        inputField.gameObject.SetActive(false);
        confirmButton.gameObject.SetActive(false);
        printList();
    }

    public void Quitgame()
    {
        saveTofile();
        Application.Quit();
    }


    public void printList()
    {
        string listtext = "";
        int rank = 0;
        foreach (Record r in record)
        {
            rank++;
            listtext = listtext + rank + "," + r.name + "|" + r.score + "\r\n";

        }
        listboard.text = listtext;
    }




}




public class Record
{
    public string name;
    public int score;
    public Record(string iname,int iscore)
    {
        name = iname;
        score = iscore;
    }
    public override string ToString()
    {
        return name + "   " + score.ToString();
    }

}

