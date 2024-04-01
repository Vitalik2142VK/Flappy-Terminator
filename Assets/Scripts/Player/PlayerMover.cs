using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField, Min(0.5f)] private float _speed;
    [SerializeField, Min(0.5f)] private float _tapForce;
    [SerializeField, Min(0.5f)] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _stratPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Rigidbody2D _rigidbody;

    public bool IsActiveMove => _rigidbody.simulated;

    private void Start()
    {
        _stratPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_speed, _tapForce);

            transform.rotation = _maxRotation; ;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void StartMove()
    {
        _rigidbody.simulated = true;
    }

    public void DeactiveMove()
    {
        _rigidbody.simulated = false;
    }

    public void Reset()
    {
        transform.position = _stratPosition;
        transform.Rotate(Vector3.zero);
    }
}
