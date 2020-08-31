using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _accelerateMultiplier;

    public void SpeedUp()
    {
        _speed *= _accelerateMultiplier;
    }

    public void SpeedDown()
    {
        _speed /= _accelerateMultiplier;
    }

    public void Stop()
    {
        _speed = 0;
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * _speed * Time.fixedDeltaTime);
    }
}
