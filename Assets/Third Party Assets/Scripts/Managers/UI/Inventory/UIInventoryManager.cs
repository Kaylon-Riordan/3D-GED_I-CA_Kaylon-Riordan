using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using GD.Items;
using GD.Audio;
using GD.Types;

namespace GD.UI
{
    public class UIInventoryManager : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        [Tooltip("Title of the inventory panel")]
        [TextArea(2, 4)]
        private string description;

        [SerializeField]
        [Tooltip("Inventory to display for this ui panel")]
        private Inventory inventory;

        [SerializeField]
        [Tooltip("Panel to display inventory items in")]
        private Transform itemUIPanel;

        [SerializeField]
        [Tooltip("Prefab for inventory item UI")]
        private GameObject itemUIPrefab;

        [SerializeField]
        [Tooltip("Sound played when item is slotted")]
        private AudioClip slotSound;

        [HideInInspector]
        public Slot currentSlot;

        #endregion Fields

        #region Fields - Internal

        private Dictionary<ItemData, GameObject> itemUIDictionary = new Dictionary<ItemData, GameObject>();

        #endregion Fields - Internal

        #region Methods

        private void Start()
        {
            if (inventory == null)
                throw new System.Exception("Inventory is not set in UIInventoryManager");
            if (itemUIPanel == null)
                throw new System.Exception("ItemUIPanel is not set in UIInventoryManager");
            if (itemUIPrefab == null)
                throw new System.Exception("ItemUIPrefab is not set in UIInventoryManager");

            InitializeUI();
        }

        private void InitializeUI()
        {
            foreach (var itemEntry in inventory)
            {
               CreateOrUpdate(itemEntry.Key, itemEntry.Value);
            }
        }

        private void CreateOrUpdate(ItemData itemData, int count)
        {
            if (!itemUIDictionary.TryGetValue(itemData, out var itemUI))
            {
                itemUI = Instantiate(itemUIPrefab, itemUIPanel);
                itemUI.SetActive(true);
                itemUI.GetComponentInChildren<Image>().sprite = itemData.UiIcon;
                itemUIDictionary[itemData] = itemUI;
            }

            var button = itemUI.GetComponentInChildren<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => this.OnButtonPressed(itemData));

            var countText = itemUI.GetComponentInChildren<TextMeshProUGUI>();
            countText.text = count.ToString();
        }

        /// <summary>
        /// Called when the inventory changes
        /// </summary>
        public void OnInventoryChange()
        {
            foreach (var itemEntry in inventory)
            {
                CreateOrUpdate(itemEntry.Key, itemEntry.Value);
            }
        }

        public void SetSlot(Slot newSlot)
        {
            this.currentSlot = newSlot;
            OnInventoryChange();
        }

        public void OnButtonPressed(ItemData data)
        {
            AudioManager.Instance.PlaySound(slotSound, AudioMixerGroupName.SFX, currentSlot.transform.position);

            if (this.currentSlot.slotedItem != null)
            {
                inventory.Add(this.currentSlot.slotedItem, 1);
                CreateOrUpdate(this.currentSlot.slotedItem, 1);
            }

            this.currentSlot.SlotItem(data);
            this.inventory.Remove(data, 1);

            if (itemUIDictionary.TryGetValue(data, out var itemUI))
            {
                Destroy(itemUI);
                itemUIDictionary.Remove(data);
            }

            OnInventoryChange();

            currentSlot.setModel(data.prefab);
        }

        #endregion Methods
    }
}