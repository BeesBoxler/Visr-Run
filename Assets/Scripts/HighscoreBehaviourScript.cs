using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HighscoreBehaviourScript : MonoBehaviour {
    // Use this for initialization
    public Text scoreText;
    public Text listboard;
    List<Record> record;
    void Start () {



        int score = StaticScoreClass.ScoreInformation;
        Debug.Log("your score is "+score);
        record = new List<Record>();

        scoreText = GetComponent("scoreText") as Text;
        scoreText.text = score.ToString();
        listboard = GetComponent("listText") as Text;



        string path = "Assets/record.txt";
        if (!System.IO.File.Exists(path))
        {
            Debug.Log("not found record.txt, create new file");
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine("test1|100000,");
            sw.WriteLine("test2|200000,");
            sw.WriteLine("test3|300000,");
            sw.WriteLine("test4|400000,");
            sw.WriteLine("test5|500000,");
            sw.WriteLine("test6|600000,");
            sw.Close();

        }

            StreamReader sr = new StreamReader(path);
            string allline =sr.ReadToEnd();
            string[] lines = allline.Split(',');
            foreach(string line in lines)
            {
            if (line.Length>2)
            {
                string[] thisline = line.Split('|');
                record.Add(new Record(thisline[0], Int32.Parse(thisline[1])));
            }
            }
            sr.Close();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void print()
    {
        foreach(Record r in record)
        {
            Debug.Log(r.ToString());
        }
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