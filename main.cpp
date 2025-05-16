#include <windows.h>
#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <filesystem> // Include for std::filesystem

// Link the library automatically
#pragma comment(lib, "c:\\Users\\User\\Documents\\Programming\\BWTek-automatization\\BTC655_BTC655N\\BTC655_Demo_DLL_v1.0.0.2\\BWTEKUSB_TEST\\BWTEKUSB.lib")

// DLL function prototypes (based on Form1.cs)
extern "C" {
    __declspec(dllimport) int GetDeviceCount();
    __declspec(dllimport) int bwtekReadEEPROMUSB(const char* filename, int channel);
    __declspec(dllimport) int bwtekTestUSB(int timing_mode, int pixel_number, int input_mode, int channel, int reserved);
    __declspec(dllimport) int bwtekSetTimingsUSB(int timing_mode, int inttime, int channel);
    __declspec(dllimport) int bwtekDataReadUSB(int TriggerMode, unsigned short* MemHandle, int channel);
}

void logMessage(const std::string& message, std::ofstream& logFile) {
    std::cout << message << std::endl; // Output to console
    logFile << message << std::endl;  // Output to log file
}

int main() {
    std::ofstream logFile("process_log.txt"); // Open log file
    if (!logFile.is_open()) {
        std::cerr << "Failed to open log file in directory: " << std::filesystem::current_path() << std::endl;
        return 1;
    }

    // 1. Initialize
    logMessage("Initializing spectrometer...", logFile);
    int deviceCount = GetDeviceCount();
    if (deviceCount <= 0) {
        logMessage("No spectrometer found!", logFile);
        return 1;
    }
    logMessage("Spectrometer found. Device count: " + std::to_string(deviceCount), logFile);

    int channel = 0; // Use first device

    // 2. Read EEPROM and get parameters (simulate, or use defaults)
    const char* iniFile = "para_0.ini";
    logMessage("Reading EEPROM using file: " + std::string(iniFile), logFile);
    bwtekReadEEPROMUSB(iniFile, channel);

    // For demo, set pixel number and timing mode (should parse iniFile for real use)
    int pixel_number = 2048;
    int timing_mode = 1;
    int input_mode = 1;
    int integration_time = 100; // ms

    // 3. Initialize device
    logMessage("Initializing device with timing mode: " + std::to_string(timing_mode) +
               ", pixel number: " + std::to_string(pixel_number) +
               ", input mode: " + std::to_string(input_mode), logFile);
    if (bwtekTestUSB(timing_mode, pixel_number, input_mode, channel, 0) != 0) {
        logMessage("Failed to initialize spectrometer!", logFile);
        return 1;
    }
    logMessage("Device initialized successfully.", logFile);

    // 4. Set integration time
    logMessage("Setting integration time to " + std::to_string(integration_time) + " ms.", logFile);
    if (bwtekSetTimingsUSB(timing_mode, integration_time, channel) != 0) {
        logMessage("Failed to set integration time!", logFile);
        return 1;
    }
    logMessage("Integration time set successfully.", logFile);

    // 5. Read spectrum data
    logMessage("Reading spectrum data...", logFile);
    std::vector<unsigned short> spectrum(pixel_number);
    if (bwtekDataReadUSB(0, spectrum.data(), channel) != 0) {
        logMessage("Failed to read spectrum data!", logFile);
        return 1;
    }
    logMessage("Spectrum data read successfully.", logFile);

    // 6. Print a few values
    logMessage("First 10 spectrum values:", logFile);
    for (int i = 0; i < 10 && i < pixel_number; ++i) {
        std::string value = "Pixel " + std::to_string(i) + ": " + std::to_string(spectrum[i]);
        logMessage(value, logFile);
    }

    // 7. Save to CSV
    logMessage("Saving spectrum data to spectrum.csv...", logFile);
    std::ofstream csv("spectrum.csv");
    if (!csv.is_open()) {
        logMessage("Failed to open spectrum.csv for writing!", logFile);
        return 1;
    }
    csv << "Pixel,Intensity\n";
    for (int i = 0; i < pixel_number; ++i) {
        csv << i << "," << spectrum[i] << "\n";
    }
    csv.close();
    logMessage("Spectrum data saved to spectrum.csv.", logFile);

    logMessage("Process completed successfully.", logFile);
    logFile.close();
    return 0;
}