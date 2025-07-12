using UnityEngine;
using TMPro;

public class DiceRoller : MonoBehaviour
{
    //временное отражение кубика текстом
    public TMP_Text Die1;
    public TMP_Text Die2;
    public Board board;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //функция которая вызывается по нажатию кнопки roll
    public void Roll()
    {
        //бросаем кости и меняем текст
        int a = Random.Range(1, 7);
        int b = Random.Range(1, 7);

        board.a = a;
        board.b = b;

        Die1.text = a.ToString();
        Die2.text = b.ToString();
    }
}
