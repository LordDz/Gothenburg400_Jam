using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets._Game.Scripts.UI
{
    public class InventoryMouseDetection : MonoBehaviour
     , IPointerEnterHandler
     , IPointerExitHandler
    {

        private MousePointer mousePointer;

        // Use this for initialization
        void Start()
        {
            mousePointer = FindObjectOfType<MousePointer>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            mousePointer.UIEnter();
            mousePointer.SetCursorImg(MouseImgType.Interact);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            mousePointer.UIExit();
            mousePointer.SetCursorImg(MouseImgType.Walk);
        }
    }
}
