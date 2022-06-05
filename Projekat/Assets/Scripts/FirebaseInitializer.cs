using Firebase;
using Firebase.Analytics;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Firebase.Database;

public class FirebaseInitializer : MonoBehaviour
{
    public UnityEvent onFirebaseInitialized;

    private void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

    }

}