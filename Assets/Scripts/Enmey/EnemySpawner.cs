using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PoolEnemy _poolEnemy;
    [SerializeField] private PoolShell _poolShellEnemy;
    [SerializeField, Min(0.3f)] private float _maxDelay;
    [SerializeField, Min(0.3f)] private float _minDelay;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private Timer _timer;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        _timer = new Timer(_maxDelay);
    }

    private void Update()
    {
        if (enabled)
        {
            if (_timer.IsTimeUp) 
            {
                SpawnEnemy();
                UpdateTimer();                
            }
            else
            {
                _timer.MakeCountdown();
            }
        }
    }

    public void ReturnAll()
    {
        _poolEnemy.DeactiveAll();
        _poolShellEnemy.DeactiveAll();
    }

    private void SpawnEnemy()
    {
        float positionY = Random.Range(_minHeight, _maxHeight);
        Vector2 spawnPoint = new Vector2(transform.position.x, positionY);

        Enemy enemy = _poolEnemy.GetEnemy();
        enemy.GetComponent<EnemyShoting>().SetPoolShell(_poolShellEnemy);
        enemy.transform.position = spawnPoint;
        enemy.gameObject.SetActive(true);
    }

    private void UpdateTimer()
    {
        if (_minDelay == _maxDelay)
            _timer.SetWaitTime(_maxDelay);
        else
            _timer.SetRandomWaitTime(_minDelay, _maxDelay);

        _timer.UpdateWaitingTime();
    }
}
