#include <windows.h>
#include <iostream>
#include <fstream>
#include <vector>
#include <string>

// DLL function prototypes (based on Form1.cs)
extern "C" {
    __declspec(dllimport) int GetDeviceCount();
    __declspec(dllimport) int bwtekReadEEPROMUSB(const char* filename, int channel);
    __declspec(dllimport) int bwtekTestUSB(int timing_mode, int pixel_number, int input_mode, int channel, int reserved);
    __declspec(dllimport) int bwtekSetTimingsUSB(int timing_mode, int inttime, int channel);
    __declspec(dllimport) int bwtekDataReadUSB(int TriggerMode, unsigned short* MemHandle, int channel);
}

int main() {
    // 1. Initialize
    int deviceCount = GetDeviceCount();
    if (deviceCount <= 0) {
        std::cerr << "No spectrometer found!" << std::endl;
        return 1;
    }
    int channel = 0; // Use first device

    // 2. Read EEPROM and get parameters (simulate, or use defaults)
    const char* iniFile = "para_0.ini";
    bwtekReadEEPROMUSB(iniFile, channel);

    // For demo, set pixel number and timing mode (should parse iniFile for real use)
    int pixel_number = 2048;
    int timing_mode = 1;
    int input_mode = 1;
    int integration_time = 100; // ms

    // 3. Initialize device
    if (bwtekTestUSB(timing_mode, pixel_number, input_mode, channel, 0) != 0) {
        std::cerr << "Failed to initialize spectrometer!" << std::endl;
        return 1;
    }

    // 4. Set integration time
    if (bwtekSetTimingsUSB(timing_mode, integration_time, channel) != 0) {
        std::cerr << "Failed to set integration time!" << std::endl;
        return 1;
    }

    // 5. Read spectrum data
    std::vector<unsigned short> spectrum(pixel_number);
    if (bwtekDataReadUSB(0, spectrum.data(), channel) != 0) {
        std::cerr << "Failed to read spectrum data!" << std::endl;
        return 1;
    }

    // 6. Print a few values
    std::cout << "First 10 spectrum values:" << std::endl;
    for (int i = 0; i < 10 && i < pixel_number; ++i) {
        std::cout << "Pixel " << i << ": " << spectrum[i] << std::endl;
    }

    // 7. Save to CSV
    std::ofstream csv("spectrum.csv");
    csv << "Pixel,Intensity\n";
    for (int i = 0; i < pixel_number; ++i) {
        csv << i << "," << spectrum[i] << "\n";
    }
    csv.close();
    std::cout << "Spectrum saved to spectrum.csv" << std::endl;

    return 0;
}