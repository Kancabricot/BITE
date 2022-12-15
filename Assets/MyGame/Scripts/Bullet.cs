using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float strength = 0.5f;
    private GameObject target;
    private Vector3 targetPos;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Garden");
        //transform.LookAt(target.transform.position);


        //GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
        targetPos = new Vector3(target.transform.position.x, target.transform.position.y , target.transform.position.z);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Garden"))
        {
            Destroy(gameObject);
            FindObjectOfType<Garden>().DamageBullet(strength);
            Debug.Log("meurt");
        }
    }
}
