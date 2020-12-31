using System;
using System.Collections;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private const int _speed = 3;
    private readonly Vector3 _originalPosition = Vector3.zero;
    private bool _isTween;

    private void Update()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            0).normalized * (_speed * Time.deltaTime);
        if (!_isTween)
        {
            MoveCube(movement);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isTween)
        {
            StartCoroutine(ResetPosition(() => { _isTween = false; }));
        }
    }

    private void MoveCube(Vector3 vec)
    {
        transform.Translate(vec);
    }

    private IEnumerator ResetPosition(Action callback)
    {
        _isTween = true;
        Debug.Log("Start Tween");
        yield return StartCoroutine(TweenToOrigin());
        Debug.Log("ResetComplete");
        callback();
    }

    private IEnumerator TweenToOrigin()
    {
        while ((_originalPosition - transform.position).magnitude > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, _originalPosition, Time.deltaTime * _speed);
            yield return null;
        }

        yield return null;
    }
}