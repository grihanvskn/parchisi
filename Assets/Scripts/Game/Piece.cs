using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Piece : MonoBehaviour, IPointerDownHandler
{
    public GameObject CurCell;
    public Board board;
    public int PlayerIndex;
    public GameHandler Handler;
    public bool Nested;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        AddPhysics2DRaycaster();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Handler.Turn % Handler.PlayerNumber == PlayerIndex && !Nested)
        {
            for (int i = 0; i < board.Cells.Length; i++)
            {
                board.Cells[i].GetComponent<Cell>().Imag.SetActive(false);
                board.Cells[i].GetComponent<Cell>().Selectable = false;
                board.Cells[i].GetComponent<Cell>().piece = this;
            }
            board.Cells[CurCell.GetComponent<Cell>().Index + Handler.a - 1].GetComponent<Cell>().Imag.SetActive(true);
            board.Cells[CurCell.GetComponent<Cell>().Index + Handler.a - 1].GetComponent<Cell>().Selectable = true;
            board.Cells[CurCell.GetComponent<Cell>().Index + Handler.b - 1].GetComponent<Cell>().Imag.SetActive(true);
            board.Cells[CurCell.GetComponent<Cell>().Index + Handler.b - 1].GetComponent<Cell>().Selectable = true;
            board.Cells[CurCell.GetComponent<Cell>().Index + Handler.a + Handler.b - 1].GetComponent<Cell>().Imag.SetActive(true);
            board.Cells[CurCell.GetComponent<Cell>().Index + Handler.a + Handler.b - 1].GetComponent<Cell>().Selectable = true;
        }
        else if (Nested && Handler.Turn % Handler.PlayerNumber == PlayerIndex && (Handler.a == 6 || Handler.b == 6))
        {
            for (int i = 0; i < board.Cells.Length; i++)
            {
                board.Cells[i].GetComponent<Cell>().Imag.SetActive(false);
                board.Cells[i].GetComponent<Cell>().Selectable = false;
                board.Cells[i].GetComponent<Cell>().piece = this;
            }
            CurCell.GetComponent<Nest>().FirstCell.GetComponent<Cell>().Imag.SetActive(true);
            CurCell.GetComponent<Nest>().FirstCell.GetComponent<Cell>().Selectable = true;
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
        transform.position = Vector3.Lerp(transform.position, CurCell.transform.position, 5 * Time.deltaTime);
    }
}
