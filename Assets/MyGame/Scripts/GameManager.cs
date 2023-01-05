using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Garden1;
    [SerializeField] private GameObject Garden2;
    [SerializeField] private GameObject Garden3;
    [SerializeField] private GameObject Garden4;

    [SerializeField] Transform GardenTarget1;
    [SerializeField] Transform GardenTarget2;
    [SerializeField] Transform GardenTarget3;
    [SerializeField] Transform GardenTarget4;
    [SerializeField] Transform PlayerTarget;
    
    [SerializeField] Transform GardenLookAt1;
    [SerializeField] Transform GardenLookAt2;
    [SerializeField] Transform GardenLookAt3;
    [SerializeField] Transform GardenLookAt4;
    [SerializeField] Transform PlayerLookAt;

    [SerializeField] private GameObject navArrow;

    [SerializeField] private GameObject winMenu;

    [SerializeField] private CinemachineVirtualCamera vcam;

    public Text scoreText;

    private bool isG1 = false;
    private bool isG2 = false;
    private bool isG3 = false;
    private bool isG4 = false;
    [SerializeField] private GameObject[] enemy;

    private void Start()
    {
        //vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public void SpawnGarden1()
    {
        scoreText.text = "5";
        Garden1.SetActive(true);
        isG1 = true;
    }
    public void SpawnGarden2()
    {
        scoreText.text = "11";
        Garden2.SetActive(true);
        isG2 = true;
    }

    public void SpawnGarden3()
    {
        scoreText.text = "18";
        Garden3.SetActive(true);
        isG3 = true;
    }
    
    public void SpawnGarden4()
    {
        scoreText.text = "18";
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
        


        if (enemy.Length == 0 && isG1 == true)
        {
            
            Time.timeScale = 0;
            navArrow.SetActive(true);
            Destroy(Garden1);
            Debug.Log("next wave 1");
            FindObjectOfType<NavArrow>().LookThree();
            FindObjectOfType<Three>().Completed1();
            isG1 = false;
            FindObjectOfType<Button_Script>().Victoir1();
            ChangeCameraToPLayer();
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
            ChangeCameraToPLayer();
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
            ChangeCameraToPLayer();
        }
        else if(enemy.Length == 0 && isG4 == true)
        {       
            navArrow.SetActive(true);
            Destroy(Garden4);
            isG4 = false;
            FindObjectOfType<NavArrow>().LookThree();
            FindObjectOfType<Button_Script>().Victoir4();
            ChangeCameraToPLayer();
        }

    }

    public void IsFinish()
    {
        winMenu.SetActive(true);
    }

    private void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        scoreText.text = (enemy.Length).ToString();
    }

    public void ChangeCameraToGarden()
    {
        if(isG1 == true)
        {

           
            vcam.Follow = GardenTarget1;
            vcam.LookAt = GardenLookAt1;

        }
        else if(isG2 == true)
        {
            
            vcam.Follow = GardenTarget2;
            vcam.LookAt = GardenLookAt2;
        }
        else if (isG3 == true)
        {
            
            vcam.Follow = GardenTarget3;
            vcam.LookAt = GardenLookAt3;
        }
        else
        {
            vcam.Follow = GardenTarget4;
            vcam.LookAt = GardenLookAt4;
        }
        
    }
    public void ChangeCameraToPLayer()
    {
        
        vcam.Follow = PlayerTarget; 
        vcam.LookAt = PlayerTarget; 
    }

}
