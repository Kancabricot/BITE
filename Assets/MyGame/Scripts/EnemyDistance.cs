using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDistance : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] GameObject[] garden;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bullet;
    [SerializeField] int lifePoint = 3;
    [SerializeField] ParticleSystem walkFX;
    [SerializeField] ParticleSystem hitFX;
    public AudioSource audioEnnemy;

    [SerializeField] private float rangeVision = 5;
    [SerializeField] private float attackSpeed = 2;
    private float distanceBetween = 1000000;

    private void Start()
    {
        garden = GameObject.FindGameObjectsWithTag("Garden");
        player = GameObject.FindGameObjectWithTag("Player");

        ChooseTarget();

        GetComponent<NavMeshAgent>().destination = target.position;
    }

    private void ChooseTarget()
    {
        for (int i = 0; i < garden.Length; i++)
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

        if (Vector3.Distance(target.transform.position, transform.position) < rangeVision)
        {
            target = player.transform;
            GetComponent<Rigidbody>().Sleep();
            GetComponent<NavMeshAgent>().isStopped = true;
            Shoot();
            walkFX.Stop(); 
        }
    }

    public void IsTouch(int damage, int strength, Transform t)
    {

        if (lifePoint <= 0)
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

    private void Shoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        Invoke("Shoot", attackSpeed);
    }
}
