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

        /// <summary>
        /// swap animation states
        /// </summary>
        void Update()
        {
            // Idle animation with no movement
            if (player.velocity == Vector3.zero)
            {
                animator.Play("Idle");
            }
            // walk animation when moving
            else
            {
                animator.Play("Walk");
                TurnCharacter();
            }
        }

        /// <summary>
        /// Face character where they are going
        /// </summary>
        void TurnCharacter()
        {
            // get a direction between the player and its destination
            Vector3 direction = (player.destination - transform.position).normalized;
            // calculate a rotation between the current direction and the one just calculated
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            // slerp to gradually turn the character towards their new direction, using the turning speed variable
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turningSpeed);
        }
    }
}
