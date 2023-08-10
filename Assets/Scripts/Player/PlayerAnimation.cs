using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // AnimationController�Q��
    [SerializeField] private Animator anim;

    // �ړ����Ă��Ȃ����̃A�j���[�V��������
    public void SetStop()
    {
        anim.SetFloat("MoveX", 0f);
    }

    // �ړ����̃A�j���[�V��������
    public void SetMove()
    {
        anim.SetFloat("MoveX", 1f);
    }
}
