<p align='center'><img align='center' src='https://github.com/BeardedPlatypus/unity-camera-package/blob/main/.docs/camera.png?raw=true' width='25%'></p>

# BeardedPlatypus.OrbitCamera

A simple orbit camera implementation build around [CineMachine][cinemachine] with
[UniRx][unirx] and optionally [UniDi][unidi]. The primary goal is to provide a simple,
reusable, and injectable camera configuration which can be used to create simple 3D
editors under a permissible license.

While anyone is free to reuse, extend, and change this code, I do want to put the
disclaimer out there that I am very much a Unity beginner. As such there might be
better ways to achieve similar or better results.

[unirx]: https://github.com/neuecc/UniRx
[unidi]: https://github.com/UniDi/UniDi
[cinemachine]: https://docs.unity3d.com/Packages/com.unity.cinemachine@2.6/manual/index.html

## Demo

<p align='center'><img align='center' src='https://github.com/BeardedPlatypus/media-storage/blob/main/unity-camera-package/camera_demo_medium.gif?raw=true' width='66%'></p>

## Motivation: A simple (injectable) orbit camera configuration for creating simple editors

These past few months I have been working on some different simple 3D editor
applications build on top of Unity. I often found myself writing very similar
code to handle the camera in these projects. After writing this code about
three times, and planning to use similar code in another project, I figured
it was about time to create a simple package that would provide this behavior
out of the box, but still allowed for enough customizability such that it could
be reused in a variety of different projects. Basically, it take care of the
boilerplate so I can focus on the interesting behavior.

## Quickstart: Install the UPM packages

*The following describes how to quickly get this package up and running, for a more detailed approach see the Installation section.*

The OrbitCamera package consists of the following upm packages:

* [BeardedPlatypus.OrbitCamera.Core](https://github.com/BeardedPlatypus/orbit-camera/tree/upm/core): Contains the main concepts and interfaces to use the camera setup.
* [BeardedPlatypus.OrbitCamera.Presets](https://github.com/BeardedPlatypus/orbit-camera/tree/upm/presets): Contains the preset implementations for the behaviour of the camera.
* [BeardedPlatypus.OrbitCamera.UniDi](https://github.com/BeardedPlatypus/orbit-camera/tree/upm/unidi): An optional package which provides the [UniDi][unidi] installers to facilitate dependency injection.

Each of these can be installed by adding the following URLs to your Unity Package Manager:

```
https://github.com/BeardedPlatypus/orbit-camera.git#upm/core
https://github.com/BeardedPlatypus/orbit-camera.git#upm/presets
https://github.com/BeardedPlatypus/orbit-camera.git#upm/unidi
```

Note that you will need [the latest version of UniDi][unidi] and [UniRx][unirx].
Once this has been setup you can configure your project similar to how the [Samples assembly](https://github.com/BeardedPlatypus/orbit-camera/tree/main/Assets/Scripts/OrbitCamera.Samples) has been configured.

## Installation: Reuse the upm packages or extend the existing code

### Add the camera core upm package

To use this library, you will at the very least need to add the `upm/core` package
to your project with the package manager (for more details on how to do this check out
[the unity official documentation][git_dependencies]). The `core` package provides
controller implementations as well as the interfaces that need to be implemented in
order for the controller to work.

When `upm/core` is installed, UniRx and CineMachine are added to your project as well
as additional dependencies.

Preset implementations of the movement interfaces can be obtained by installing the
`upm/preset` package. This packages provides the basic behavior as shown in the above
demo for rotating, zooming and setting the view.

[git_dependencies]: https://docs.unity3d.com/Manual/upm-git.html

### Optionally add the camera UniDi upm packages

I personally like to use [UniDi][unidi] to handle my dependency injection within Unity.
If you use this already, or want to start using it, you can add the `upm/unidi` package to
your project (note that there is also a Zenject `upm/zenject` available, if you have not
upgraded). This package provides the mono behaviors and installers to inject your camera
system into your scenes.

### Implement the `IBindings` interface

The `IBindings` interface acts as mapping between your input actions the camera
controller. It requires an implementation of the `Orbit`, `Translate`, and `Zoom`
observables, as well as the direct set operations.

An example implementation can be found in the [`OrbitCamera.Samples\binding.cs`](/Assets/Scripts/OrbitCamera.Samples/Bindings.cs).
It provides the translation of mouse movements to the before-mentioned observables.
For specific details on how such values can be mapped, I recommend reading the
[ReactiveX documentation][rx_docs]

If any of the operations are not relevant, you can assign them an empty observable,
which will ensure no events are emitted.

[rx_docs]: https://reactivex.io/documentation/observable.html

### Configure your camera system

*For the following section I assume you are using `UniDi` and it will require changes if you do not use it*

With the bindings set up, it is time to configure the scene. The following section
describes how to set up a scene similar to the [`SampleScene.unity`](/Assets/Scenes/SampleScene.unity).

#### Create a CineMachine camera set up

First assign the `CineMachineBrain` to the `Main Camera`. There is no need to adjust the settings, however
you are free to do so.

Next add add a virtual camera by creating a new empty game object and assign a `CineMachineVirtualCamera` script.
We need to assign the transform of this game object to the orbit camera controller. A simple script to do this
can be found [here](/Assets/Scripts/OrbitCamera.Samples/ControllerBehaviour.cs).

#### Configure the dependency injection

With the camera configured, we can set up the dependency injection. We need to set up the following dependencies:

* The `CameraControllerInstaller`
* The `OrbitCenterInstaller`
* The `CoroutineRunnerInstaller`

Additionally, we need the dependencies for the different kinds of orbit, translation, and zoom behaviors. Preset
implementations can be found in the `Presets` directory.

Lastly, we need the `IBindings` dependency injected, an example installer can be found in [`CameraInstaller.cs`](/Assets/Scripts/OrbitCamera.Samples/CameraInstaller.cs).

## Dependencies: The awesome libraries with which this package is realized

* [UniRx][unirx]
* [CineMachine][cinemachine]
* [UniDi][unidi] - Optional

## Attribution

* Camera icon made by dreamicons from [Flaticon](https://www.flaticon.com/)
