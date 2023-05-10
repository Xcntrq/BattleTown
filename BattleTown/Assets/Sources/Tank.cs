using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GridLayout _tilemap;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3Int cellCoord = _tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            print(_tilemap.CellToWorld(cellCoord));
        }
    }

    public void Move(Vector2 direction, float dt)
    {
        transform.up = direction;

        Vector2 desiredPosition = transform.position;
        if (direction.x == 0)
        {
            desiredPosition.x = Mathf.RoundToInt(desiredPosition.x * 0.5f) * 2;
            float deltaX = transform.position.x - desiredPosition.x;
            if (Mathf.Abs(deltaX) > 0.5f)
            {
                desiredPosition.x += Mathf.Sign(deltaX) * 2f;
            }
        }
        else if (direction.y == 0)
        {
            desiredPosition.y = Mathf.RoundToInt(desiredPosition.y * 0.5f) * 2;
            float deltaY = transform.position.y - desiredPosition.y;
            if (Mathf.Abs(deltaY) > 0.5f)
            {
                desiredPosition.y += Mathf.Sign(deltaY) * 2f;
            }
        }

        ContactFilter2D contactFilter2D = new ContactFilter2D();
        Vector2 point = (Vector2)transform.position + 2.05f * direction.normalized;
        Vector2 size = new Vector2(2.2f, 0.01f);
        int colliderCount = Physics2D.OverlapBox(point, size, transform.rotation.eulerAngles.z, contactFilter2D.NoFilter(), new Collider2D[1]);

        colliderCount = 0;

        if (colliderCount == 0)
        {
            Vector2 pos = transform.position;
            if (direction.y == 0)
                pos.y = Mathf.Round(pos.y / 2) * 2;
            else if (direction.x == 0)
                pos.x = Mathf.Round(pos.x / 2) * 2;
            transform.position = pos;

            var rb = GetComponent<Rigidbody2D>();
            rb.MovePosition(rb.position + _speed * dt * direction);
        }
    }
}