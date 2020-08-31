using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _accelerateDuration;
    private PlayerMover _mover;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y);
        _mover.Move(direction);
    }

    public void Stop()
    {
        _mover.Stop();
    }

    public void Accelerate()
    {
        StartCoroutine(StartAccelerate(_accelerateDuration));
    }

    private IEnumerator StartAccelerate(float duration)
    {
        _mover.SpeedUp();
        while (duration > 0)
        {
            duration -= Time.deltaTime;
            yield return null;
        }
        _mover.SpeedDown();
    }
}
