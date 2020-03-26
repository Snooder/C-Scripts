using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterController : MonoBehaviour
{
    public TMP_Text m_TextComponent;
    public TMP_Text arrowsLeftText;
    public TMP_Text scoreText;
    public Rigidbody arrowPrefab;
    public Camera playercamera;
    public Animator anim;
    public Transform arrowSpawn;
    public GameObject arrow;
    public GameObject player;
    public GameObject bow;
    WindDirection windScript;
    public WindZone windzone;
    public GameObject WinText;
    public GameObject LostText;

    float pullStartTime;
    int drawing = 0;
    public float speed = 10.0f;
    private float translation;
    private float straffe;
    public float score = 0;
    public int arrowsLeft = 10;

    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        GameObject windObject = GameObject.Find("WindZone");
        WindDirection windScript = windObject.GetComponent<WindDirection>();

        WinText = GameObject.Find("WinText");
        LostText = GameObject.Find("LostText");
        WinText.SetActive(false);
        LostText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (score >= 1000)
        {
            WinText.SetActive(true);
            LostText.SetActive(false);
        }

        if (arrowsLeft == 0 && score <= 1000)
        {
            LostText.SetActive(true);
            
            
        }


        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(key: KeyCode.Mouse0))
        {
            anim.Play("arrowBack");
            drawing = 1;
            pullStartTime = Time.time;



        }

        if (drawing == 1 && Input.GetKeyUp(key: KeyCode.Mouse0))
        {
            if (LostText.active == true)
            {
                LostText.SetActive(false);
                arrowsLeft = 10;
                score = 0;
                scoreText.text = "Score: " + score;

            }

            if(WinText.active == true)
            {
                WinText.SetActive(false);
                arrowsLeft = 10;
                score = 0;
                scoreText.text = "Score: " + score;
            }

            anim.Play("arrowIdle");
            float nextFire = Time.time - pullStartTime;
            m_TextComponent.text = "Power " + nextFire.ToString();

            arrow.AddComponent<TrailRenderer>();
            arrow.GetComponent<TrailRenderer>().startColor = Color.red;
            arrow.GetComponent<TrailRenderer>().endColor = Color.white;
            arrow.GetComponent<TrailRenderer>().startWidth = .3f;
            arrow.GetComponent<TrailRenderer>().endWidth = .1f;
            arrow.GetComponent<TrailRenderer>().time = .8f;

            Rigidbody arrowObject = Instantiate(arrowPrefab, arrowSpawn.transform.position, Quaternion.identity) as Rigidbody;
            arrowObject.GetComponent<BoxCollider>().isTrigger = true;
            Destroy(arrow.GetComponent<TrailRenderer>());
        
            arrowObject.transform.SetParent(bow.transform);
            arrowObject.transform.rotation = arrow.transform.rotation;
            arrowObject.transform.Rotate(0, 90, 0);
 
            Shoot(arrowObject, nextFire);
            
            arrowsLeft -= 1;
            arrowsLeftText.text = "Arrows Left: " + arrowsLeft;
            //GameObject.Destroy(arrowObject,3);

            //windScript.changeDirection();

            //m_Rigidbody.transform.position = transform.position + Camera.main.transform.forward;
            //Rigidbody arrowObject = Instantiate(m_Rigidbody, transform.position, transform.rotation);

            //arrowObject.velocity = transform.forward * 10;
            // Shoot();
            //arrowObject.velocity = transform.TransformDirection(Vector3(0,0,10f));
            //m_Rigidbody.velocity = Camera.main.transform.forward * 40;
            // arrowSpeed = ArrowSpeed * timePulledBack;
            drawing = 0;

        }


        //m_Rigidbody.velocity = transform.forward * m_Speed;
    }


    void Shoot(Rigidbody arrowObject, float nextFire)
    {
        //anim.Play("Exit");
        arrowObject.isKinematic = false;
        Destroy(arrowObject.GetComponent<Animator>());
        arrowObject.transform.SetParent(null, true);
        arrowObject.AddForce(arrowSpawn.transform.forward * 1000f * nextFire);
        Debug.Log(arrowObject.position.y);


    }

}