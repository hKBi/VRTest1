using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine.UI.Extensions
{

    public class BulletSizeChange : MonoBehaviour
    {
        MoveCannon moveCannon;
        public GameObject cannon;
        public RadialSlider slider;
        float size;
        // Start is called before the first frame update

        private void Awake()
        {
            GameObject bulletChanger = GameObject.Find("Cannon");
            moveCannon = bulletChanger.GetComponent<MoveCannon>();
            this.slider.onValueChanged.AddListener(this.ChangeBullet);

            this.size = this.slider.Angle;
            
        }



        public void ChangeBullet(int changedSize)
        {
            float delta = (changedSize + this.size * 0.2f)/1000;
            moveCannon.bulletPrefab.transform.localScale = new Vector3(delta, delta, delta);
            Debug.Log(moveCannon.bulletPrefab.transform.localScale);
            moveCannon.firespeed =
            moveCannon.firespeed = 15 - ((changedSize + this.size * 10f)/1000);
            Debug.Log(moveCannon.firespeed);

            this.size = changedSize;






            /*else if (Input.GetKeyDown(KeyCode.M))
            {
                bulletPrefab.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
                if (firespeed <= 15)
                {
                    firespeed = firespeed + 0.5f;
                }
            }*/
        }

        
    }
}
