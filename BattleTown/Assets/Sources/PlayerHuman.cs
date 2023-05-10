using UnityEngine;

public class PlayerHuman : Player
{
    [SerializeField] private string AxisH;
    [SerializeField] private string AxisV;

    private void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;

        float axisH = Input.GetAxis(AxisH);
        float axisV = Input.GetAxis(AxisV);

        if (axisH != 0)
        {
            direction = axisH * Vector2.right;
        }

        if (axisV != 0)
        {
            direction = axisV * Vector2.up;
        }

        if (direction != Vector2.zero)
        {
            _tank.Move(direction, Time.deltaTime);
            if (Time.deltaTime != Time.fixedDeltaTime)
                print(Time.deltaTime + "   " + Time.fixedDeltaTime);
        }
    }
}