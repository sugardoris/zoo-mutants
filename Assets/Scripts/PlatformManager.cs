using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;
    
    [SerializeField]
    private GameObject platformPrefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
             Destroy(gameObject);
        }
    }
    
    void Start()
    {
        Instantiate(platformPrefab, new Vector2(97.74135f, 1.25f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(107.2544f, 1.124956f), platformPrefab.transform.rotation);
    }

    // IEnumerator SpawnPlatform(Vector2 spawnPosition)
    // {
    //     yield return new WaitForSeconds(5f);
    //     Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    // }
}
