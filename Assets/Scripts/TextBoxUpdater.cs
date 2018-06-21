using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxUpdater : MonoBehaviour {
    private TMP_Text text;
    private int distance;

    private void Start()
    {
        distance = 0;
        text = gameObject.GetComponent<TMP_Text>();
    }

    void FixedUpdate ()
    {
        distance = distance + 1;

        text.text = "Score " + (distance / 10).ToString();
    }

    private void OnDestroy()
    {
        StaticScoreClass.ScoreInformation = distance / 10;
    }
}