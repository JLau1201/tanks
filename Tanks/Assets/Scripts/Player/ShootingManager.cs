using System.Collections;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform bulletContainer;
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private ParticleSystem smokePS;

    // Max number of bullets on screen
    private float maxBullets;
    private float currBullets;

    private void Start() {
        // Subscribe to events
        GameInputs.Instance.OnShootInput += GameInputs_OnShootInput;
    }

    private void GameInputs_OnShootInput(object sender, System.EventArgs e) {
        // Return if number of bullets on screen is equal to max bullets
        if (currBullets == maxBullets) return;
        
        // Instantiate bullet
        // Orient and position bullet to bullet spawn point
        Transform bulletTransform = Instantiate(bulletPrefab, bulletContainer);
        bulletTransform.position = bulletSpawnPoint.position;
        bulletTransform.rotation = bulletSpawnPoint.rotation;

        ParticleSystem smoke = Instantiate(smokePS);
        smoke.transform.position = bulletSpawnPoint.position;

        Bullet bullet = bulletTransform.GetComponent<Bullet>();
        bullet.SetDirection();
        
    }
}
