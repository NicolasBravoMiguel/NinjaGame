# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.0.4] - 22/11/2026
### Added
- Vidas con iconos de corazón en la interfaz (VidasUI).
- Barra de vida del mini jefe y del jefe final (BarraVidaJefe).
- Menú de pausa con Esc, con botones Continuar y Menú (MenuPausa).
- Partículas: PolvoSalto, ChispasGolpe y HumoDerrota.
- Estela (Trail Renderer) en el shuriken.
- Luz global de noche, luces en los jefes y en la lava, y post-proceso con Bloom y Vignette.
- Sacudida de cámara al recibir o hacer daño (CamaraRig + SacudidaCamara).
- Efectos de sonido de salto, ataque y golpe, y música persistente entre escenas (MusicaPersistente).
- Fondo en los tres niveles, con parallax en el nivel 1.
- Notas del playtest en Playtest.md.
### Changed
- CamaraSube ahora funciona desde el CamaraRig.
- El proyectil del jefe final usa el sprite shuriken_jefe.

## [0.0.3] - 21/11/2026
### Added
- Sprites del jugador, mini jefe, jefe, escenario y corazones de vida.
- Animaciones del jugador: idle, correr, saltar, escalar y atacar (Animator + PlayerAnimacion).
- Animaciones del mini jefe y del jefe: idle y ataque.
- Script Parallax para el fondo.
### Changed
- Plataformas, vigas y paredes con Draw Mode Tiled.
- LanzadorBarriles y JefeFinal activan la animación de ataque.

## [0.0.2] - 20/11/2026

### Added
- Shuriken del jugador con la tecla J (19/11/2026).
- Escaleras: el jugador sube y baja con W/S (19/11/2026).
- Escenas MenuPrincipal y Final, y cambio de nivel con Enter (19/11/2026).
- Nivel 2: vigas, escaleras, barriles y mini jefe con 5 de vida (19/11/2026).
- Los barriles se rompen con 2 shurikens (19/11/2026).
- Nivel 3: jefe final con dos fases (20/11/2026).

### Changed
- La escena Nivel1_Graybox ahora se llama Nivel1 (19/11/2026).

## [0.0.1] - 18/11/2026

### Added
- GameManager con 3 vidas, victoria, Game Over y reinicio con R (18/11/2026).
- Interfaz: texto de vidas, panel de Game Over y panel de victoria (18/11/2026).
- Lava que sube y quita una vida al tocarla (18/11/2026).
- Meta que solo se activa al tocarla desde arriba (18/11/2026).
- Cámara CamaraSube que sigue al jugador sin bajar de la lava (18/11/2026).
- Scripts Constants, Peligro, Meta, VidasUI y Lava (18/11/2026).

## [0.0.0] - 18/11/2026

### Added
- Documento de concepto: idea, objetivo, cómo se gana y cómo se pierde (17/11/2026).
- Proyecto en Unity 6.6 (Universal 2D) y escena del nivel 1 (18/11/2026).
- Graybox del nivel 1: suelo y plataformas con Box Collider 2D y layer Ground (18/11/2026).
- Jugador con Rigidbody 2D, Box Collider 2D y GroundCheck (18/11/2026).
- Script PlayerMovement: movimiento horizontal y salto con Input Manager clásico (18/11/2026).
- Physics Material 2D SinFriccion para que el jugador no se pegue a las paredes (18/11/2026).
- Se agrega el changelog al proyecto (18/11/2026).
- Se agrega plantilla para PR (18/11/2026).