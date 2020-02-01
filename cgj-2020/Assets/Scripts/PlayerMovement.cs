﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction;

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
        rb2d.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
    
    private void ShootDirectionRay(Vector3 directionToLook) 
    {
        Debug.DrawRay(transform.position, directionToLook, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToLook, RAYCAST_LENGTH);

        if(hit.collider != null) 
        {
            if(hit.transform.tag.Equals("Item"))
            {
                Debug.Log("Am hitting");
                StartCoroutine(hit.transform.GetComponent<ItemGO>().InteractWith());
            }
        }
    }
}
