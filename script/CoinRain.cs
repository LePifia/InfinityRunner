using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRain : MonoBehaviour
{
    float PlayerDistance_Spawn_Level;
    
    [SerializeField] GameObject coin;
    [SerializeField] GameObject player;
    [SerializeField] float retard;

    public bool isRainning = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coinRain());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator coinRain()
    {
        if (isRainning == true)
        {
            yield return new WaitForSeconds(retard);
            spawnCoin();
        }
    }
    private void spawnCoin()
    {
        PlayerDistance_Spawn_Level = Random.Range(10, 50);
        float x = player.transform.position.x + PlayerDistance_Spawn_Level;
        float y = 5;

        Instantiate(coin, new Vector3(x, y, 0), Quaternion.identity);

        StartCoroutine(coinRain());
    }
}
