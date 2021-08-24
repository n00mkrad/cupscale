# Cupscale
Image Upscaling GUI based on ESRGAN

![](https://i.imgur.com/ntIuSrv.png)

## Credits:

Based around [xinntao's ESRGAN](https://github.com/xinntao/ESRGAN) implemented via [Joey's Fork](https://github.com/JoeyBallentine/ESRGAN).

AMD/Intel GPU compatibility is possible thanks to BlueAmulet's [esrgan-ncnn-vulkan](https://github.com/BlueAmulet/realsr-ncnn-vulkan) based on nihui's [realsr-ncnn-vulkan](https://github.com/nihui/realsr-ncnn-vulkan) running on Tencent's [ncnn](https://github.com/Tencent/ncnn) framework, as well as [xinntao's Real-ESRGAN](https://github.com/xinntao/Real-ESRGAN).

## Download:

[Get the latest release](https://github.com/n00mkrad/cupscale/releases)

## Installation:

The application is more or less portable. It's a single executable that you can run anywhere.

Temporary files are stored in the installation directory by default, which is why you shouldn't install the application in protected locations like Program Files.

## Supported AI Backends:

- Nvidia CUDA (Recommended)
- Vulkan (Works on any modern GPU, but is slower and takes a long time start up)
- CPU (Works without GPU, but is very slow)

## Features:

- CUDA, Vulkan/NCNN or CPU supported, with included model converter for NCNN
- On-the-fly Model Interpolation
- Model Chaining (Run images through multiple models at once)
- Batch Upscaling (Load a directory or multiple single images)
- Automatic Image tiling/merging to avoid running out of VRAM
- Pre-Processing: Optionally downscale images before upscaling
- Post-Processing: Automatically resize after upscaling
- Compatible with PNG, JPEG, BMP, WEBP, TGA, DDS images
- Load image straight out of the clipboard (no need to download images from web)
- Create various types of comparisons (Side-By-Side, 50/50, and before/after animations as GIF or MP4)
