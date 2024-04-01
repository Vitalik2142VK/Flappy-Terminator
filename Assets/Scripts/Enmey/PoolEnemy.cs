using UnityEngine;

public class PoolEnemy : MonoBehaviour
{
    [SerializeField] private Transform _conteiner;
    [SerializeField] private Enemy _prefab;

    private PoolObjcts<Enemy> _pool;

    private void Start()
    {
        _pool = new PoolObjcts<Enemy>(_conteiner, _prefab);
    }

    public Enemy GetEnemy()
    {
        Enemy enemy = _pool.GetGameObject();
        enemy.Dead += PutEnemy;

        return enemy;
    }

    public void PutEnemy(Enemy enemy)
    {
        _pool.PutGameObject(enemy);
        enemy.Dead -= PutEnemy;
    }

    public void DeactiveAll()
    {
        _pool.DeactiveAll();
    }
}
