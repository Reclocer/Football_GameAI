using UnityEngine;

public class UserControlFabric : MonoBehaviour
{
    [SerializeField] private Player _player;

    public static UserControlFabric Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void SetControlOnPlayer<T>() where T : Component, IUserControl
    {
        IUserControl control = _player.gameObject.AddComponent<T>();
        _player.SetControl(control);
    }
}
