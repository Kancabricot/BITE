using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Garden1;
    [SerializeField] private GameObject Garden2;
    [SerializeField] private GameObject Garden3;
    [SerializeField] private GameObject Garden4;
    [SerializeField] private GameObject navArrow;

    private bool isG1 = false;
    private bool isG2 = false;
    private bool isG3 = false;
    private bool isG4 = false;
    [SerializeField] private GameObject[] enemy;
    
    

    public void SpawnGarden1()
    {
        
        Garden1.SetActive(true);
        isG1 = true;
    }
    public void SpawnGarden2()
    {
        Garden2.SetActive(true);
        isG2 = true;
    }

    public void SpawnGarden3()
    {
        Garden3.SetActive(true);
        isG3 = true;
    }
    
    public void SpawnGarden4()
    {
        Garden4.SetActive(true);
        isG3 = true;
    }

    private void Mission2()
    {

    }
    private void Mission3()
    {

    }

    public void CheckWave()
    {
        Invoke("CallCheckWave", 0.5f);
    }

    public void CallCheckWave()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
 
        if(enemy.Length == 0 && isG1 == true)
        {           
            Time.timeScale = 0;
            navArrow.SetActive(true);
            Destroy(Garden1);
            Debug.Log("next wave 1");
            FindObjectOfType<NavArrow>().LookThree();
            FindObjectOfType<Three>().Completed1();
            isG1 = false;
            FindObjectOfType<Button_Script>().Victoir1();
        }
        else if(enemy.Length == 0 && isG2 == true)
        {
            navArrow.SetActive(true);
            Destroy(Garden2);
            Debug.Log("Next waves 2");
            FindObjectOfType<NavArrow>().LookThree();
            FindObjectOfType<Three>().Completed2();
            isG2 = false;
            FindObjectOfType<Button_Script>().Victoir2();
        }
        else if(enemy.Length == 0 && isG3 == true)
        {
            navArrow.SetActive(true);
            Destroy(Garden3);
            isG3 = false;
            FindObjectOfType<NavArrow>().LookThree();
            FindObjectOfType<Three>().Completed3();
            Debug.Log("fini");
            FindObjectOfType<Button_Script>().Victoir3();
        }
        else if(enemy.Length == 0 && isG4 == true)
        {
            navArrow.SetActive(true);
            Destroy(Garden4);
            isG4 = false;
            FindObjectOfType<NavArrow>().LookThree();
            FindObjectOfType<Button_Script>().Victoir4();
        }

    }

}
