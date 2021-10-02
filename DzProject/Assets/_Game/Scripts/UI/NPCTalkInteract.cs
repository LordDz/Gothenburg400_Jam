using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets._Game.Scripts.UI
{
    public class NPCTalkInteract : MonoBehaviour, IPointerEnterHandler
     , IPointerExitHandler
    {
        MousePointer mousePointer;
        // Use this for initialization
        void Start()
        {
            mousePointer = FindObjectOfType<MousePointer>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            mousePointer.SetCursorImg(MouseImgType.Talk);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            mousePointer.SetCursorImg(MouseImgType.Walk);
        }
    }
}
