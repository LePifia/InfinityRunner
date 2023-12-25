using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreTable : MonoBehaviour
{
    [SerializeField] GameObject entryContainer;
    [SerializeField] GameObject entryTemplate;

    public int rank;

    public int score;

    public string rankName;

    [SerializeField] float templateHeight = 10f;

    
    private List<GameObject> highScoresObjectList;

    public void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores Highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // SORTING ENTRIES BY SCORE

        for (int i = 0; i < Highscores.highScoresList.Count; i++)
        {
            for (int j = i +1; j < Highscores.highScoresList.Count; j++)
            {
                if (Highscores.highScoresList[j].score > Highscores.highScoresList[i].score)
                {
                    //swapper
                    HighScoreEntry tmp = Highscores.highScoresList[i];
                    Highscores.highScoresList[i] = Highscores.highScoresList[j];
                    Highscores.highScoresList[j] = tmp;

                }
            }
        }

        highScoresObjectList = new List<GameObject>();
        foreach (HighScoreEntry highScoreEntry in Highscores.highScoresList)
        {
            CreateHighScoreEntry(highScoreEntry, entryContainer, highScoresObjectList);

        }
    }

    void CreateHighScoreEntry(HighScoreEntry highScoreEntry, GameObject container, List<GameObject> gameObjectList)
    {
        GameObject entry = Instantiate(entryTemplate, container.transform);

        RectTransform entryRectTransform = entry.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * gameObjectList.Count);

        entry.gameObject.SetActive(true);

        //RANK

        int rank = gameObjectList.Count + 1;
        string PositionString;

        switch (rank)
        {
            default:
                PositionString = rank + "TH"; break;

            case 1:
                PositionString = "1st"; break;

            case 2:
                PositionString = "2st"; break;

            case 3:
                PositionString = "3st"; break;

            case 4:
                PositionString = "4st"; break;

            case 5:
                PositionString = "5st"; break;

            case 6:
                PositionString = "6st"; break;

            case 7:
                PositionString = "7st"; break;
        }

        entry.transform.Find("Rank").GetComponent<TextMeshProUGUI>().text = PositionString.ToString();

        //SCORE

        score = highScoreEntry.score;

        entry.transform.Find("ScoreRank").GetComponent<TextMeshProUGUI>().text = score.ToString();

        //NAME

        rankName = highScoreEntry.name;
        entry.transform.Find("WinnerRank").GetComponent<TextMeshProUGUI>().text = rankName.ToString();

        gameObjectList.Add(entry);
    }

    public void AddHighScore(int scoreMax, string rankName)
    {
        //CREATE NEW ENTRY
        HighScoreEntry highscoreEntry = new HighScoreEntry { score = scoreMax, name = rankName };

        //LOAD SAVED HIGHSCORES
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores Highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //ADD NEW ENTRY TO HIGHSCORES
        Highscores.highScoresList.Add(highscoreEntry);

        // SAVE UPDATED HIGHSCORES
        string json = JsonUtility.ToJson(Highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighScoreEntry> highScoresList;


    }

    // HIGH SCORE ENTRY

    [System.Serializable]
    private class HighScoreEntry {

        public int score;
        public string name;
    }
}
