using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float JumpStreng = 2f;
    [SerializeField] private float maxGroundDistance = 0.3f;
    
     private Rigidbody _rigidbody;
     private Transform _GroundCheckObjeck;

    private bool isGrounded;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _GroundCheckObjeck = GameObject.FindGameObjectWithTag("Ground Check").transform; 
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(_GroundCheckObjeck.transform.position, Vector3.down, maxGroundDistance);
          if (Input.GetButtonDown("Jump") && isGrounded)
            _rigidbody. AddForce(Vector3.up * 100 * JumpStreng);
    }
}
