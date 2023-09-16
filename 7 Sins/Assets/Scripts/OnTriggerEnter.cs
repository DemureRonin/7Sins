using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnter : MonoBehaviour
{
    [SerializeField] private string _otherTag;
    [SerializeField] private UnityEvent _action;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_otherTag == collision.tag)
        {
            _action?.Invoke();
        }
    }
}

