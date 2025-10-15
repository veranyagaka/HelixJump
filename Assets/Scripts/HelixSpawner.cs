using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixSpawner : MonoBehaviour
{
    [Header("Helix Settings")]
    public GameObject helixParent;           // Parent object containing all helix levels
    public GameObject helixLevelPrefab;      // Prefab for a single helix level
    public int numberOfLevels = 5;           // Number of levels to spawn
    public float verticalSpacing = 3f;       // Distance between each level

    [Header("Rotation Settings")]
    public float rotationSpeed = 1f;         // Controls how sensitive the rotation feels

    private Vector2 lastTapPos;

    void Start()
    {
        if (helixParent == null)
        {
            Debug.LogWarning("Helix Parent not assigned! Please drag your helix object into the field in the Inspector.");
            return;
        }

        // Optional: spawn levels automatically if prefab is assigned
        if (helixLevelPrefab != null)
        {
            SpawnHelixLevels();
        }
    }

    void Update()
    {
        HandleHelixRotation();
    }

    /// <summary>
    /// Allows player to rotate the helix by dragging horizontally.
    /// </summary>
    void HandleHelixRotation()
    {
        if (helixParent == null)
            return;

        if (Input.GetMouseButton(0))
        {
            Vector2 curTapPos = Input.mousePosition;

            if (lastTapPos == Vector2.zero)
                lastTapPos = curTapPos;

            float delta = (lastTapPos.x - curTapPos.x) * rotationSpeed;
            lastTapPos = curTapPos;

            helixParent.transform.Rotate(Vector3.up * delta);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }
    }

    /// <summary>
    /// Instantiates helix levels and positions them evenly under the helixParent.
    /// </summary>
    void SpawnHelixLevels()
    {
        float spawnY = 0f;

        for (int i = 0; i < numberOfLevels; i++)
        {
            GameObject level = Instantiate(helixLevelPrefab, helixParent.transform);
            level.transform.localPosition = new Vector3(0, -spawnY, 0);
            spawnY += verticalSpacing;
        }

        Debug.Log($"{numberOfLevels} helix levels spawned successfully!");
    }
}

