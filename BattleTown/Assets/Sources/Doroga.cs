using UnityEngine;

public class Doroga : MonoBehaviour
{
    private float _timer;
    private bool _isActive;

    private void Update()
    {
        if (_isActive)
            _timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isActive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print(_timer);
    }
}