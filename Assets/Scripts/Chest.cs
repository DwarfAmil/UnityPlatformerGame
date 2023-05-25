using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _soul;

    public void OpenChest()
    {
        StartCoroutine("Open");
    }

    private IEnumerator Open()
    {
        _animator.SetTrigger("Open");

        yield return new WaitForSeconds(0.5f);
        
        Instantiate(
            _soul,
            new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z),
            Quaternion.identity
        );
    }
}
