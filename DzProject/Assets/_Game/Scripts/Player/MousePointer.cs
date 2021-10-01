using RPGM.Gameplay;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D CursorTexture;
    public AudioSource AudioClick;

    public Transform MouseClickImg;
    public CharacterController2D Player;

    public void Start()
    {
        Cursor.SetCursor(CursorTexture, Vector2.zero, CursorMode.Auto);
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
        AudioClick.Play();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        MouseClickImg.position = mousePos;
        Player.GoToPosition(mousePos);
    }

}
