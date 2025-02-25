# Virtual Reality Prosthesis Evaluation Platform
Platform for evaluating and customizing prosthetic devices using virtual reality.
Development is generalized from the online synergy identification platform.

Wiki: https://github.com/Rigaro/VRProEP/wiki  
Youtube: https://www.youtube.com/watch?v=vvq4tjShdB4

## Features
- User data: User/subject information and experimental data is stored externally to software data to protect personal information. Experimental data is stored anonymously.
- Prosthetic devices: Allows the addition of commercial (3D models) or custom virtual prosthetic devices and to automatically personalise their dimensions to the users/subjects.
- Human-prosthetic interfaces: Allows the implementation of different interfaces. Currently implemented: sEMG proportional, Motion-based.
- Object interaction: Allows interaction with objects through a VR controller (able-bodied) or through the virtual prosthetic devices and interfaces.
- Mixed reality: Allows recording of the user and virtual reality environment in Mixed Reality by placing the user in the virtual world.
- External hardware: Allows the integration of external hardware devices. Currently implemented: bone conduction feedback device, myoware sEMG electrode system, Thalmic Labs Myoband.

## Integrations
### SteamVR
SteamVR used to handle Virtual Reality headsets.
Current headset compatibility: HTC Vive Pro.

### LIV
Software to create Mixed Reality videos.
https://liv.tv/

### Thalmic Labs Myoband
Pattern recognition based myoelectric sensor. Discontinued.

## Hardware
Resources for hardware integration, such as CAD files and Arduino code, can be found in https://github.com/Rigaro/VRProEP-Hardware

# Platform versions in reseach papers

## Transaction on Neural Systems and Rehabilitation Engineering 2020 Paper Submission
The following platform and Unity versions were used for the experiments included in the paper submitted to IEEE Transaction on Neural Systems and Rehabilitation Engineering in 2020, titled *"Task-space Synergies for Reaching using Upper-limb Prostheses"*.

- VRProEP Version: 0.4. Tag Link: https://github.com/Rigaro/VRProEP/releases/tag/0.4
- Unity Version: 2018.3.8f1

Runs from Unity Editor. See Wiki for more information.

## Frontiers in Neuroscience 2020 Paper
The following platform and Unity versions were used for the experiments included in the paper published in Frontiers in Neuroscience in 2020, titled *"Tactile Feedback in Closed-Loop Control of Myoelectric Hand Grasping: Conveying Information of Multiple Sensors Simultaneously via a Single Feedback Channel"*.  
Paper DOI: https://doi.org/10.3389/fnins.2020.00348  
Paper website: https://www.frontiersin.org/articles/10.3389/fnins.2020.00348/full

- VRProEP Version: 0.5.1. Tag Link: https://github.com/Rigaro/VRProEP/releases/tag/0.5.1
- Unity Version: 2019.1.10f1

Runs from Unity Editor. See Wiki for more information.


