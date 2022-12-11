using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three : MonoBehaviour
{
    [SerializeField] GameObject uiQuest1;
    [SerializeField] GameObject uiQuest2;
    [SerializeField] GameObject uiQuest3;
    [SerializeField] GameObject uiQuest4;

    [SerializeField] GameObject player;
    [SerializeField] Transform targetPosition;

    private bool questOneIsAccepted = false;
    private bool questTwoIsAccepted = false;
    private bool questTreeIsAccepted = false;
    private bool questFourIsAccepted = false;

    [SerializeField] private bool questOneIsCompleted = false;
    [SerializeField] private bool questTwoIsCompleted = false;
    [SerializeField] private bool questTreeIsCompleted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && questOneIsAccepted == false)
        {
            uiQuest1.SetActive(true);
        }
        else if (other.CompareTag("Player") && questTwoIsAccepted == false && questOneIsCompleted == true)
        {
            uiQuest2.SetActive(true);
        }
        else if(other.CompareTag("Player") && questTreeIsAccepted == false && questTwoIsCompleted == true)
        {
            uiQuest3.SetActive(true);
        }else if(other.CompareTag("Player") && questFourIsAccepted == false && questTreeIsCompleted == true)
        {
            uiQuest4.SetActive(true);
        }
    }

    public void QuestOneAccept()
    {
        questOneIsAccepted = true;
        uiQuest1.SetActive(false);
        FindObjectOfType<PlayerController>().TakeShowel();
    }

    public void QuestTwoAccept()
    {
        questTwoIsAccepted = true;
        uiQuest2.SetActive(false);
    }
    public void QuestTreeAccept()
    {
        questTreeIsAccepted = true;
        uiQuest3.SetActive(false);
    }

    public void QuestFourAccept()
    {
        questFourIsAccepted = true;
        uiQuest4.SetActive(false);
    }

    public void Completed1()
    {
        questOneIsCompleted = true;
        player.transform.position = targetPosition.position;
    }

    public void Completed2()
    {
        questTwoIsCompleted = true;
        player.transform.position = targetPosition.position;
        Debug.Log("quest2completed true");
    }

    public void Completed3()
    {
        questTreeIsCompleted = true;
        player.transform.position = targetPosition.position;
        Debug.Log("quest2completed true");
    }
}
