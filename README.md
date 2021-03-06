<p align='center'><img align='center' src='https://github.com/BeardedPlatypus/unity-camera-package/blob/main/.docs/camera.png?raw=true' width='25%'></p>

*this is a work-in-progress and will be updated further soon*

# BeardedPlatypus.OrbitCamera

A simple orbit camera implementation build around CineMachine with UniRx and optionally
Zenject. The primary goal is to provide a simple, reusable, and injectable camera 
configuration which can be used to create simple 3D editors under a permissible license.

While anyone is free to reuse, extend, and change this code, I do want to put the 
disclaimer out there that I am very much a Unity beginner. As such there might be
better ways to achieve similar or better results.

## Demo

<p align='center'><img align='center' src='https://github.com/BeardedPlatypus/media-storage/blob/main/unity-camera-package/camera_demo_medium.gif?raw=true' width='66%'></p>

*A more extensive video, as well as an interactive demo will be added shortly.*

## Motivation: A simple (injectable) orbit camera configuration for creating simple editors

These past few months I have been working on some different simple 3D editor 
applications build on top of Unity. I often found myself writing very similar 
code to handle the camera in these projects. After writing this code about
three times, and planning to use similar code in another project, I figured
it was about time to create a simple package that would provide this behaviour
out of the box, but still allowed for enough customisability such that it could
be reused in a variety of different projects. Basically, take out the boilerplate
so I can focus on the interesting behaviour. 

## Quickstart: Install the UPM packages

*The following describes how to quickly get this package up and running, for a more detailed approach see the Installation section.*

The OrbitCamera package consists of the following upm packages:

* [BeardedPlatypus.OrbitCamera.Core](https://github.com/BeardedPlatypus/orbit-camera/tree/upm/core): Contains the main concepts and interfaces to use the camera setup.
* [BeardedPlatypus.OrbitCamera.Presets](https://github.com/BeardedPlatypus/orbit-camera/tree/upm/presets): Contains the preset implementations for the behaviour of the camera.
* [BeardedPlatypus.OrbitCamera.Zenject](https://github.com/BeardedPlatypus/orbit-camera/tree/upm/zenject): An optional package which provides the [Zenject](https://github.com/modesttree/Zenject) installers to facilitate dependency injection.

Each of these can be installed by adding the following URLs to your Unity Package Manager:

```
https://github.com/BeardedPlatypus/orbit-camera.git#upm/core
https://github.com/BeardedPlatypus/orbit-camera.git#upm/presets
https://github.com/BeardedPlatypus/orbit-camera.git#upm/zenject
```
Note that you will need [the latest version of Zenject](https://github.com/modesttree/Zenject/releases/tag/9.2.0) and [UniRx](https://github.com/neuecc/UniRx).
Once this has been setup you can configure your project similar to how [Samples assembly](https://github.com/BeardedPlatypus/orbit-camera/tree/main/Assets/Scripts/OrbitCamera.Samples) is configured.

## Installation: Reuse the upm packages or extend the existing code

### Add the camera core upm package

To use this library, you will at the very least need to add the upm core package
to your project with the package manager (for more details on how to do this
check out [the unity official documentation]()). This will add the basic classes
as well as the preset behaviour to your project for you to use. 

Note that this will add the UniRx and Cinemachine dependencies as well, as these
have been used to develop this library. 

### Optionally add the camera zenject upm packages

I personally like to use Zenject to handle my dependency injection within Unity.
If you use this as well, you can further add the zenject camera upm package to
your project. This package provides the mono behaviours and installers to 
inject your camera system into your scenes.

### Implement the IBindings interface

### Configure your camera system (with zenject)

## Develop

## Usecases

## Dependencies: The awesome libraries with which this package is realised.

* [UniRx](https://github.com/neuecc/UniRx)
* [CineMachine](https://unity.com/unity/features/editor/art-and-design/cinemachine)
* [Zenject](https://github.com/modesttree/Zenject) - Optional

## Attribution

* Camera icon made by dreamicons from [Flaticon](https://www.flaticon.com/)
