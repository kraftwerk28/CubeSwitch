using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInit : MonoBehaviour
{
    [Header("Cubes")]
    public GameObject Cube;
    public GameObject Jumper;
    public Transmitter_AI Transmitter;

    [Header("Teleporter buttons")]
    public GameObject CubeButton;
    public GameObject JumperButton;

    [Header("Other buttons")]
    public GameObject OverviewButton;
    public GameObject ExitButton;
    public GameObject SwitchButton;
    public GameObject HelpButton;
    public GameObject PanelClose;
    // [Header("Camera")]
    // public Camera Camera;

    // Use this for initialization
    void Start()
    {
        Cube = GameObject.Find("Heavy");
        Jumper = GameObject.Find("Jumper");
        Transmitter = GameObject.Find("Transmitter").GetComponent<Transmitter_AI>();

        CubeButton.GetComponent<Button>().onClick.AddListener(() => { Transmitter.Teleport(Cube); });
        JumperButton.GetComponent<Button>().onClick.AddListener(() => { Transmitter.Teleport(Jumper); });
        OverviewButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MapOverview>().ToggleOverview();
        });
        ExitButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            transform.Find("MenuSwitcher").GetComponent<MenuSwitcher>().SwitchToMenu();
        });
        HelpButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            transform.Find("PanelHelp").GetComponent<PanelHelp>().Show(true);
        });
        PanelClose.GetComponent<Button>().onClick.AddListener(() =>
        {
            transform.Find("PanelHelp").transform.Find("Button").GetComponent<Button>().onClick.AddListener(() =>
            {
                transform.Find("PanelHelp").GetComponent<PanelHelp>().Show(false);
            });
        });
        SwitchButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MarkerControl>().Switch();
        });
    }
}
