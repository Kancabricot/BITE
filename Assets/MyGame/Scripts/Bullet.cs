using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10;
    public void ShootDirection(Vector3 direction)
    {
        // Lancer le Bullet
        GetComponent<Rigidbody>().velocity = direction * speed;

        Destroy(gameObject, 2f);
    }
}
