using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerShoting))]
[RequireComponent(typeof(Animator))]
public class Player : Character, IPlayer
{
    private readonly int Destroyed = Animator.StringToHash(nameof(Destroyed));

    public event Action GameOver;

    private PlayerMover _playerMover;
    private PlayerShoting _playerShoting;
    private Animator _animator;
    private Vector2 _startPosition;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerShoting = GetComponent<PlayerShoting>();
        _animator = GetComponent<Animator>();
        _startPosition = transform.position;

        GetComponents();
    }

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if (_playerMover.IsActiveMove)
        {
            _playerMover.Move();

            if (Input.GetKey(KeyCode.F))
                _playerShoting.Shot(transform.rotation.eulerAngles.z);
        }
    }

    public void Activation()
    {
        gameObject.SetActive(true);
        transform.position = _startPosition;

        _playerMover.StartMove();
    }

    protected override void OnDetectedCollision(IInteractive interactive)
    {
        if (interactive is not IPlayer)
        {
            _animator.SetTrigger(Destroyed);
            _playerMover.DeactiveMove();
            _playerShoting.RemoveAllShell();

            StartCoroutine(WaitRemove());
        }
    }

    protected override IEnumerator WaitRemove()
    {
        yield return Wait;

        GameOver?.Invoke();

        gameObject.SetActive(false);
    }
}
