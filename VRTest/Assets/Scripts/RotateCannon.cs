using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateCannon : MonoBehaviour

{
    public GameObject cannon;
    public Slider slider;

    float prevrotation;
    // Start is called before the first frame update
    private void Awake()
    {
        this.slider.onValueChanged.AddListener(this.OnSliderChanged);

        this.prevrotation = this.slider.value;
    }

  public void OnSliderChanged(float rotation)
    {
        float delta = rotation - this.prevrotation;
        this.cannon.transform.Rotate(Vector3.back * delta * 20);

        this.prevrotation = rotation;
    }
}
