using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGravity : MonoBehaviour 
{
    public Transform objectToOrbit;
    Rigidbody2D rb;
    [Header("USING VELOCITY(Using Initial Impulse = false)")]
    public float orbitSpeed;
    public float gravityVelocity;
    [Header("Using Initial Impulse")]
    public float gravity;
    public float initialImpulse;
    public bool usingInitialImpulse;
    Vector2 direction;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        if (usingInitialImpulse == true) {
            direction = objectToOrbit.transform.position - transform.position;
            transform.right = direction;
            rb.AddForce(transform.up * initialImpulse);
        }
    }
    void Update() {
        if (objectToOrbit.gameObject != null) {
            direction = objectToOrbit.transform.position - transform.position;
            
            if (direction.y > -0.6 && direction.y < 0.6) {
                direction.y += 1;
            }
            transform.right = direction;
            Debug.DrawRay(transform.position, transform.right * 100, Color.red);
            Debug.DrawRay(transform.position, transform.up * 100, Color.green);
            
            if (usingInitialImpulse) {
                rb.AddForce(transform.right * gravity);
            }
            else {
                rb.freezeRotation = true;
                rb.velocity = transform.right * gravityVelocity + transform.up * orbitSpeed;
            }

        }
    }
}