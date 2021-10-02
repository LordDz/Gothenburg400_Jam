using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets._Game.Scripts.UI
{
    public class NPCTalkInteract : MonoBehaviour, IPointerEnterHandler
     , IPointerExitHandler
    {
        MousePointer mousePointer;
        private bool CanInteract = true;

        public MouseImgType ImgType = MouseImgType.Talk;

        // Use this for initialization
        void Start()
        {
            mousePointer = FindObjectOfType<MousePointer>();
        }

        public void SetHasTalked()
        {
            CanInteract = false;
            mousePointer.SetCursorImg(MouseImgType.Walk);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (CanInteract)
            {
                mousePointer.SetCursorImg(ImgType);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (CanInteract)
            {
                mousePointer.SetCursorImg(MouseImgType.Walk);
            }
        }
    }
}
