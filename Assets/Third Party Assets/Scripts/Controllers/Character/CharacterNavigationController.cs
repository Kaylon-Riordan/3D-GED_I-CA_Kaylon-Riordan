using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

/// <summary>
/// Moves player to pount clicked on a nav mesh
/// </summary>
/// Based on this video:   https://youtu.be/CHV1ymlw-P8
namespace GD.Controllers
{
    public class CharacterNavigationController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Main game camaera.")]
        private Camera cam;

        [SerializeField]
        [Tooltip("Player character game object.")]
        private NavMeshAgent player;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
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
        /// Called when player selects a destination point on the navmesh
        /// </summary>
        /// <param name="context"></param>
        //public void Click(InputAction.CallbackContext context)
        //{
        //    //if a player is selected then determine destination
        //    if (isSelected)
        //        ClickDestination();
        //}
    }
}