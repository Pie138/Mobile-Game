using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COL : MonoBehaviour
{
    public GameObject Prefab;

    public float timer;

    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
            Destroy(this.gameObject);
    }

    void DestroyCOL()
    {
        Destroy(this.gameObject);
    }
}
