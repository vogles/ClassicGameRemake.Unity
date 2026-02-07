using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Vector2 _direction = Vector2.zero;
    public float _speed = 2.0f;
    private Rigidbody2D _rigidbody;

    public Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
    }

    public Vector2 Position
    {
        get => _rigidbody.position;
    }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if (_rigidbody != null)
        {
            //_rigidbody.MovePosition(Position + (_direction * _speed * Time.deltaTime));
            _rigidbody.linearVelocity = _direction * _speed;
        }
    }
}
