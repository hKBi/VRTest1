using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCounter : MonoBehaviour
{
    public int firecounter;
    int firecountertotal;
    public Text counterText;
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

            SetCountText();
        }
        
    }
    void SetCountText ()
    {
        counterText.text = "Hit: " + firecounter.ToString();
    }
        

}
