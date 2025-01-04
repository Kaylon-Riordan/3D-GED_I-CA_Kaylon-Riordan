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
        private PlayerInputActions inputs;
        private InputAction leftClick;

        private void Awake()
        {
            player = GetComponent<NavMeshAgent>();
            inputs = new PlayerInputActions();
        }
        private void OnEnable()
        {
            leftClick = inputs.Player.LeftClick;
            leftClick.Enable();
            leftClick.performed += LeftClick;
        }
        private void OnDisable()
        {
            leftClick.performed -= LeftClick;
            leftClick.Disable();
        }

        /// <summary>
        /// Called when player left clicks, will move character to that position if on navmesh
        /// </summary>
        /// <param name="context"> Informs when the left click input is activated </param>
        public void LeftClick(InputAction.CallbackContext context)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                player.SetDestination(hit.point);
            }
        }
    }
}