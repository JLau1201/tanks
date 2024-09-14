using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBarrel : MonoBehaviour
{


    private void Update() {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 targetDir = (mouseWorldPos - (Vector2)transform.position).normalized;
        float targetAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        targetAngle += 90f; // Adjust for the barrel's initial downward orientation

        transform.eulerAngles = new Vector3(0, 0, targetAngle);
    }
}
