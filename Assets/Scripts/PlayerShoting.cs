using UnityEngine;

public class PlayerShoting : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private PoolShell _pool;
    [SerializeField, Min(100.0f)] private float _speedShell;
    [SerializeField, Min(0.25f)] private float _timeBetweenShost;

    private Timer _timer;

    private void Start()
    {
        _timer = new Timer(_timeBetweenShost);
        _timer.UpdateWaitingTime();
    }

    private void Update()
    {
        _timer.MakeCountdown();
    }

    public void Shot(float rotationZ)
    {
        if (_timer.IsTimeUp) 
        {
            Vector2 targetPoint = Quaternion.AngleAxis(rotationZ, Vector3.forward) * Vector2.right;

            Shell shell = _pool.GetShell();
            shell.gameObject.SetActive(true);
            shell.transform.position = _shotPoint.transform.position;
            shell.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            shell.Rigidbody.AddForce(_speedShell * targetPoint);

            _timer.UpdateWaitingTime();
        }
    }

    public void RemoveAllShell()
    {
        _pool.DeactiveAll();
    }
}
