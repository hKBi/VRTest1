using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class RotateCannon : MonoBehaviour

{
    public GameObject cannon;
    public Slider slider;
    public LinearMapping linearMapping;
    private float currentLinearMapping = float.NaN;


    float prevrotation;
    // Start is called before the first frame update
    private void Awake()
    {
        this.slider.onValueChanged.AddListener(this.OnSliderChanged);
        //this.slider3d.onValueChanged.AddListener(this.On3dSliderChanged);
        //GameObject slider3d = GameObject.Find("FreeSlideArtificialSlider");
        //linearMapping = slider3d.GetComponent<LinearMapping>();

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
            this.cannon.transform.Rotate(Vector3.back * delta * 20);

            this.prevrotation = currentLinearMapping;
        }
    }

    public void OnSliderChanged(float rotation)
    {
        float delta = rotation - this.prevrotation;
        this.cannon.transform.Rotate(Vector3.back * delta * 20);

        this.prevrotation = rotation;
    }

    
    


}
