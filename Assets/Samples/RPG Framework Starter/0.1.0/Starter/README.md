# Starter

What a game on the RPG Framework needs before its first module runs: an entry point, the game's global installer, the
databases naming each module and its scene, the module router, a variable map, input actions, the transitions, the
dialogue window and the audio players. Begin your game from it and change anything in it: once imported, it is yours.

It also shows how a game adds a module of its own. The **splash screen** is one: the framework has no splash module,
so the Starter writes it the way every framework module is written.

---

## Before you press Play

As with a new project from a template, a few steps come first:

1. **Import the samples it is built from**: in the Package Manager, RPG Framework Menu's **Menu Sample** and RPG
   Framework Field's **2D Field Sample**. The title screen is the Menu Sample's `MenuModule` scene and the field the 2D
   Field Sample's `FieldModule`; both scenes' input adapters already use the Starter's actions.
2. **Install the menu's text**: RPG Framework > Menu > Install Sample Text. The game reads its text from
   `StreamingAssets` as it starts, and a sample cannot put files there itself.
3. **Export the field**: RPG Framework > Field Designer Window, **Add New Field Entry**, its **Field Prefab** the 2D
   Field Sample's `SampleField`, then **Export Runtime Data** into the 2D Field Sample's folder, namespace
   `RPGFramework.Field.Sample2D`. It builds the field's bundle into `StreamingAssets` and writes the sample's
   `FieldDatabase.cs` again.
4. **Make the Starter's actions the project's**: Edit > Project Settings > Input System Package, **Project-wide
   Actions**: `Starter Input Actions`. The menus move between their buttons with its **UI** map.
5. **List the scenes in the build**: File > Build Profiles, **Scene List**: `Entry Point` first, then
   `SplashScreenModule`, `MenuModule` and `FieldModule`. A module's scene is loaded by name, so one left out fails as
   it loads.
6. **Open `Entry Point` and press Play**: the splash screen, then the title. **New Game** begins in `SampleField`,
   which the variable map's `CurrentField` names.

---

## What's in it

| | |
| --- | --- |
| `Entry Point` | The first scene: builds the framework from the global installer and enters the splash screen |
| `Starter Global Installer` | Everything the framework asks the game for, and the stores the modules share |
| `StarterModuleDatabase`, `StarterSceneDatabase` | Each module's id to the interface its scene binds, and that interface to the scene's name |
| `StarterModuleRouter` | The framework's routes, from `DefaultModuleRouter`, and the splash screen's: on to the title |
| `StarterDefaultSettings` | The settings a first launch starts from |
| `Variable Map` | Every variable a framework package requires, with its default |
| `Starter Input Actions` | A **Game** map, one action per control slot, and a **UI** map for the menus |
| `Transitions/` | The transition config and database, using Core's fade, and the router's config |
| `Dialogue/` | The dialogue window, using Core's, and its text styles |
| `Audio/` | Empty music and SFX providers, and a mixer with a group for each stem |
| `SplashScreen/` | The splash screen module, in an assembly of its own |

---

## Making it your own

- **A module of your own** joins both databases, under an id of its own, and its scene the build's scene list. The
  router decides what follows each of its outcomes.
- **Sounds**: the Starter is silent. `SilentAudioIntentPlayer` plays nothing for what the menus and field ask for, and
  the music and SFX providers are empty. Fill the providers (Create > RPG Framework > Audio) and bind an
  `IAudioIntentPlayer` of your own that maps each intent to a sound.
- **Variables**: declare your game's in the `Variable Map`. When a framework package adds a required variable, **Add
  Missing Required Variables** in its inspector declares it.
- **Text**: the menus' localisation keys are in the Menu Sample's installer. Replace them with your own spreadsheet's
  (RPG Framework Localisation's README).
- **The debug room**: install RPG Framework Debug Room and add `ENABLE_RPG_FRAMEWORK_DEBUG` to a build profile's
  scripting defines. The databases already name its module under that define; a scene named `DebugRoomModule`, with a
  scene installer and GameObject > RPG Framework > Debug Room > Debug Room Module, joins that profile's scene list.

---

## A module of your own: the splash screen

A module is a scene, an interface Core resolves and enters, and a component in the scene binding it:

- **`SplashScreenConstants`** gives it an id no framework module uses — Field is 0, Menu 1, Battle 2 and the debug room
  255 — and the outcome it reports when it is done.
- **`ISplashScreenModule`** is what the module database names, and **`SplashScreenModule`** implements it: once Core
  has revealed the scene it waits three seconds, then reports `OUTCOME_FINISHED`.
- **`SplashScreenModuleMonoBehaviour`**, in the scene, implements Core's `IModuleBindings`: Core calls it after the
  game's scene installer, and it binds the module only where the installer bound nothing, as every framework module
  binds its own types.
- **`SplashScreenSceneInstaller`** is the game's installer for that scene. It binds nothing, but every module scene
  needs one.
- **`StarterModuleRouter`** routes the outcome, clearing the module stack for the title menu.

It is in its own assembly, `StarterSample.SplashScreen`, which references only Core, Core's shared types and DI: the
composition root knows the module, and the module knows nothing of the game.
