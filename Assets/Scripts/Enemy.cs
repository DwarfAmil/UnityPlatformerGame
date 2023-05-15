using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4;

    [FormerlySerializedAs("_hp")] public int hp = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(_speed * Time.deltaTime, 0));

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ClearWall"))
        {
            _speed *= -1;
        }
    }
}
