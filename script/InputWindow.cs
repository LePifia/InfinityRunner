using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputWindow : MonoBehaviour
{
    public string NameDisplay;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject textDisplay;
    [SerializeField] HighScoreTable highScoreTable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void ReadStringInput ()
    {
        NameDisplay = inputField.GetComponent<TextMeshProUGUI>().text;

        PlayerPrefs.SetString("Name", NameDisplay);

        string nameRank = PlayerPrefs.GetString("Name");
        int scoreMax = PlayerPrefs.GetInt("Coins");
        highScoreTable.AddHighScore(scoreMax, nameRank);
        SceneManager.LoadScene("HighScores");
    }
}
