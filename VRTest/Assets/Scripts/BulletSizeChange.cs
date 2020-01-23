using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

namespace UnityEngine.UI.Extensions
{

    public class BulletSizeChange : MonoBehaviour
    {
        MoveCannon moveCannon;
        public GameObject cannon;
        public RadialSlider slider;
        float size;
        public LinearMapping linearMapping;
        private float currentLinearMapping = float.NaN;
        public Text bulletchangetext;
        public Text bulletchangetext2d;

        // Start is called before the first frame update

        private void Awake()
        {
            GameObject bulletChanger = GameObject.Find("Cannon");
            moveCannon = bulletChanger.GetComponent<MoveCannon>();
            this.slider.onValueChanged.AddListener(this.ChangeBullet);

            if (linearMapping == null)
            {
                linearMapping = GetComponent<LinearMapping>();
            }

            this.size = linearMapping.value;

            this.size = this.slider.Angle;
            
        }

        private void Update()
        {
            if (currentLinearMapping != linearMapping.value)
            {
                currentLinearMapping = linearMapping.value;
                float delta = (currentLinearMapping + this.size * 2f);
                moveCannon.bulletPrefab.transform.localScale = new Vector3(delta, delta, delta);
                Debug.Log(moveCannon.bulletPrefab.transform.localScale);
                moveCannon.firespeed =
                moveCannon.firespeed = 15 - (currentLinearMapping + this.size * 10f);
                Debug.Log(moveCannon.firespeed);
                Changetext();

                this.size = currentLinearMapping;
            }
        }



        public void ChangeBullet(int changedSize)
        {
            float delta = (changedSize + this.size * 0.2f)/360;
            moveCannon.bulletPrefab.transform.localScale = new Vector3(delta, delta, delta);
            Debug.Log(moveCannon.bulletPrefab.transform.localScale);
            moveCannon.firespeed =
            moveCannon.firespeed = 15 - ((changedSize + this.size * 10f)/360);
            Debug.Log(moveCannon.firespeed);

            ChangeText2d();

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

        void Changetext()
        {
            float textoutput = linearMapping.value * 100; 
            bulletchangetext.text = "Value: " + textoutput.ToString();
        }

        void ChangeText2d()
        {
            float textouput = this.slider.Angle / 3.6f;
            bulletchangetext2d.text = "Value: " + textouput.ToString();
        }

        
    }
}
