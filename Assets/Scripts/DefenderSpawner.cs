using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        if(defender!=null)
            AttemptToPlaceDefenderAt(GetSquareClicked());        
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStartCost();

        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 toGrid = SnapToGrid(worldPos);

        return toGrid;
    }

    private Vector2 SnapToGrid(Vector2 toGrid)
    {
        float posX = Mathf.RoundToInt(toGrid.x);
        float posY = Mathf.RoundToInt(toGrid.y);

        return new Vector2(posX, posY);
    }

    private void SpawnDefender(Vector2 toGrid)
    {
        Defender newDefender = Instantiate(defender, toGrid, Quaternion.identity) as Defender;
    }
}
