using TMPro;
using UnityEngine;

public class PlayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _diaText;

    [SerializeField] private TextMeshProUGUI _soulText;

    [SerializeField] private GameObject _textPanel;

    private void Start()
    {
        _textPanel.SetActive(false);
        _diaText.text = "X " + 0;
        _soulText.text = "X " + 0;
    }

    public void DiaUpdate(int num)
    {
        _diaText.text = "X " + num;
    }

    public void SoulUpdate(int num)
    {
        _soulText.text = "X " + num;
    }

    public void TextPanel()
    {
        _textPanel.SetActive(true);
    }

    public void ExitTextPanel()
    {
        _textPanel.SetActive(false);
    }
}
