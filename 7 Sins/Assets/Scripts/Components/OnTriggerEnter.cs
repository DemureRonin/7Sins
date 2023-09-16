using System;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnter : MonoBehaviour
{
    [SerializeField] private Actions[] _actions;
    

    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
        foreach (var action in _actions)
        {
            if (action.otherTag == otherCollision.tag)
            {
                action.gameEvent.Invoke(otherCollision.gameObject);
                Debug.Log("Collision");
                return;
            }
        }
        
    }

}
[Serializable]
public class Actions
{
    [SerializeField] private string _otherTag;
    public string otherTag => _otherTag;

    [SerializeField] private EnterEvent _gameEvent;

    public EnterEvent gameEvent => _gameEvent;

    
}

