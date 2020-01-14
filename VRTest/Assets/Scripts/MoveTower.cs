using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTower : MonoBehaviour
{

    public GameObject tower;
    public Slider slider;

    float prevrotation;
    // Start is called before the first frame update
    private void Awake()
    {
        this.slider.onValueChanged.AddListener(this.Rotate);

        this.prevrotation = this.slider.value;
    }


    public void Rotate(float rotation)
    {
        float delta = rotation - this.prevrotation;
        this.tower.transform.Rotate(Vector3.up * delta * 180);

        this.prevrotation = rotation;


    }
}
