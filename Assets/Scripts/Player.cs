using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _power = 3;
    [SerializeField] private int _diaNum;

    private bool _isJump, _isDoubleJump, _isKey;

    private int _jumpCount, _soul;

    private Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _isJump = false;
        _isDoubleJump = false;
        _isKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;

        if (x > 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if (x < 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        
        transform.Translate(x, 0, 0);

        if (_jumpCount == 1)
        {
            _isJump = true;
        }

        else if (_jumpCount == 2)
        {
            _jumpCount = 0;
            _diaNum -= 5;
            GameObject.FindWithTag("PlayUI").GetComponent<PlayUI>().DiaUpdate(_diaNum);
            _isDoubleJump = false;
        }

        if (_diaNum >= 5)
        {
            _isDoubleJump = true;
        }

        if ((Input.GetKeyDown(KeyCode.Space) && !_isJump) || (Input.GetKeyDown(KeyCode.Space) && _isDoubleJump))
        {
            _jumpCount++;
            _rigidbody2D.AddForce(new Vector2(0, _power), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            _diaNum++;
            
            GameObject.FindWithTag("PlayUI").GetComponent<PlayUI>().DiaUpdate(_diaNum);
        }
        
        if (other.gameObject.CompareTag("EnemyHead"))
        {
            other.gameObject.GetComponentInParent<Enemy>().hp -= 5;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _jumpCount = 0;
            _isJump = false;
        }

        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            _isKey = true;
            Debug.Log("Key!");
        }

        if (other.gameObject.CompareTag("SoulMaster"))
        {
            if (_soul == 1)
            {
                SceneManager.LoadScene("Stage02");
            }
            else
            {
                GameObject.FindWithTag("PlayUI").GetComponent<PlayUI>().TextPanel();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GoldenChest") && _isKey)
        {
            _isKey = false;
            other.gameObject.GetComponent<Chest>().OpenChest();
        }

        if (other.gameObject.CompareTag("Soul"))
        {
            _soul++;
            GameObject.FindWithTag("PlayUI").GetComponent<PlayUI>().SoulUpdate(_soul);
            Destroy(other.gameObject);
        }
    }
}
