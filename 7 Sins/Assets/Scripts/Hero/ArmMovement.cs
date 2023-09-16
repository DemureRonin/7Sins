using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    void Update()
    {
        RotateArm();
    }
    private void RotateArm()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePosition - transform.position;

        float zRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;  

        transform.rotation = Quaternion.Euler(0, 0, zRotation );

        if (transform.rotation.z == Mathf.Clamp(transform.rotation.z,-0.9f, -0.8f) || transform.rotation.z == Mathf.Clamp(transform.rotation.z, 0.8f, 0.9f))
        {
            _sprite.transform.localScale = new Vector3(-1,1,0);
            transform.localScale = new Vector3(-1,-1,0);
        }

        else if (transform.rotation.z == Mathf.Clamp(transform.rotation.z, -0.7f, 0.7f))
        {
            transform.localScale = new Vector3(1, 1, 0);

            _sprite.transform.localScale = new Vector3(1, 1, 0);
        }
    }
}
