# NinjaHead

Juego de plataformas y acción en 2D con temática ninja, con el ritmo de jefes de Cuphead. Hecho en Unity como proyecto escolar.

**Video del juego:** https://youtu.be/XeLgIj3gZUo

## La idea

El jugador es un shinobi que tiene que superar tres niveles, cada uno con una mecánica distinta, hasta llegar al líder del clan enemigo y derrotarlo.

1. **Nivel 1 – El ascenso.** Un nivel vertical: hay que subir de plataforma en plataforma mientras la lava sube desde abajo.
2. **Nivel 2 – La torre del ayudante.** Al estilo de Donkey Kong: vigas y escaleras, y un mini jefe que lanza barriles que ruedan por las plataformas. Hay que llegar arriba y vencerlo.
3. **Nivel 3 – El jefe final.** Una arena contra el líder del clan, con dos fases de ataques.

**Cómo se gana:** superando los tres niveles.
**Cómo se pierde:** el jugador tiene 3 vidas. Cada golpe, barril, proyectil, caída o toque con la lava quita una vida. Sin vidas, es Game Over.

## Controles

| Tecla | Acción |
|---|---|
| A / D o flechas | Moverse |
| W / S | Subir y bajar escaleras |
| Espacio | Saltar |
| J | Lanzar shuriken |
| Esc | Pausa |
| Enter | Continuar al siguiente nivel |
| R | Reiniciar después del Game Over |

## Cómo abrir el proyecto

1. Instala **Unity 6.6 (6000.6.8f1)** desde Unity Hub.
2. Clona el repositorio:
   ```
   git clone https://github.com/NicolasBravoMiguel/NinjaGame.git
   ```
3. En Unity Hub: **Add → Add project from disk** y elige la carpeta `NinjaGame`.
4. Abre la escena `Assets/Scenes/MenuPrincipal` y dale **Play**.

Para jugar sin Unity, descarga la build de macOS desde la sección **Releases** del repositorio.

## Estructura del proyecto

- **Scenes:** MenuPrincipal, Nivel1, Nivel2, Nivel3 y Final.
- **Scripts:** organizados en Data, Domain, Framework y Utils (Constants y Efectos).
- **Jerarquía de cada nivel:** Managers, Setup, Environment, Characters, Canvases y Systems.
- La comunicación entre scripts usa eventos `Action` (por ejemplo, `GameManager.OnVidasCambiaron` para la interfaz y `JefeVida.OnJefeGolpeado` para la sacudida de cámara).

## Créditos

| Asset | Autor | Licencia |
|---|---|---|
| Jefe final (Pixel DarkNinja) | Zhen – https://zhen.itch.io | Uso personal y comercial gratis; no se puede redistribuir ni revender |
| Grungy Dungeon Tileset #1: Walls w/ Torch Animation | Hypnobius – https://hypnobius.itch.io | Uso personal y comercial; no se puede redistribuir ni revender |
| Assets de CraftPix | CraftPix – https://craftpix.net | https://craftpix.net/file-licenses/ |
| Jugador (Martial Hero) | LuizMelo | Creative Commons Zero (CC0) |
| Mini jefe (yellowNinja) | Autor no indicado en el paquete | No venía licencia en el paquete |
| Shurikens (Elemental Shurikens – Pixel Art Asset Pack) | clavapixel | Uso personal y comercial gratis |
| Corazones (16x16 Heart Health) | _Por completar_ | _Por completar_ |
| Tiles de madera y escalera de cuerda | _Por completar_ | _Por completar_ |
| Fondo | Imagen generada con Gemini (Google) | — |
| Efectos de sonido y música | Freesound – https://freesound.org | Licencias Creative Commons de cada sonido |

## Versiones

Ver [CHANGELOG.md](CHANGELOG.md). El proyecto usa Gitflow: ramas `pre-release-x.x.x` y `pre-release-x.x.x.n-nombre`, Pull Requests, tags y Releases.
