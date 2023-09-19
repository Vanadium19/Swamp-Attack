using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorData : MonoBehaviour
{
    public static class Params
    {
        public static readonly int DeathParamHash = Animator.StringToHash("Death");
        public static readonly int AttackParamHash = Animator.StringToHash("Attack");
    }

    public static class States
    {
        public static readonly int IdleStateHash = Animator.StringToHash("Idle");
        public static readonly int AttackStateHash = Animator.StringToHash("Attack");
        public static readonly int CelebrationStateHash = Animator.StringToHash("Celebration");
    }
}
