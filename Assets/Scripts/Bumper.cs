using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class Bumper : MonoBehaviour
{
    [SerializeField] float power = 1f;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach(var contact in collision.contacts)
        {
            var force = -1 * contact.normal * power;

            contact.otherCollider.attachedRigidbody.AddForce(force, ForceMode.Impulse);
        }

        if(_animator != null)
        {
            _animator.SetTrigger("activate");
        }

        ScoreManager.instance.AddScore(1000);
    }
}
