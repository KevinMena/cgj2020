using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction;

    [SerializeField] float horizontal;

    [SerializeField] float vertical;

    public float speed = 5f;

    void Update()
    {
        horizontal = 0f;
        vertical = 0f;

        if(Input.GetAxisRaw("Horizontal") != 0) 
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = 0f;
        } 
        else if(Input.GetAxisRaw("Vertical") != 0)
        {
            vertical = Input.GetAxisRaw("Vertical");
            horizontal = 0f;
        }

        direction = new Vector3(horizontal, vertical, 0);

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        Debug.DrawRay(transform.position, direction.normalized, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 2f);

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
