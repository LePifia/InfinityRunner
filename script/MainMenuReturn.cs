using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuReturn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CountDownMenu()
    {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("mainMenu");
    }
}
