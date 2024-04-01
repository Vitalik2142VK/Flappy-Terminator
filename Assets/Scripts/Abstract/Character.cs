using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CollisionRegistrar))]
public abstract class Character : MonoBehaviour
{
    private const float _waitTime = 0.5f;

    private readonly int Destroyed = Animator.StringToHash(nameof(Destroyed));

    private CollisionRegistrar _collision;

    protected WaitForSeconds Wait {  get; } = new WaitForSeconds(_waitTime);

    private void OnEnable()
    {
        _collision.CollisionDetected += OnDetectedCollision;
    }

    private void OnDisable()
    {
        _collision.CollisionDetected -= OnDetectedCollision;
    }

    protected void GetComponents()
    {
        _collision = GetComponent<CollisionRegistrar>();
    }

    protected abstract void OnDetectedCollision(IInteractive interactive);

    protected abstract IEnumerator WaitRemove();
}
