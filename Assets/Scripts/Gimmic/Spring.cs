using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour, IGain
{
    [SerializeField] private float _spForce = 15.0f;
    public float JumpForce()
    {
        return _spForce;
    }
}
