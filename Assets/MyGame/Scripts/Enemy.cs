using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] GameObject[] garden;
    [SerializeField] GameObject player;
    [SerializeField] int lifePoint = 3;
    [SerializeField] ParticleSystem walkFX;
    [SerializeField] ParticleSystem hitFX;
    [SerializeField] ParticleSystem stunFX;
    public AudioSource audioEnnemy;
    private float distanceBetween = 1000000;
    private float tempStun = 1f;

    private void Start()
    {
        garden = GameObject.FindGameObjectsWithTag("Garden");
        player = GameObject.FindGameObjectWithTag("Player");

        ChooseTarget();

        GetComponent<NavMeshAgent>().destination = target.position;
    }

    private void ChooseTarget()
    {
        for(int i = 0; i < garden.Length; i++)
        {
            if (Vector3.Distance(garden[i].transform.position, transform.position) < distanceBetween)
            {
                target = garden[i].transform;
                distanceBetween = Vector3.Distance(garden[i].transform.position, transform.position);
            }
        }
    }

    void Update()
    {
        if(GetComponent<Rigidbody>().velocity != new Vector3(0, 0, 0))
        {
            walkFX.Stop();
        }
    }

    public void IsTouch(int damage, int strength, Transform t)
    {
        
        if(lifePoint <= 0)
        {
            //Destroy(Collider);
            audioEnnemy.Play();
            GetComponent<TrailRenderer>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(t.forward.x, t.forward.y, t.forward.z) * strength, ForceMode.Impulse);
            Invoke("Death", 1f);
            walkFX.Stop();
            hitFX.Play();
        }
        else
        {
            lifePoint -= damage;
            Stun();
            hitFX.Play();
        }
        
        
    }

    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x - 10, transform.forward.y + 5, transform.forward.z) / 2, ForceMode.Impulse);
    }

    private void Death()
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().CheckWave();
    }

    private void Stun()
    {
        GetComponent<Rigidbody>().Sleep();
        GetComponent<NavMeshAgent>().isStopped = true;
        stunFX.Play();
        Invoke("Restart", tempStun);
    }

    private void Restart()
    {
        stunFX.Stop();
        GetComponent<NavMeshAgent>().isStopped = false;
    }

}
