using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class MoveTower : MonoBehaviour
{

    public GameObject tower;
    public Slider slider;
    public LinearMapping linearMapping;
    public LinearMapping linearMapping2d;
    private float currentLinearMapping = float.NaN;
    private float currentlinearmapping2d = float.NaN;

    float prevrotation;
    // Start is called before the first frame update
    private void Awake()
    {
        this.slider.onValueChanged.AddListener(this.Rotate);

        if (linearMapping == null)
        {
            linearMapping = GetComponent<LinearMapping>();
        }
        else if (linearMapping2d == null)
        {
            linearMapping2d = GetComponent<LinearMapping>();
        }
        this.prevrotation = linearMapping2d.value;
        this.prevrotation = linearMapping.value;

        this.prevrotation = this.slider.value;
    }

    private void Update()
    {
        if (currentLinearMapping != linearMapping.value)
        {
            currentLinearMapping = linearMapping.value;
            float delta = currentLinearMapping - this.prevrotation;
            this.tower.transform.Rotate(Vector3.up * delta * 180);
            
            this.prevrotation = currentLinearMapping;
        }
        else if (currentlinearmapping2d != linearMapping2d.value)
        {
            currentlinearmapping2d = linearMapping2d.value;
            float delta = currentlinearmapping2d - this.prevrotation;
            this.tower.transform.Rotate(Vector3.up * delta * 180);

            this.prevrotation = currentlinearmapping2d;
        }
    }

    public void Rotate(float rotation)
    {
        float delta = rotation - this.prevrotation;
        this.tower.transform.Rotate(Vector3.up * delta * 180);

        this.prevrotation = rotation;


    }
}
