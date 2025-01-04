using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

/// Based on this video:   https://youtu.be/LVu3_IVCzys
namespace GD.Controllers
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("How fst the player model turns.")]
        private float turningSpeed;

        private NavMeshAgent player;
        private Animator animator;

        private void Awake()
        {
            player = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (player.velocity == Vector3.zero)
            {
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Walk");
                TurnCharacter();
            }
        }

        void TurnCharacter()
        {
            Vector3 direction = (player.destination - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turningSpeed);
        }
    }
}
