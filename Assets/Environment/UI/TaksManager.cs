using Unity.Netcode;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : NetworkBehaviour
{
    public static TaskManager Instance;

    public List<Task> Tasks = new List<Task>();

    private void Awake()
    {
        Instance = this;
    }

    [ServerRpc(RequireOwnership = false)]
    public void AddTaskServerRpc(string title, string description, string category)
    {
        Task newTask = new Task
        {
            Title = title,
            Description = description,
            Category = category,
            IsCompleted = false
        };

        Tasks.Add(newTask);
        UpdateTasksClientRpc(JsonUtility.ToJson(Tasks));
    }

    [ClientRpc]
    public void UpdateTasksClientRpc(string tasksJson)
    {
        Tasks = JsonUtility.FromJson<List<Task>>(tasksJson);
    }
}
