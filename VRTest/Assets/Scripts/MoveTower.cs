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
    private float currentLinearMapping = float.NaN;

    float prevrotation;
    // Start is called before the first frame update
    private void Awake()
    {
        this.slider.onValueChanged.AddListener(this.Rotate);

        if (linearMapping == null)
        {
            linearMapping = GetComponent<LinearMapping>();
        }
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
    }

    public void Rotate(float rotation)
    {
        float delta = rotation - this.prevrotation;
        this.tower.transform.Rotate(Vector3.up * delta * 180);

        this.prevrotation = rotation;


    }
}
