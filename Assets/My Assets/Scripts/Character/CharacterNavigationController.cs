using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

/// <summary>
/// Moves player to point clicked on a nav mesh
/// </summary>
/// Based on these videos:   https://youtu.be/CHV1ymlw-P8   &   https://youtu.be/LVu3_IVCzys
namespace GD.Controllers
{
    public class CharacterNavigationController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Main game camaera.")]
        private Camera cam;

        private NavMeshAgent player;
        private bool move;

        private InputManager input;

        private void Awake()
        {
            player = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
            input = InputManager.instance;

            InputManager.leftClickDown += StartFollowing;
            InputManager.leftClickUp += StopFollowing;
        }

        /// <summary>
        /// Runs while the player is holding left click, will move character to that position if on navmesh
        /// </summary>
        private void FixedUpdate()
        {
            if (move)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    player.SetDestination(hit.point);
                }
            }
        }

        /// <summary>
        /// Called when player left clicks, turns on movment
        /// </summary>
        public void StartFollowing()
        {
            move = true;
        }

        /// <summary>
        /// Called when player releases left click, turns off movment
        /// </summary>
        public void StopFollowing()
        {
            move = false;
        }
    }
}