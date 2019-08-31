using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float FireRate;
    //position of the bullet spawn
    [SerializeField] private Transform BulletPoint;
    [SerializeField] private float[] lastPressed;

    [Header("Bullet Spawn Points")]
    [SerializeField] private GameObject BulletPointD;
    [SerializeField] private GameObject BulletPointU;
    [SerializeField] private GameObject BulletPointL;
    [SerializeField] private GameObject BulletPointR;

    [Header("State")]
    [HideInInspector]public bool IsInteracting;

    [Header("Bullet Diagonal Spawn Points")]
    [SerializeField] private GameObject SD;
    [SerializeField] private GameObject WD;
    [SerializeField] private GameObject WA;
    [SerializeField] private GameObject SA;

    private bool CanShoot = true;


    void Update()
    {

        //if pressing something set the horizontal value into the array
        if (Input.GetAxis("Horizontal") != 0)
        {
            lastPressed[0] = Input.GetAxisRaw("Horizontal");
        } // if not pressing anything start the routine
        else
        {
            StartCoroutine(NotPressed(lastPressed, true));
        }
        //if pressing something set the vertical value into the array
        if (Input.GetAxis("Vertical") != 0)
        {
            lastPressed[1] = Input.GetAxisRaw("Vertical");
        }// if not pressing anything start the routine
        else
        {
            StartCoroutine(NotPressed(lastPressed, false));
        }
            //if the horizontal vaue is 1 set bool to idle rigth
            if (lastPressed[0] == 1)
            {
                BulletPoint = BulletPointR.transform;
                BulletPointR.SetActive(true);
                BulletPointU.SetActive(false);
                BulletPointD.SetActive(false);
                BulletPointL.SetActive(false);
            }
            //if the horizontal vaue is -1 set bool to idle left
            if (lastPressed[0] == -1)
            {
                BulletPoint = BulletPointL.transform;
                BulletPointR.SetActive(false);
                BulletPointU.SetActive(false);
                BulletPointD.SetActive(false);
                BulletPointL.SetActive(true);
            }
            //if the vertical vaue is 1 set bool to idle up
            if (lastPressed[1] == 1)
            {
                BulletPoint = BulletPointU.transform;
                BulletPointR.SetActive(false);
                BulletPointU.SetActive(true);
                BulletPointD.SetActive(false);
                BulletPointL.SetActive(false);
            }
            //if the vertical vaue is -1 set bool to idle down
            if (lastPressed[1] == -1)
            {
                BulletPoint = BulletPointD.transform;
                BulletPointR.SetActive(false);
                BulletPointU.SetActive(false);
                BulletPointD.SetActive(true);
                BulletPointL.SetActive(false);
            }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            BulletPoint = WA.transform;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            BulletPoint = WD.transform;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            BulletPoint = SD.transform;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            BulletPoint = SA.transform;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && CanShoot && !IsInteracting)
        {
            Instantiate(Bullet, BulletPoint.position, BulletPoint.rotation);
            CanShoot = false;
            StartCoroutine(firerate());
        }
    }
    IEnumerator NotPressed(float[] Lastpressed, bool Horizontal)
    {
        //wait untill end of frme to set the last pressed values to 0
        yield return new WaitForEndOfFrame();
        if (Horizontal)
        {
            lastPressed[0] = 0;
        }
        else
        {
            lastPressed[1] = 0;
        }
    }


    IEnumerator firerate()
    {
        yield return new WaitForSeconds(FireRate);
        CanShoot = true;
    }
}
