using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _speedIncrement = 0.05f;
    //[SerializeField] private float _contactDistance = 0.05f;
    [SerializeField] private ContactFilter2D _contactFilter;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction = Vector2.zero;
    private GameController _gameController = null;

    public Vector2 Direction 
    {
        get => _direction;
        set => _direction = value;
    }

    public Vector2 Position
    {
        get => _rigidbody.position;
        set => _rigidbody.position = value;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameController = Object.FindAnyObjectByType<GameController>();
    }

    private void FixedUpdate()
    {
        var amountToMoveBy = _speed * Time.fixedDeltaTime;
        List<RaycastHit2D> hitResults = new List<RaycastHit2D>();
        int hitCount = _rigidbody.Cast(_direction, _contactFilter, hitResults, amountToMoveBy);

        if (hitCount > 0)
        {
            foreach (var hitResult in hitResults)
            {
                var hitResultTag = hitResult.collider.tag;
                if (hitResultTag == "Environment")
                {
                    ReflectY();
                }
                else if (hitResultTag == "Player")
                {
                    ReflectX();
                }
                else if (hitResultTag == "Respawn")
                {
                    if (hitResult.collider.name == "LeftBoundary")
                    {
                        _gameController.ChangeState(GameController.GameState.LeftWon);
                    }
                    else
                    {
                        _gameController.ChangeState(GameController.GameState.RightWon);
                    }
                }
            }
        }
  
        _rigidbody.MovePosition(_rigidbody.position + (amountToMoveBy * _direction));
    }

    public void ReflectY()
    {
        _direction.y *= -1;
    }

    public void ReflectX()
    {
        _direction.x *= -1;

        _speed = Mathf.Min(_speed + _speedIncrement, _maxSpeed);
    }
}
