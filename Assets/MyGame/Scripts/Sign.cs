using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] GameObject signUI;
    [SerializeField] ParticleSystem fx;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            signUI.SetActive(true);
            fx.Stop();
        }
    }
}
