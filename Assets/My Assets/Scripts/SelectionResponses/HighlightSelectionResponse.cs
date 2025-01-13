using GD.Events;
using GD.Items;
using UnityEngine;
using UnityEngine.AI;

namespace GD.Selection
{
    /// <summary>
    /// Changes the material of the selected object to a highlight material.
    /// </summary>
    public class HighlightSelectionResponse : SelectionResponse
    {
        #region Fields

        [SerializeField]
        private Material highlightMaterial;

        [SerializeField]
        [Tooltip("The event that is raised when an item is selected")]
        private SlotGameEvent onSelection;

        #endregion Fields

        #region Internal

        //store the original material of the selected object to allow for deselection
        private Material originalMaterial;

        private InputManager input;

        private bool hovering;

        private Transform current;

        #endregion Internal

        private void Start()
        {
            input = InputManager.instance;

            // add the interact function to the left click down delegate from the input manager
            InputManager.leftClickDown += Interact;

            hovering = false;
        }

        //Called when we select a NEW thing - transform is the ref to new thing
        public override void OnSelect(Transform currentTransform)
        {
            var obj = currentTransform.gameObject;
            // only run the code for selection, if the player is in range of the slot
            if (obj.GetComponent<Slot>().targetArea.inArea)
            {
                //get the renderer to access the material
                var renderer = currentTransform.GetComponent<Renderer>();

                //remember old material
                originalMaterial = renderer.material;
                //set to new material
                renderer.material = highlightMaterial;

                //store the current as previous for the next call to OnSelect
                base.OnSelect(currentTransform);

                current = currentTransform;

                hovering = true;
            }
        }

        //Called when we deselect something - transform is the old selected thing
        public override void OnDeselect(Transform currentTransform)
        {
            //get the renderer to access the material
            var renderer = currentTransform.GetComponent<Renderer>();

            //am i deselecting a valid renderer? did i record its original material?
            if (originalMaterial != null && renderer != null)
                renderer.material = originalMaterial;

            hovering = false;
        }

        /// <summary>
        /// Raises an event when an object is left clicked
        /// </summary>
        public void Interact()
        {
            // If the cursor is over an object and the player is in range trigger the selection event
            if(hovering)
            {
                onSelection?.Raise(current.GetComponent<Slot>());
            }
        }
    }
}