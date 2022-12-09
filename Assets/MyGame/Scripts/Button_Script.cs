using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour
{
    [SerializeField] GameObject Option;


    public void QuestOneAccept()
    {
        FindObjectOfType<GameManager>().SpawnGarden1();
        FindObjectOfType<Three>().QuestOneAccept();
        FindObjectOfType<NavArrow>().QuestOneAccept();
    }

    public void QuestTwoAccept()
    {
        FindObjectOfType<GameManager>().SpawnGarden2();
        FindObjectOfType<Three>().QuestTwoAccept();
        FindObjectOfType<NavArrow>().QuestTwoAccept();
    }

    public void QuestTreeAccept()
    {
        FindObjectOfType<GameManager>().SpawnGarden3();
        FindObjectOfType<Three>().QuestTreeAccept();
        FindObjectOfType<NavArrow>().QuestTreeAccept();
    }

    public void Pause ()
    {
        Option.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Play() 
    {
        Option.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
