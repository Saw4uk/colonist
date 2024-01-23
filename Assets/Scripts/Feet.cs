using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public bool IsGrounded { get; set; }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
    }
}
