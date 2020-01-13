using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTower : MonoBehaviour
{
    int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.up * speed * Time.deltaTime);

            
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.down * speed * Time.deltaTime);

           
        }

        /*Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.y = Mathf.Clamp(currentRotation.y, -90.0f, 90.0f);
        transform.localRotation = Quaternion.Euler(currentRotation);*/

    }
}
