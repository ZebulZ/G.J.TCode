using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float FireRate;
    //position of the bullet spawn
    [SerializeField] private Transform BulletPoint;

    private bool CanShoot = true;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && CanShoot)
        {
            Instantiate(Bullet, BulletPoint);
            CanShoot = false;
            StartCoroutine(firerate());
        }
    }

    IEnumerator firerate()
    {
        yield return new WaitForSeconds(FireRate);
        CanShoot = true;
    }
}
