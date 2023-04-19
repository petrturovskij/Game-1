using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    void Start()
    {
        Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(transform.forward * 50f, ForceMode.Impulse);

    }
    private void Hit(GameObject collisionGO)
    {
        if (collisionGO.TryGetComponent(out Health HP))
        {
            HP.Hit(damage);
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Hit(other.gameObject);
    }



}


