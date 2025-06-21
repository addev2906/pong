using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovementLeft : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float speed;
    private Vector2 moveInput;
    public EventMangerScript events;
    void Start()
    {
        transform.position = new Vector3(-8,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (events.gameEnded==false)
        {
            moveInput.x = 0;
            moveInput.y = Input.GetAxisRaw("Vertical");

            moveInput.Normalize();

            rb.velocity = moveInput * speed;
        }
      
    }
}
