using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnArduino : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Material turnon;
    [SerializeField]
    public Material turnoff;

    MeshRenderer mesh;
    void Start()
    {
        mesh = this.gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    public void Run()
    {
        mesh.material = turnon;

    }

    public void Pause()
    {
        mesh.material = turnoff;//안녕하세요 요번에 5조 인턴으로 오게된 정선재입니다. 잘부탁드립니다.
    }
}
