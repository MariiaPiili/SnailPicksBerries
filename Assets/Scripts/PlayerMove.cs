using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float SpeedMove;
    public float MaxSpeedMove;   

    public Vector3 _velocity;

    private Rigidbody _rigidbody;
    private float _horizont;
    private float _boostSpeed = 2.5f;


    public GameObject PlayerImage;    

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        _horizont = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(Mathf.Clamp(_rigidbody.velocity.x, -MaxSpeedMove, MaxSpeedMove), _rigidbody.velocity.y, _rigidbody.velocity.z);
        _rigidbody.AddRelativeForce(-Vector3.right * SpeedMove * _horizont);

        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(-Vector3.right * SpeedMove * _horizont*_boostSpeed);
        }

            if (_horizont < 0)
        {
            PlayerImage.transform.eulerAngles = Vector3.up * 180f;
        }
        else if(_horizont > 0) 
        {
            PlayerImage.transform.eulerAngles = Vector3.up * 0;
        }
        _velocity = _rigidbody.velocity;

        if (transform.position.x > 12.5f)
        {
            transform.position = new Vector3(-12.5f, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -12.5f)
        {
            transform.position = new Vector3(12.5f, transform.position.y, transform.position.z);
        }
    }
}
