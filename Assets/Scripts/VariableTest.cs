using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class VariableTest : MonoBehaviour
    {
        private int _score;

        private void Start()
        {
            _score = 100;
            Debug.Log(_score.ToString());
        }
    }
}