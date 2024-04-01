using UnityEngine;

public class EnemyShoting : MonoBehaviour 
{
    private const float RotationY = 180;

    [SerializeField] private float _xOffsetShotPoint;
    [SerializeField, Min(50.0f)] private float _speedShell = 50;
    [SerializeField, Min(3.0f)] private float _maxTimeShost;
    [SerializeField, Min(1.0f)] private float _minTimeShost;

    private PoolShell _pool;
    private Timer _timer;

    private void Start()
    {
        _timer = new Timer(_maxTimeShost);
        _timer.UpdateWaitingTime();
    }

    private void Update()
    {
        _timer.MakeCountdown();
    }

    public void Shot()
    {
        if (_timer.IsTimeUp)
        {
            Vector2 shootPoint = new Vector2(transform.position.x + _xOffsetShotPoint, transform.position.y);

            Shell shell = _pool.GetShell();
            shell.gameObject.SetActive(true);
            shell.transform.position = shootPoint;
            shell.transform.rotation = Quaternion.Euler(0, RotationY, 0);
            shell.Rigidbody.AddForce(_speedShell * Vector2.left);

            _timer.SetRandomWaitTime(_minTimeShost, _maxTimeShost);
            _timer.UpdateWaitingTime();
        }
    }

    public void SetPoolShell(PoolShell pool)
    {
        _pool = pool;
    }
}
