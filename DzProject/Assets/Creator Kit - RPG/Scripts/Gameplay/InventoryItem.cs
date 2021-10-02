using RPGM.Core;
using RPGM.Gameplay;
using RPGM.UI;
using UnityEngine;
using static UnityEngine.UI.Button;

namespace RPGM.Gameplay
{
    /// <summary>
    /// Marks a gameObject as a collectable item.
    /// </summary>
    [ExecuteInEditMode]
    [RequireComponent(typeof(SpriteRenderer))]
    public class InventoryItem : MonoBehaviour
    {
        public int count = 1;
        public Sprite sprite;
        public ButtonClickedEvent OnClick;
        public NPCController InteractTalker;

        GameModel model = Schedule.GetModel<GameModel>();

        public void PickupItem()
        {
            MessageBar.Show($"Picked up: {name} x {count}");
            model.AddInventoryItem(this);
            UserInterfaceAudio.OnCollect();
            gameObject.SetActive(false);
        }
    }
}
