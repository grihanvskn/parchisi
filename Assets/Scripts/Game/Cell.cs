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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        AddPhysics2DRaycaster();
        board = FindAnyObjectByType<Board>();
        piece = FindAnyObjectByType<Piece>();
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
            piece.CurCell = gameObject;
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
