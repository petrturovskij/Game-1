
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour
{
    public float _speed = 5;
    public float runSpeed = 10;
    private Rigidbody rb;
    private Vector3 _direction;
    public GameObject bullet;
    public Transform spown;
    public float damage;
    public Camera cam;
    private bool isRunning;
    public float range;
    public Transform orientation;
    private Animator animator;
    private void Start()
    {
        animator= GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        if (Input.GetButtonDown("Run"))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        animator.SetFloat("Z", _direction.z);
        animator.SetFloat("X", _direction.x);
        
    }
    private void FixedUpdate()
    {
        var moveDirection = orientation.forward * _direction.z + orientation.right * _direction.x; 
        rb.AddForce(moveDirection.normalized * (isRunning ? runSpeed : _speed) * 10f, ForceMode.Force);

    }
    private void Hit(GameObject collisionGO)
    {
        if (collisionGO.TryGetComponent(out Health HP))
        {
            HP.Hit(damage);
        }
        Destroy(gameObject);
    }
    private void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.Hurt(damage);
            }

        }

    }
}





