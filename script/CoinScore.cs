using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinScore : MonoBehaviour
{
    public int coinCount;
    public GameObject coinText;

    [SerializeField] CoinRain Rain;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject DeadBackground;
    [SerializeField] GameObject InputField;

    private int coinScore;

    private void Awake()
    {
        coinText = GameObject.Find("Score");
    }

    private void Update()
    {
        if (Player.transform.position.y < -20)
        {
            Rain.isRainning = false;
            DeadBackground.SetActive(true);
            InputField.SetActive(true);
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            PlayerPrefs.SetInt("Coins", coinScore);
        }
    }

    public void point()
    {
        coinScore++;
        coinText.GetComponent<TextMeshProUGUI>().text = coinScore.ToString();
        
    }
}
