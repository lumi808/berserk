using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Walk()
    {
        _animator.SetBool("Walk", true);
    }

    public void Stop()
    {
        _animator.SetBool("Walk", false);
    }

    public void Slash()
    {
        _animator.SetTrigger("Slash");
    }  

    public void Kick()
    {
        _animator.SetTrigger("Kick");
    }
}
