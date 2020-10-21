using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] obj;
    public float spawnInterval = 7f;
    public Vector3 pos = new Vector3(125, 10, -13);
    public float size = 1.0f;
    private Vector3 dir = Vector3.right;

    List<GameObject> platforms = new List<GameObject>();
    public int maxPlatforms = 3;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn()); 

    }

    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject go = Instantiate(obj[Random.Range(0, obj.Length)], pos, Quaternion.identity);
            platforms.Add(go);

            if (platforms.Count > maxPlatforms)
            {
                GameObject oldestPlatform = platforms[0];
                Destroy(oldestPlatform);
                platforms.Remove(oldestPlatform);
            }

            pos += dir * size;
            yield return new WaitUntil(() => pos.x - player.position.x < 70);                             
        }
    }
    
    
}
