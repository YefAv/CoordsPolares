using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LookAtAcceleration : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 acceleration;

    void Update()
    {
        Vector3 mousePos = GetWorldMousePosition();
        Vector3 diference = mousePos - transform.position;
        
        
        
        Move(diference);

    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;

        return worldPos;
    }
    
    
    private void Move(Vector3 direction)
    {
        acceleration = direction;
        velocity += acceleration*Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

            
        float radians = Mathf.Atan2(velocity.y, velocity.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);
    }

}
