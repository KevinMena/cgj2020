using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction;

    public Vector3 lastDirection;

    [SerializeField] float horizontal;

    [SerializeField] float vertical;

    [SerializeField] const float RAYCAST_LENGTH = 2;

    Rigidbody2D rb2d;

    public float speed = 15f;

    void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 directionTWO) 
    {
        direction = directionTWO;
        if(!direction.Equals(Vector3.zero))
        {
            lastDirection = direction;
        }
        rb2d.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        ShootDirectionRay(lastDirection);
    }
    
    private void ShootDirectionRay(Vector3 directionToLook) 
    {
        Debug.DrawRay(transform.position, directionToLook, Color.red);
    }
}
