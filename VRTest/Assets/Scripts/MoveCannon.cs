using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Valve.VR.Extras;

public class MoveCannon : MonoBehaviour
{
    float speed = 10;
    public float firespeed = 10;
    public GameObject bulletPrefab;
    public GameObject spawnPoint;
    private float nextFire;
    public float fireRate;
    int fired;
    private GameObject bullet;
    public Button draw;
    public Button fire;
    public SteamVR_LaserPointer laserPointer;
  
    // Start is called before the first frame update

    private void Awake()
    {
        //laserPointer.PointerClick += FireBullet;
        //laserPointer.PointerClick += drawPrediction;
    }
    void Start()
    {
        bulletPrefab.transform.localScale = new Vector3(0.2f,0.15f,0.15f);
        draw.onClick.AddListener(drawPrediction);
        fire.onClick.AddListener(FireBullet);
        
    }

    // Update is called once per frame1
    void Update()
    {
        
        //FireBullet();
        //drawPrediction();
        ChangeBullet();


    }


    public void FireBullet(/*object sender, PointerEventArgs e*/)
    {
        if(Time.time > nextFire /*&& e.target.name == "Fire"*/)
        {

            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;

            bullet.GetComponent<Rigidbody>().velocity = new Vector3(transform.up.x * firespeed, transform.up.y * firespeed, transform.up.z * firespeed);
           
            fired = fired + 1;
            Debug.Log("feuert" + fired);
            


        }
    }

    
    void ChangeBullet()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            bulletPrefab.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            {
                firespeed = firespeed - 0.5f;
            }
            Debug.Log(firespeed);
        }
        else if(Input.GetKeyDown(KeyCode.M))
        {
            bulletPrefab.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
            if (firespeed <= 15)
            {
                firespeed = firespeed + 0.5f;
            }
        }
    }

   public void drawPrediction(/*object sender, PointerEventArgs e*/)
    {
       // if (e.target.name == "Load")
        //{
            DrawTraject(spawnPoint.transform.position, new Vector3(transform.up.x * firespeed, transform.up.y * firespeed, transform.up.z * firespeed), Physics.gravity);
        //}
            
    }

    void DrawTraject(Vector3 startpos, Vector3 velocity, Vector3 gravity)
    {
        int numsteps = 20;
        float timeDelta = 1.0f / velocity.magnitude;
        var line = this.gameObject.GetComponent<LineRenderer>();
        line.positionCount = numsteps;
        line.useWorldSpace = true;

        Vector3 pos = startpos;
        Vector3 vel = velocity;

        for (var i = 0; i < numsteps; i++)
        {
            line.SetPosition(i, pos);
            vel += gravity * timeDelta;
            pos += vel * timeDelta + (0.5f * gravity * timeDelta * timeDelta);
        }
    }
}
