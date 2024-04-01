using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyShoting))]
public class Enemy : Character, IEnemy
{
    private readonly int Destroyed = Animator.StringToHash(nameof(Destroyed));

    public event Action<Enemy> Dead;

    private EnemyShoting _enemyShoting;
    private Animator _animator;

    private void Awake()
    {
        _enemyShoting = GetComponent<EnemyShoting>();
        _animator = GetComponent<Animator>();

        GetComponents();
    }

    private void Update()
    {
        if (enabled)
            _enemyShoting.Shot();
    }

    protected override void OnDetectedCollision(IInteractive interactive)
    {
        if (interactive is IPlayer || interactive is Shell)
        {
            _animator.SetTrigger(Destroyed);

            StartCoroutine(WaitRemove());
        }
        else
        {
            Dead?.Invoke(this);
        }
    }

    protected override IEnumerator WaitRemove()
    {
        yield return Wait;

        Dead?.Invoke(this);
    }
}
