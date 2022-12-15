using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garden : MonoBehaviour
{
    [SerializeField] public float lifePoint = 20;
    [SerializeField] Image lifeBar;
    [SerializeField] public float lifePointMax = 20;
    [SerializeField] private float damageTaken = 1;
    [SerializeField] private bool lastGarden = false;
    [SerializeField] ParticleSystem fxHit;

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
        fxHit.Play();
        CheckLife();
    }

    private void CheckLife()
    {
        if(lifePoint <= 0)
        {
            if (lastGarden)
            {
                FindObjectOfType<GameManager>().IsFinish();
            }
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

    public void DamageBullet(float damage)
    {
        lifePoint -= damage;
        fxHit.Play();
        Debug.Log("take damage by bullet");
    }
}
