using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SecondaryEnemytypeTwoLifeCircle : MonoBehaviour
{
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _animationClip;
    [SerializeField] private Transform _laserRay;

    private GameObject _player;
    private Coroutine _shoot;
    private Vector3 _direction;
    private Quaternion _toRotation;
    private float _observationTime = 3.5f;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _endPosition = new Vector3() { x = Random.Range(-1.5f, 1.5f), y = Random.Range(1, 0), z = 0 };
        _direction = (_endPosition - transform.position).normalized;
        _toRotation = Quaternion.LookRotation(Vector3.forward, _direction);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _endPosition, _speed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _toRotation, 300* Time.deltaTime);

        if (transform.position == _endPosition && _observationTime > 0)
        {
            _observationTime -= Time.deltaTime;

            if (_observationTime > 0 && _laserRay.localScale.x == 0)
            {
                _direction = (_player.transform.position - transform.position).normalized;
                _toRotation = Quaternion.LookRotation(Vector3.forward, _direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _toRotation, 300 * Time.deltaTime);
            }
            if(_observationTime < 0)
            {
                _shoot = StartCoroutine(Shoot());
            }
        }
    }

    private IEnumerator Shoot()
    {
        float delay = _animationClip.length;
        _animator.SetTrigger("IncreaseScaleTrigger");

        while(delay >= 0)
        {
            delay -= Time.deltaTime;
            yield return null;
        }

        StopCoroutine(_shoot);
        _observationTime = 3.5f;
    }
}
