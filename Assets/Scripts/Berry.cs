using UnityEngine;

public class Berry : MonoBehaviour
{
    public PlayerHealth PlayerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerMove>())
        {
            other.attachedRigidbody.GetComponent<PlayerScore>().Score += 1;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(transform.position.y < -5f)
        {
            PlayerHealth.HealthCount--;
            Destroy(gameObject);
        }
    }

}
