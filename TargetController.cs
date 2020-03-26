using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
         * 50
         * 100
         * 150
         * 175
         * 200
         * 225
         * 250
         * 300
         */
        Debug.Log("Hit");

        if (other.gameObject.name == "Cylinder.50")
        {
            Debug.Log("Hit 50");
        }
        if (other.gameObject.name == "Cylinder.100")
        {
            Debug.Log("Hit 100");

        }
        if (other.gameObject.name == "Cylinder.150")
        {
            Debug.Log("Hit 150");

        }
        if (other.gameObject.name == "Cylinder.175")
        {
            Debug.Log("Hit 175");

        }
        if (other.gameObject.name == "Cylinder.200")
        {
            Debug.Log("Hit 200");

        }
        if (other.gameObject.name == "Cylinder.225")
        {
            Debug.Log("Hit 225");

        }
        if (other.gameObject.name == "Cylinder.250")
        {
            Debug.Log("Hit 250");

        }
        if (other.gameObject.name == "Cylinder.300")
        {
            Debug.Log("Hit 300");

        }
    }
}
