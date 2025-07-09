using UnityEngine;
using TMPro;

public class DiceRoller : MonoBehaviour
{
    //временное отражение кубика текстом
    public TMP_Text Die1;
    public TMP_Text Die2;
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

        Die1.text = a.ToString();
        Die2.text = b.ToString();
    }
}
