using System.IO;
using UnityEngine;

public class PyRun : MonoBehaviour
{
    //Python�ļ�
    public Object pyFile;
    //Python�ļ�·��
    public string pyFilePath="Assets/src/python/";

    private Interpreter machine = new Interpreter();

    private object ClassReference;


    private void Awake()
    {
        machine.Compile(pyFilePath + pyFile.name + ".py", Microsoft.Scripting.SourceCodeKind.Statements);
        ClassReference = machine.GetVariable(Path.GetFileNameWithoutExtension(pyFilePath + pyFile.name + ".py"));
        InvokeMethod("Awake");
    }

    private void Start()
    {
        InvokeMethod("Start");
    }

    private void Update()
    {
        InvokeMethod("Update");
    }
    private void InvokeMethod(string Method)
    {
        machine.InvokeMethod(ClassReference, Method, this);
    }
}
