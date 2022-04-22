using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LD_Hazard : MonoBehaviour
{
    public string color;

    public enum ZoneColor
    {
        GREEN,
        RED,
        CYAN,
        BLUE
    }

    public ZoneColor ZColor;

    public bool isWatery;
    public bool isBounce;
    public bool isFast;
    public bool isThing;

    SpriteRenderer SR;
    AreaEffector2D AE;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        AE = GetComponent<AreaEffector2D>();

        switch (ZColor)
        {
            case ZoneColor.BLUE:
                isWatery = true;
                AE.forceAngle = 90;
                AE.forceMagnitude = 10;
                SR.color = Color.blue;
                break;

            case ZoneColor.RED:
                isFast = true;
                AE.forceAngle = 0;
                AE.forceMagnitude = 8;
                SR.color = Color.red;
                break;

            case ZoneColor.CYAN:
                isBounce = true;
                AE.forceAngle = 90;
                AE.forceMagnitude = 5;
                AE.forceVariation = 15;
                SR.color = Color.cyan;
                break;

            case ZoneColor.GREEN:
                isThing = true;
                SR.color = Color.green;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
