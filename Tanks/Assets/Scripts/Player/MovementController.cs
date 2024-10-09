using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform tankBody;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector2 moveDir = GameInputs.Instance.GetMovementNormalized();
        
        if(moveDir != Vector2.zero) {
            HandleRotation(moveDir);
        }
        
        rb.velocity = moveDir * moveSpeed;
    }

    private void HandleRotation(Vector2 moveDir) {
        float targetAngle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        targetAngle += 90; // Adjust for the tank's initial downward orientation

        tankBody.eulerAngles = new Vector3(0, 0, targetAngle);
    }
}
