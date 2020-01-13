using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCounter : MonoBehaviour
{
    public int firecounter;
    int firecountertotal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            firecounter = firecounter + 1;
            Debug.Log("getroffen" + firecounter);
            
        }
        
    }
}
