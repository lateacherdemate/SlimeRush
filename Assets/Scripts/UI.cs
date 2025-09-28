using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text Mango_Text;
    public TMP_Text Dragonfruit_Text;
    public TMP_Text Death_Text;

    public int mangos = 0;
    public int dragonfruits = 0;
    public static int deaths = 0;

    void Update()
    {
       Mango_Text.text = "X" + mangos;
       Dragonfruit_Text.text = "X" + dragonfruits;
       Death_Text.text = "" + deaths;

    }
}

