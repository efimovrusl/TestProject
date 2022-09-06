using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Managers
{
[RequireComponent( typeof( UIDocument ) )]
public class UIManager : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _rootVisualElement;

    private TextField _pathToJsonTextField;
    private Button _loadFileButton;
    
    public event Action<string> OnLoadFileButtonClick;

    private void Start()
    {
        _uiDocument = GetComponent<UIDocument>();

        _rootVisualElement = _uiDocument.rootVisualElement;
        _pathToJsonTextField = _rootVisualElement.Q<TextField>( "pathToJsonTextField" );
        _loadFileButton = _rootVisualElement.Q<Button>( "loadFileButton" );

        _loadFileButton.RegisterCallback<ClickEvent>( _ =>
            OnLoadFileButtonClick?.Invoke( _pathToJsonTextField.value ) );
    }

}
}