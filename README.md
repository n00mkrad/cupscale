# cupscale
Image Upscaling GUI based on ESRGAN - **WORK IN PROGRESS**

![](https://i.imgur.com/tIRI1MO.png)

## Download:

[Get the latest release](https://github.com/n00mkrad/cupscale/releases)

## Installation:

The application is currently portable. It's a single executable that you can run anywhere.

It comes with an ESRGAN implementation, however, Python and all dependencies (PyTorch, opencv-python, tensorboardX) are required for ESRGAN to run on CUDA.

## Supported AI Backends:

- Nvidia CUDA (Recommended)
- Vulkan (Works on any modern GPU, but is slower and takes a long time start up)
- CPU (Works without GPU, but is very slow)

## Features:

- CUDA, Vulkan/NCNN or CPU supported, with included model converter for NCNN
- On-the-fly Model Interpolation
- Model Chaining
- Batch Upscaling (Directory or multiple single images)
- Automatic Image tiling/merging to avoid running out of VRAM
- Post-Processing: Automatically resize after upscaling
- Compatible with PNG, JPEG, BMP, WEBP, TGA, DDS images
- Load image straight out of the clipboard (no need to download images from web)
