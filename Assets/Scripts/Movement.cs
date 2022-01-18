using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    [SerializeField] private bool _isPlayer;
    private Vector2 _velocity = new Vector2(0, 0);
    private Vector2 _destination;
    private float _speed = 10;
    private float _step = 1.8f;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (!_isPlayer)
        {
            System.Random rand = new System.Random(Guid.NewGuid().GetHashCode());
            float x = rand.Next(-1, 2);
            float y = rand.Next(-1, 2);

            if (x < 0)
            {
                MoveLeft();
            }
            else if (x > 0)
            {
                MoveRight();
            }
            else if (y > 0)
            {
                MoveUp();
            }
            else if (y < 0)
            {
                MoveDown();
            }
        }

    }
    
    private void FixedUpdate()
    {
        CheckPosition();
    }

    private void CheckPosition()
    {
        if ((_velocity.x > 0 && !(transform.position.x > _destination.x)) || (_velocity.x < 0 && !(transform.position.x < _destination.x)))
        {
            Shift();
        }
        else if ((_velocity.y > 0 && !(transform.position.y > _destination.y)) || (_velocity.y < 0 && !(transform.position.y < _destination.y)))
        {
            Shift();
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    private void Shift()
    {
        _rigidbody.AddForce(_velocity);
    }
    
    
    public void MoveUp()
    {
        _velocity = new Vector2(0, _speed);
        _destination = new Vector2(0, transform.position.y + _step);
        ResetAnimator();
        _animator.SetBool("Up", true);
    }

    public void MoveDown()
    {
        _velocity = new Vector2(0, -_speed);
        _destination = new Vector2(0, transform.position.y - _step);
        ResetAnimator();
        _animator.SetBool("Down", true);
    }

    public void MoveLeft()
    {
        _velocity = new Vector2(-_speed, 0);
        _destination = new Vector2(transform.position.x - _step, 0);
        ResetAnimator();
        _animator.SetBool("Left", true);
    }

    public void MoveRight()
    {
        _velocity = new Vector2(_speed, 0);
        _destination = new Vector2(transform.position.x + _step, 0);
        ResetAnimator();
        _animator.SetBool("Right", true);
    }
    
    private void ResetAnimator()
    {
        _animator.SetBool("Left", false);
        _animator.SetBool("Right", false);
        _animator.SetBool("Up", false);
        _animator.SetBool("Down", false);
    }

   
    

   
}