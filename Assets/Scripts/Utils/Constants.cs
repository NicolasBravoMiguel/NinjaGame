using UnityEngine;

/// <summary>
/// Constantes compartidas por todo el proyecto.
/// </summary>
public static class Constants
{
    public const string TAG_PLAYER = "Player";
    public const string TAG_ESCALERA = "Escalera";
    public const string CAPA_SUELO = "Ground";

    public const int VIDAS_INICIALES = 3;

    public const KeyCode TECLA_ATAQUE = KeyCode.J;
    public const KeyCode TECLA_REINICIO = KeyCode.R;
    public const KeyCode TECLA_CONTINUAR = KeyCode.Return;
    public const KeyCode TECLA_PAUSA = KeyCode.Escape;

    public const string ESCENA_MENU = "MenuPrincipal";
    public const string ESCENA_NIVEL1 = "Nivel1";
}