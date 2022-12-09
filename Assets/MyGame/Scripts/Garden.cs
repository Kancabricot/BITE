using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garden : MonoBehaviour
{
    [SerializeField] private float lifePoint = 20;
    [SerializeField] Image lifeBar;
    [SerializeField] private float lifePointMax = 20;
    [SerializeField] private float damageTaken = 1;

    private void Start()
    {
        lifePoint = lifePointMax;
    }

    private void Update()
    {
        lifeBar.fillAmount = lifePoint / lifePointMax;
    }

    public void TakeDamage()
    {
        lifePoint -= damageTaken;
        CheckLife();
    }

    private void CheckLife()
    {
        if(lifePoint <= 0)
        {
            Debug.Log("loose");
        }
    }
}
