using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _threshhold = 0.1f;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>(); 
    }
    public bool IsGrounded()
    {
        RaycastHit2D boxcast = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size * 1,0f,Vector2.down,  _threshhold, _layer);
        if (boxcast.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }  
    }
}
