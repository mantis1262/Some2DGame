using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovment : MonoBehaviour
{

    private Vector2 velocity;
    private Vector3 direction;
    private bool hasMoved;

    [SerializeField] private int vision = 3;
    public Tilemap fog;


    void Update()
    {
        if(velocity.x == 0)
        {
            hasMoved = false;
        } else if(velocity.x != 0 && !hasMoved)
        {
            hasMoved = true;
            MoveByDirection();
        }

        velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void MoveByDirection()
    {
        if (velocity.x < 0)
        {
            if(velocity.y> 0)
            {
                direction = new Vector3(-.5f, .5f);
            }
            else if( velocity.y < 0)
            {
                direction = new Vector3(-.5f, -.5f);
            } 
            else
            {
                direction = new Vector3(-1f, 0);
            }
        }
        else if (velocity.x > 0)
        {
            if (velocity.y > 0)
            {
                direction = new Vector3(.5f, .5f);
            }
            else if (velocity.y < 0)
            {
                direction = new Vector3(.5f, -.5f);
            }
            else
            {
                direction = new Vector3(1f, 0);
            }
        }

        transform.position += direction;
        UpdateFog();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position -= direction;
    }

    private void UpdateFog()
    {
        Vector3Int currentPosition = fog.WorldToCell(transform.position);
        for (int i = -3; i <= 3; i++)
        {
            for (int j = -3; j <= 3; j++)
            {
                fog.SetTile(currentPosition + new Vector3Int(i, j, 0), null);
            }
        }
    }

}
