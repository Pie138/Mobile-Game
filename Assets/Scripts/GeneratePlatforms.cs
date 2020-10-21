//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GeneratePlatforms : MonoBehaviour
//{

//    public bool needtogenerate = false;
//    public Transform generate;

//    // start is called before the first frame update
//    void Start()
//    {

//    }

//    // update is called once per frame
//    void Update()
//    {
//        if (needtogenerate)
//        {
//            generateplatform();
//        }
//    }

//    void generateplatform()
//    {
//        gameobject obj = objectpooler.current.getpooledobject();

//        if (obj == null)
//            return;
//        obj.transform.position = generate.transform.position;
//        obj.transform.rotation = transform.rotation;
//        obj.setactive(true);
//        needtogenerate = false;
//    }
//}
