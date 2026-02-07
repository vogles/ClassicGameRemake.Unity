using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public enum WallBehavior
    {
        Reflect,
        Destroy
    }

    public enum WallSide
    {
        Left,
        Right
    }

    [SerializeField] private WallBehavior _behaviour = WallBehavior.Reflect;
    [SerializeField] private Vector2 _reflectionVector;

    public Vector2 ReflectionVector 
    {
        get => _reflectionVector;
        set => _reflectionVector = value;
    }

    public void HandleBallCollision(Ball ball)
    {
        if (_behaviour == WallBehavior.Reflect)
        {
            var currentBallDirection = ball.Direction;
            currentBallDirection *= ReflectionVector;

            ball.Direction = currentBallDirection;
        }
        else
        {

        }
    }
}
