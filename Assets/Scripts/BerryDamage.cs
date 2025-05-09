using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerMove>())
        {
            other.attachedRigidbody.GetComponent<PlayerHealth>().HealthCount -= 1;
            Destroy(gameObject);

        }
    }

    private void Update()
    {
        DestroyBerryDamage();
    }

    private void DestroyBerryDamage()
    {
        if(transform.position.y < -4.5f)
        {
            Destroy(gameObject);
        }
    }
}
