using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollowPlayer : MonoBehaviour
{

    [SerializeField] private Transform tFollow;
    [SerializeField] private Vector3 offSet;

    void Update()
    {
        Vector3 newPos = tFollow.position - offSet;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }
}
