using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask bulletLayer;
    [SerializeField] private LayerMask tankLayer;
    [SerializeField] private ParticleSystem explosionPS;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;

    private Vector2 moveDirection;
    private float numBounces = 0;
    private float maxBounces = 1;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        int collisionLayer = 1 << collision.gameObject.layer;

        // Case for wall collision
        if(collisionLayer == wallLayer) {
            Vector2 wallNormal = collision.GetContact(0).normal;
            HandleWallCollision(wallNormal);
        }else if(collisionLayer == bulletLayer) {
            HandleBulletDestroy();
        }
    }

    private void HandleWallCollision(Vector2 wallNormal) {
        rb.velocity = Vector2.Reflect(moveDirection, wallNormal);
        moveDirection = rb.velocity;
        float targetAngle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));

        if (numBounces == maxBounces) {
            HandleBulletDestroy();
        } else {
            numBounces++;
        }
    }

    private void HandleBulletDestroy() {
        ParticleSystem explosion = Instantiate(explosionPS);
        explosion.transform.position = transform.position;
        Destroy(gameObject);
    }

    public void SetDirection() {
        rb.velocity = transform.up * moveSpeed;
        moveDirection = rb.velocity;
    }
}
