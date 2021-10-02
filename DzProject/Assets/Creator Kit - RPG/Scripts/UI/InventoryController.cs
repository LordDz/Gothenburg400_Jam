using System.Collections;
using System.Collections.Generic;
using RPGM.Core;
using RPGM.Gameplay;
using RPGM.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPGM.UI
{
    public class InventoryController : MonoBehaviour
    {
        public Transform elementPrototype;
        public float stepSize = 1;

        Vector2 firstItem;
        GameModel model = Schedule.GetModel<GameModel>();
        SpriteUIElement sizer;

        void Start()
        {
            firstItem = elementPrototype.localPosition;
            elementPrototype.gameObject.SetActive(false);
            sizer = GetComponent<SpriteUIElement>();
            Refresh();
        }

        // Update is called once per frame
        public void Refresh()
        {
            var cursor = firstItem;
            for (var i = 1; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
            var displayCount = 0;
            foreach (var i in model.InventoryItems)
            {
                var count = model.GetInventoryCount(i);
                if (count <= 0) continue;
                displayCount++;
                var e = Instantiate(elementPrototype);
                e.transform.parent = transform;
                e.transform.localPosition = cursor;
                var child0 = e.transform.GetChild(0);
                var child0Img = child0.GetComponent<Image>();
                var item = model.GetInventoryItem(i);
                child0Img.sprite = model.GetInventorySprite(i);
                child0.GetComponent<Button>().onClick = item.OnClick;

                e.gameObject.SetActive(true);
                cursor.x += stepSize;
            }

            //if (displayCount > 0)
            //    sizer.Show();
            //else
            //    sizer.Hide();
        }
    }
}
