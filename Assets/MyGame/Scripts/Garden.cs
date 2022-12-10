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
    private float attackSpeed = 1;
    private bool canAttack;

    private void Start()
    {
        lifePoint = lifePointMax;
    }

    private void Update()
    {
        lifeBar.fillAmount = lifePoint / lifePointMax;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            canAttack = true;
            CallDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            canAttack = false;
        }
    }

    public void TakeDamage()
    {
        lifePoint -= damageTaken;
        Debug.Log("oui");
        CheckLife();
    }

    private void CheckLife()
    {
        if(lifePoint <= 0)
        {
            Debug.Log("loose");
        }
    }

    private void CallDamage()
    {

        if (canAttack)
        {
            TakeDamage();
            Invoke("CallDamage", attackSpeed);
        }

    }
}
