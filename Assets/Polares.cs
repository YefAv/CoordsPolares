using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Polares : MonoBehaviour
{
    [SerializeField]
    private Vector2 polarCoord;

    [SerializeField] private float angularSpeed, angularAcceleration;

    [SerializeField] private float radialSpeed, radialAcceleration;

    private float cos, sin;
    

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawPolar(polarCoord);
        transform.position = PolarToCartesian(polarCoord);

        radialSpeed += radialAcceleration * Time.deltaTime;
        polarCoord.x += radialSpeed * Time.deltaTime;

        angularSpeed += angularAcceleration * Time.deltaTime;
        polarCoord.y += angularSpeed * Time.deltaTime;

        if (Mathf.Abs(polarCoord.x)>5)
        {
            radialSpeed*=-1;

        }

    }

    void DrawPolar(Vector2 polarCord)
    {
        
        Debug.DrawLine(Vector3.zero, PolarToCartesian(polarCord), Color.cyan);
    }
    
    private Vector3 PolarToCartesian(Vector2 polar)
    {
        float r = polar.x;
        Vector3 rad = new Vector3(Mathf.Cos(polar.y)*r, Mathf.Sin(polar.y)*r);
        return rad;
    }
}
