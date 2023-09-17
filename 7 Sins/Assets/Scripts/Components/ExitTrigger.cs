using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : EnterTrigger
{
    private void OnTriggerExit2D(Collider2D otherCollision)
    {
        foreach (var action in _actions)
        {
            if (action.otherTag == otherCollision.tag)
            {
                action.gameEvent.Invoke(otherCollision.gameObject);
                Debug.Log("CollisionExit");
                return;
            }
        }
    }
}
