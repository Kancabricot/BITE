using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] Image cdBar;

    [SerializeField] GameObject allBar;

    Vector3 moveDirection;
    Vector3 aimDirection;
    float moveSpeed = 0;
    [SerializeField] float speedMax = 10f;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float decceleration = 0.1f;
    [SerializeField] float smoothRotation = 0.1f;
    public AudioSource audioPlayer;
    [SerializeField] GameObject Pelle;

    [SerializeField] ParticleSystem walkFX;

    [SerializeField] float atkspeed = 2f;
    private float cdAtk;
    private bool canAtk = true;
    [SerializeField] int damage = 1;
    [SerializeField] private int strength = 200;


    // Cache
    Rigidbody rb;
    GameManager gameManager;
    private bool isDistance = false;
    private bool isTrigger = false;
    private GameObject target;
    
    private bool haveShowel = false;
    private bool canPlayFX = false;
    private bool canStopFX = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        //cdBar = GetComponent<Image>();

        cdAtk = 0;
    }

    void Update()
    {
        cdBar.fillAmount = cdAtk / atkspeed;
       


        if (joystick.Direction.magnitude > 0)
        {
            
            // Vecteur de direction de déplacement
            moveDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y).normalized;
            moveSpeed = Mathf.Lerp(moveSpeed, speedMax, acceleration) * joystick.Direction.magnitude;

        } else {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, decceleration);
            
        }
        
        if (joystick.Direction.magnitude > 0 && canPlayFX == true)
        {
            walkFX.Play();
            canPlayFX = false;
            canStopFX = true;
        }
        else if (joystick.Direction.magnitude <= 0 && canStopFX == true)
        {
            walkFX.Stop();
            canStopFX = false;
            canPlayFX = true;
        }

        if (isTrigger)
        {
            //transform.LookAt(target.transform.position);
        }
        else
        {
            // Orientation du player
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, smoothRotation);
            aimDirection = moveDirection;
        }

        if(canAtk == false)
        {
            allBar.SetActive(true);
            if(cdAtk >= atkspeed)
            {
                canAtk = true;
                cdAtk = 0;
                allBar.SetActive(false);
            }
            else
            {
                cdAtk += Time.deltaTime;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isTrigger = true;
            target = other.gameObject;
            TryToShoot(other.gameObject);
        }

        if (other.CompareTag("EnemyDistance"))
        {
            isDistance = true;
            isTrigger = true;
            target = other.gameObject;
            TryToShoot(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isTrigger = false;
        }

        if (other.CompareTag("EnemyDistance"))
        {
            isTrigger = false;
            isDistance = false;
        }
    }

    private void FixedUpdate()
    {
        // Vélocité = direction * vitesse * inclinaison du joystick
        rb.velocity = moveDirection * moveSpeed;

    } 
    void TryToShoot(GameObject targetfunction)
    {
        if(haveShowel == true)
        {
            if(canAtk == true)
            {
                Pelle.transform.DORotate(new Vector3(90 + 0, 0),0.15f)
                    .SetLoops(2,LoopType.Yoyo);
                audioPlayer.Play();
                if(isDistance == true)
                {
                    Debug.Log("rentre");
                    targetfunction.GetComponent<EnemyDistance>().IsTouch(damage, strength, transform);
                    isDistance = false;
                }
                else
                {
                    targetfunction.GetComponent<Enemy>().IsTouch(damage, strength, transform);
                }
               
                canAtk = false;
            }
        }
    }

    public void TakeShowel()
    {
        haveShowel = true;
    }

    public void Upgrade()
    {
        atkspeed = atkspeed / 2;
    }
}