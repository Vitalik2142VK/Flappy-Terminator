using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ground : MonoBehaviour, IInteractive
{
    private readonly int IsMove = Animator.StringToHash(nameof(IsMove));

    private Animator _animator;
    private bool _isMove = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move()
    {
        _isMove = true;

        ChangeAnimation();
    }

    public void Stop()
    {
        _isMove = false;

        ChangeAnimation();
    }

    private void ChangeAnimation()
    {
        _animator.SetBool(IsMove, _isMove);
    }
}
