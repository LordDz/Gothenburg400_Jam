using RPGM.Gameplay;
using UnityEngine;


public enum MouseImgType
{
    Interact,
    Walk,
    Talk
}

public class MousePointer : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D CursorInteract;
    public Texture2D CursorWalk;
    public Texture2D CursorTalk;
    public AudioSource AudioClick;

    public Transform MouseClickImg;
    public CharacterController2D Player;

    private bool isInUI = false;

    public void Start()
    {
        Cursor.SetCursor(CursorWalk, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick();
        }
    }

    private void MouseClick()
    {
        if (isInUI)
        {
            return;
        }
        AudioClick.Play();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        MouseClickImg.position = mousePos;
        Player.GoToPosition(mousePos);
    }

    public void UIEnter()
    {
        isInUI = true;
    }

    public void UIExit()
    {
        isInUI = false;
    }

    public void SetCursorImg(MouseImgType mouseImgType)
    {
        switch (mouseImgType)
        {
            case MouseImgType.Interact:
                Cursor.SetCursor(CursorInteract, Vector2.zero, CursorMode.Auto);
                break;
            case MouseImgType.Walk:
                Cursor.SetCursor(CursorWalk, Vector2.zero, CursorMode.Auto);
                break;
            case MouseImgType.Talk:
                Cursor.SetCursor(CursorTalk, Vector2.zero, CursorMode.Auto);
                break;

        }
    }

}
