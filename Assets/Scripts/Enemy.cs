using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _speed = 2f;
    
    private Vector3 _direction = Vector3.right;

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position += _direction.normalized * _speed * Time.deltaTime;
    }
}
