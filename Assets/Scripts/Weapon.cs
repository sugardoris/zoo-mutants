using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shotPeriod;

    private void Start()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
            if (GeometryUtility.TestPlanesAABB(planes, gameObject.GetComponent<Collider2D>().bounds))
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }

            yield return new WaitForSeconds(shotPeriod);
        }
    }
}
