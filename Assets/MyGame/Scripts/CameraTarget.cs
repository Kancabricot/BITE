using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] Transform target;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        // Nouvelle position
        Vector3 newPos = offset + target.position;
        transform.position = newPos;

        // Oriente la vision de la caméra

        transform.LookAt(target);
    }
}
