using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerDownHandler
{

    public int Index;
    public GameObject Imag;
    public bool Selectable = false;
    public Board board;
    public Piece piece;
    public GameHandler Handler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        AddPhysics2DRaycaster();
        board = FindAnyObjectByType<Board>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Selectable)
        {
            for (int i = 0; i < board.Cells.Length; i++)
            {
                board.Cells[i].GetComponent<Cell>().Imag.SetActive(false);
                board.Cells[i].GetComponent<Cell>().Selectable = false;
            }
            if (Handler.a == Index - piece.CurCell.GetComponent<Cell>().Index)
            {
                Handler.a = 0;
            }
            else if (Handler.b == Index - piece.CurCell.GetComponent<Cell>().Index)
            {
                Handler.b = 0;
            }
            else if (Handler.b + Handler.a == Index - piece.CurCell.GetComponent<Cell>().Index)
            {
                Handler.a = 0;
                Handler.b = 0;
            }
            piece.CurCell = gameObject;
            if (piece.Nested)
            {
                if (Handler.a > Handler.b)
                {
                    Handler.a = 0;
                }
                else
                {
                    Handler.b = 0;
                }
                piece.Nested = false;
            }
        }
    }
    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
