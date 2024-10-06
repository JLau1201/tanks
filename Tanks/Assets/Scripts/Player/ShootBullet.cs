using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform bulletContainer;
    [SerializeField] private float bulletMoveSpeed;

    private float ammo = 5;
    private float reloadTime = 3;

    private void Start() {
        // Subscribe to events
        GameInputs.Instance.OnShootInput += GameInputs_OnShootInput;
    }

    private void GameInputs_OnShootInput(object sender, System.EventArgs e) {
        // Return if out of ammo
        if (ammo == 0) return;
        
        // Instantiate bullet
        // Orient and position bullet to bullet spawn point
        Transform bulletTransform = Instantiate(bulletPrefab, bulletContainer);
        bulletTransform.position = bulletSpawnPoint.position;
        bulletTransform.rotation = bulletSpawnPoint.rotation;

        Bullet bullet = bulletTransform.GetComponent<Bullet>();
        bullet.SetDirection();
        
        ammo -= 1;
        StartCoroutine(ReloadBullet());
    }

    private IEnumerator ReloadBullet() {
        yield return new WaitForSeconds(reloadTime);
        ammo++;
    }
}
