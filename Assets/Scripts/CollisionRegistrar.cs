using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollisionRegistrar : MonoBehaviour
{
    public event Action<IInteractive> CollisionDetected;

    private void OnValidate()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractive interactive))
        {
            CollisionDetected?.Invoke(interactive);
        }
    }
}
