using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class arrowController : MonoBehaviour
{
    public TMP_Text m_TextComponent;
    Rigidbody myBody;
    private float lifetimer = 2f;
    private float timer;
    private bool hitSomething = false;
    public float score;
    CharacterController playerScript;
    public GameObject windObject;


    //GameObject arrowObject;
    //public GameObject arrowPrefab;
    //public Transform arrowSpawn;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        myBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        playerScript = GameObject.Find("Capsule").GetComponent<CharacterController>();



    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update() {
        myBody.AddForce(windObject.transform.forward * 10);
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

        if (other.gameObject.name == "Cylinder.50")
        {
            Debug.Log("Hit 50");
            playerScript.score += 50;

            hitSomething = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;

            Stick();
            return;

        }
        if (other.gameObject.name == "Cylinder.100")
        {
            Debug.Log("Hit 100");
            playerScript.score += 100;
            hitSomething = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;

            Stick();
            return;



        }
        if (other.gameObject.name == "Cylinder.150")
        {
            Debug.Log("Hit 150");
            playerScript.score += 150;
            hitSomething = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;
            Stick();
            return;



        }
        if (other.gameObject.name == "Cylinder.175")
        {
            Debug.Log("Hit 175");
            playerScript.score += 175;
            hitSomething = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;

            Stick();
            return;



        }
        if (other.gameObject.name == "Cylinder.200")
        {
            Debug.Log("Hit 200");
            playerScript.score += 200;
            hitSomething = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;

            Stick();
            return;



        }
        if (other.gameObject.name == "Cylinder.225")
        {
            Debug.Log("Hit 225");
            playerScript.score += 225;
            hitSomething = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;

            Stick();
            return;



        }
        if (other.gameObject.name == "Cylinder.250")
        {
            Debug.Log("Hit 250");
            playerScript.score += 250;
            hitSomething = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;

            Stick();
            return;



        }
        if (other.gameObject.name == "Cylinder.300")
        {
            Debug.Log("Hit 300");
            playerScript.score += 300;
            hitSomething = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;

            Stick();
            return;




        }

    }

    private void Stick()
    {
        m_TextComponent.text = "Score: " + playerScript.score.ToString();

    }
}
