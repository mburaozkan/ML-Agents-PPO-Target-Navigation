using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

// This class defines an ML-Agents agent that learns to move to a target point in a 2D environment
public class MoveToTargetAgent : Agent
{
    // References to the environment, the target, and the background
    [SerializeField] private Transform env; // The parent object for the environment
    [SerializeField] private Transform target; // The target object the agent needs to reach
    [SerializeField] private SpriteRenderer backgroundSpriteRenderer; // The background, which will change color depending on success or failure

    // This function is called at the start of each new training episode
    public override void OnEpisodeBegin()
    {
        // Randomize the agent's starting position within a certain range
        transform.localPosition = new Vector3(Random.Range(-3.5f, -1.5f), Random.Range(-3.5f, 3.5f));

        // Randomize the target's position within a different range
        target.localPosition = new Vector3(Random.Range(1.5f, 3.5f), Random.Range(-3.5f, 3.5f));

        // Randomly rotate the environment to introduce variation in the training
        env.localRotation  = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

        // Reset the agent's rotation to its original state
        transform.rotation = Quaternion.identity;
    }

    // Collects observations for the agent to make decisions based on its environment
    public override void CollectObservations(VectorSensor sensor)
    {
        // Add the agent's current position as an observation
        sensor.AddObservation((Vector2)transform.localPosition);

        // Add the target's current position as an observation
        sensor.AddObservation((Vector2)target.localPosition);
    }

    // Defines how the agent should move based on the actions received from the neural network
    public override void OnActionReceived(ActionBuffers actions)
    {
        // Get the X and Y movement values from the continuous action space
        float moveX = actions.ContinuousActions[0];
        float moveY = actions.ContinuousActions[1];

        // Set the movement speed for the agent
        float movementSpeed = 5f;

        // Update the agent's position based on the action values
        transform.position += new Vector3(moveX, moveY) * Time.deltaTime * movementSpeed;
    }

    // Provides manual controls for testing the agent's behavior via keyboard inputs (WASD controls)
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;

        // Initialize movement inputs for X and Y directions
        float moveX = 0f;
        float moveY = 0f;

        // Map WASD keys to movement directions
        if (Input.GetKey(KeyCode.W)) moveY = 1f; // Move up
        if (Input.GetKey(KeyCode.S)) moveY = -1f; // Move down
        if (Input.GetKey(KeyCode.A)) moveX = -1f; // Move left
        if (Input.GetKey(KeyCode.D)) moveX = 1f; // Move right

        // Assign the heuristic (manual) control values to the continuous actions
        continuousActions[0] = moveX;
        continuousActions[1] = moveY;
    }

    // Handles collision events to provide rewards or penalties based on what the agent touches
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the agent reached the target
        if (collision.TryGetComponent(out Target target))
        {
            // Reward the agent for reaching the target
            AddReward(20f);

            // Change the background color to green to indicate success
            backgroundSpriteRenderer.color = Color.green;

            // End the current episode since the goal was achieved
            EndEpisode();
        }
        // Check if the agent hit a wall
        else if (collision.TryGetComponent(out Wall wall))
        {
            // Penalize the agent for hitting the wall
            AddReward(-2f);

            // Change the background color to red to indicate failure
            backgroundSpriteRenderer.color = Color.red;

            // End the current episode as the agent made a mistake
            EndEpisode();   
        }
    }
}
