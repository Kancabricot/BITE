using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Garden1;
    [SerializeField] private GameObject Garden2;
    [SerializeField] private GameObject Garden3;
    private bool isG1 = false;
    private bool isG2 = false;
    private bool isG3 = false;
    private GameObject[] enemy;
    

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
            FindObjectOfType<NavArrow>().LookThree();
            Destroy(Garden1);
            Debug.Log("next wave 1");
            FindObjectOfType<Three>().Completed1();
            isG1 = false;
        }
        else if(enemy.Length == 0 && isG2 == true)
        {
            FindObjectOfType<NavArrow>().LookThree();
            Destroy(Garden2);
            Debug.Log("Next waves 2");
            FindObjectOfType<Three>().Completed2();
            isG2 = false;
        }
        else if(enemy.Length == 0 && isG3 == true)
        {
            FindObjectOfType<NavArrow>().LookThree();
            Destroy(Garden3);
            isG3 = false;
            Debug.Log("fini");
        }

    }

}
