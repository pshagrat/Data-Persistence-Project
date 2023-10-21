using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField] Text TopScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if(DataManager.Instance != null)
        {
            InitializeText();
        }
    }

    private void InitializeText()
    {
        string textToShow = "Best Score: " + DataManager.Instance.NameBestScore + " " + DataManager.Instance.BestScore;
        TopScoreText.text = textToShow;
    }
}
