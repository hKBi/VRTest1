using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HoverButtonEvent : MonoBehaviour
{
    MoveCannon moveCannon;

    private void Awake()
    {
        GameObject hoverButton = GameObject.Find("Cannon");
        moveCannon = hoverButton.GetComponent<MoveCannon>();
        
    }
    
    public void OnPressDrawPrediction(Hand hand)
    {
        moveCannon.drawPrediction();
    }

    public void OnPressFireBullet(Hand hand)
    {
        moveCannon.FireBullet();
    }
}
