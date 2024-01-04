using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializationCallbackScript : MonoBehaviour, ISerializationCallbackReceiver {
    public List<int> _keys = new List<int> {3, 4, 5};
    public List<string> _values = new List<string> {"I", "Love", "Unity"};

    public Dictionary<int, string> _myDictionary = new Dictionary<int, string>();
    
    public void OnBeforeSerialize() {
        Debug.Log("1111111111111");
        
        _keys.Clear();
        _values.Clear();

        foreach (var kvp in _myDictionary) {
            _keys.Add(kvp.Key);
            _values.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize() {
        Debug.Log("222222222222");
        
        _myDictionary = new Dictionary<int, string>();
        for (int i = 0; i != Math.Min(_keys.Count, _values.Count); i++) {
            _myDictionary.Add(_keys[i], _values[i]);
        }
    }

    public void OnGUI() {
        // foreach (var kvp in _myDictionary) {
        //     GUILayout.Label("Key: " + kvp.Value + "value: " + kvp.Value);
        // }
    }
}
