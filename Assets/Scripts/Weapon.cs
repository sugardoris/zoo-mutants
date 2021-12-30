using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private void Start()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            yield return new WaitForSeconds(2f);
        }
    }
}
