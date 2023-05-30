using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _diaText;

    [SerializeField] private TextMeshProUGUI _soulText;

    [SerializeField] private GameObject _textPanel;

    [SerializeField] private Text _text;

    [SerializeField] private GameObject _clearBtn, _unClearBtn;

    private void Start()
    {
        _clearBtn.SetActive(false);
        _unClearBtn.SetActive(false);
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

    public void TextPanel(string s, bool b)
    {
        if (b == true)
        {
            _clearBtn.SetActive(false);
            _unClearBtn.SetActive(false);
            _clearBtn.SetActive(true);
        }
        else
        {
            _clearBtn.SetActive(false);
            _unClearBtn.SetActive(false);
            _unClearBtn.SetActive(true);
        }
        _text.text = s;
        _textPanel.SetActive(true);
    }

    public void ExitTextPanel()
    {
        _textPanel.SetActive(false);
    }

    public void NextStageBtn(string s)
    {
        _textPanel.SetActive(false);
        SceneManager.LoadScene(s);
    }
    
    public void TextPanel(string s)
    {
        _text.text = s;
        _textPanel.SetActive(true);
    }
}
