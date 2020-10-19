using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] obj;
    public float spawnInterval = 1f;
    public Vector3 pos = new Vector3(125, 10, -13);
    public float size = 1.0f;
    private Vector3 dir = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn()); 
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(obj[Random.Range(0, obj.Length)], pos, Quaternion.identity);
            pos += dir * size;
            yield return new WaitForSeconds(spawnInterval); 
        }
    }
}
