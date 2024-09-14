using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{


    private void Start() {
        // Subscribe to events
        GameInputs.Instance.OnShootInput += GameInputs_OnShootInput;
    }

    private void GameInputs_OnShootInput(object sender, System.EventArgs e) {
        
    }
}
