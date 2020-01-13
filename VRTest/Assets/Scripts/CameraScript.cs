using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Vector3 offset;

    public GameObject player;

    public float camPosX;
    public float camPosY;
    public float camPosZ;

    public float camRotationX;
    public float camRotationY;
    public float camRotationZ;

    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(player.transform.position.x + camPosX, player.transform.position.y + camPosY, player.transform.position.z + camPosZ);
        transform.rotation = Quaternion.Euler(camRotationX, camRotationY, camRotationZ);
    }
    

    // Update is called once per frame
    void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
}
