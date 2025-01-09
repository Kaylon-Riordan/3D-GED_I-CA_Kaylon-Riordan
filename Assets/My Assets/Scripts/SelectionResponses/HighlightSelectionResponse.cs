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
        private GameEvent onSelection;

        #endregion Fields

        #region Internal

        //store the original material of the selected object to allow for deselection
        private Material originalMaterial;

        private InputManager input;

        private bool hovering;

        #endregion Internal

        private void Start()
        {
            input = InputManager.instance;

            InputManager.leftClickDown += Interact;

            hovering = false;
        }

        //Called when we select a NEW thing - transform is the ref to new thing
        public override void OnSelect(Transform currentTransform)
        {
            var obj = currentTransform.gameObject;
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

        public void Interact()
        {
            if(hovering)
            {
                onSelection?.Raise();
            }
        }
    }
}