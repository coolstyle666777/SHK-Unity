using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _motionRadius;
    private Vector3 _targetPosition;

    public event UnityAction Killed;

    private void Start()
    {
        _targetPosition = SetRandomPosition();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (transform.position == _targetPosition)
        {
            _targetPosition = SetRandomPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
            Killed?.Invoke();
            player.Accelerate();
            gameObject.SetActive(false);
        }
    }

    private Vector3 SetRandomPosition()
    {
        return Random.insideUnitCircle * _motionRadius;
    }
}
