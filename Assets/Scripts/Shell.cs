using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Shell : MonoBehaviour, IInteractive
{
    public event Action<Shell> Hit;

    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IInteractive _))
        {
            Hit?.Invoke(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractive _))
        {
            Hit?.Invoke(this);
        }
    }
}
