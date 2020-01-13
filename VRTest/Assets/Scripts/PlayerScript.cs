using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position += Vector3.left * 0.5f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += Vector3.back * 0.5f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += Vector3.forward *0.5f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position += Vector3.right * 0.5f * Time.deltaTime;
        }
    }
}
