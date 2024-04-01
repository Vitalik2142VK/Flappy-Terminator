using UnityEngine;

public class PoolShell : MonoBehaviour 
{
    [SerializeField] private Transform _conteiner;
    [SerializeField] private Shell _prefab;

    private PoolObjcts<Shell> _pool;

    private void Start()
    {
        _pool = new PoolObjcts<Shell>(_conteiner, _prefab);
    }

    public Shell GetShell()
    {
        Shell shell = _pool.GetGameObject();
        shell.Hit += PutShell;

        return shell;
    }

    public void PutShell(Shell shell)
    {
        _pool.PutGameObject(shell);
        shell.Hit -= PutShell;
    }

    public void RemoveAll()
    {
        _pool.RemoveAll();
    }
}