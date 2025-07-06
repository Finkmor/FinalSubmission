using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int speed = 3;
    [SerializeField] private Rigidbody rb;
    public static Player instance;
    public bool alive;


    private void Update()
    {
        PlayerMove();
        PlayerBound();
    }
    private void PlayerMove()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");
        var overallInput = verticalInput + horizontalInput;
        rb.maxLinearVelocity = 10;
        rb.AddForce(Vector3.forward * verticalInput * speed);
        rb.AddForce(Vector3.right * horizontalInput * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Projectile"))
        {
            alive = false;
            Destroy(gameObject);
        }
    }
    private void PlayerBound()
    {
        if (transform.position.x > 23 || transform.position.x < -22)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > 12 || transform.position.z < -16)
        {
            Destroy(gameObject);
        }
    }

}
