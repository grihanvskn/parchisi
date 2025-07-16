using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    //временное отражение кубика текстом
    public TMP_Text Die1;
    public TMP_Text Die2;
    public Board board;
    public int Turn = -1;
    public int PlayerNumber;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //функция которая вызывается по нажатию кнопки roll
    public int a, b;
    public void Roll()
    {
        if (a == 0 && b == 0)
        {
            Turn++;
            //бросаем кости и меняем текст
            a = Random.Range(1, 7);
            b = Random.Range(1, 7);

            board.a = a;
            board.b = b;

            Die1.text = a.ToString();
            Die2.text = b.ToString();
        }
    }
}
