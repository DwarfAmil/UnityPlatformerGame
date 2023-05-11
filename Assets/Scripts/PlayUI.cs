using TMPro;
using UnityEngine;

public class PlayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _diaText;

    private void Start()
    {
        _diaText.text = "Dia - " + 0;
    }

    public void DiaUpdate(int num)
    {
        _diaText.text = "Dia - " + num;
    }
}
