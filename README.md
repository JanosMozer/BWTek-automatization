# BWTEK Spectrometer Remote Control (C++/C#)

This repository provides a **C++/C Sharp implementation** for controlling a BWTEK spectrometer and managing measurements remotely. It is designed for setups where direct physical access to the spectrometer is limited or when measurements need to be taken periodically.

## Features
* Connect to and initialize a BWTEK spectrometer.
* Trigger spectral measurements via C++ and C# code.
* Retrieve and process spectral data.
* Remote management of measurement sessions through a lightweight server or API interface.
* Export data for downstream analysis.

---

## Requirements
* BWTEK spectrometer with drivers installed.
* C++17 or newer.
* BWTEK SDK / dynamic library (DLL for Windows, SO for Linux, DYLIB for macOS).
* CMake (for building).
* [Optional] gRPC or REST framework for remote communication.

---

## Notes
* Tested with BWTek Exemplar Plus Spectrometer: https://bwtek.com/wp-content/uploads/2024/09/280001230-E-BTC655N-ExemplarPlus-compressed.pdf.
* Ensure SDK and hardware firmware versions are compatible.
* Remote use requires appropriate network configuration and permissions.
