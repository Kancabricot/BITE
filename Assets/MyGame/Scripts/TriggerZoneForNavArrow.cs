using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneForNavArrow : MonoBehaviour
{
    [SerializeField] GameObject navArrow;

    private void OnTriggerEnter(Collider other)
    {
        navArrow.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        navArrow.SetActive(true);
    }
}
