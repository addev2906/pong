 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ComputerAI : MonoBehaviour
{
    public CollisionScript collisionScript;
    public Rigidbody2D compRB;
    public new Collider2D collider;
    [SerializeField] float compSpeed;

    private void Start()
    {
        transform.position = new Vector3(8,0,0);
    }
    public void seek()
    {
        float dist = Mathf.Abs(transform.position.y - collisionScript.hitPoint.y);
        if (collisionScript.hitPoint.y>transform.position.y)
        {
            if (dist >= 0.2) { compRB.velocity = new Vector2(0, compSpeed); }
            
            else
            {
                compRB.velocity = Vector2.zero;
            }
        }
        
        if (collisionScript.hitPoint.y < transform.position.y){
            if (dist >= 0.4) { compRB.velocity = new Vector2(0, -compSpeed); }
            
            else { compRB.velocity = Vector2.zero; }
        }
        

    }



}
