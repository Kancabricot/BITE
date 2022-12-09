using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x - 10, transform.forward.y + 5, transform.forward.z), ForceMode.Impulse);
        Debug.Log(transform.forward.x);
        Debug.Log(transform.forward.y);
        Debug.Log(transform.forward.z);
    }
}
