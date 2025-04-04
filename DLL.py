import ctypes
import os

def try_functions(lib):
    """Try BWTek function naming patterns to find all available functions."""
    # Common prefixes for BWTek functions
    prefixes = ["bwtek"]
    
    # Comprehensive list of base function names
    base_names = [
        # Core functions - original list
        "InitDevice", "CloseDevice", "TestUSB", "ReadEEPROM", 
        "SetIntegrationTime", "GetSpectrum", "GetSpectrumUSB",
        "SetTimingMode", "SetTriggerMode", "SetPixelMode", "SetInputMode",
        "InitSpectrometer", "Init", "Close", "ReadEEPROMUSB",
        "SetIntTime", "GetData", "GetDataUSB", "Acquire",
        
        # Initialization and device connection
        "OpenDevice", "Initialize", "Connect", "Setup", "OpenUSB",
        "Reset", "ResetDevice", "GetDeviceHandle",
        
        # Acquisition control
        "SetExposureTime", "SetExposure", "SetAcquisitionTime", 
        "StartAcquisition", "StopAcquisition", "AbortAcquisition",
        "SetAverages", "GetAverage", "GetAveragedData", "SetAccumulations",
        "GetSingleSpectrum", "GetDarkSpectrum", "GetReferenceSpectrum",
        "SubtractDark", "EnableDarkCorrection", "DisableDarkCorrection",
        "StoreBackground", "SubtractBackground", "StoreDark", "UseStoredDark",
        "SetScanAverage", "GetNumPixels", "GetPixelCount",
        
        # Trigger and timing modes
        "SetExternalTrigger", "EnableTrigger", "SetTrigger", "GetTriggerModes",
        "SoftwareTrigger", "GetTriggerOptions", "WaitForTrigger",
        "SetSyncMode", "GetTriggerStatus", "SetTriggerDelay",
        
        # Status and information queries
        "GetStatus", "IsConnected", "GetDeviceInfo", "GetFirmwareVersion",
        "GetHardwareInfo", "GetSerialNumber", "GetModelInfo",
        "IsUSBConnected", "CheckConnection", "GetUSBStatus",
        
        # Laser/excitation control
        "SetLaserPower", "EnableLaser", "DisableLaser", "GetLaserStatus",
        "SetLaserWavelength", "GetLaserPower", "SetLaserMode",
        "LightSourceOn", "LightSourceOff", "SetLightSourceIntensity",
        
        # Detector/CCD control
        "SetCCDTemp", "GetCCDTemp", "SetDetectorGain", "GetDetectorGain",
        "SetBinning", "EnableCooling", "DisableCooling", "GetCoolingStatus",
        "SetGain", "GetTemperature", "GetTargetTemperature",
        "SetTECTemp", "EnableTEC", "DisableTEC", "GetTECStatus", "SetTEC",
        
        # Data processing
        "ApplyCalibration", "CorrectSpectrum", "SmoothData", "FindPeaks", 
        "RemoveBackground", "RemoveCosmicRays", "GetProcessedData",
        "ProcessSpectrum", "ConvertToWavelength", "GetWavelengthData",
        "ConvertRaw", "GetCalibrationCoefficients", "SetSmoothing",
        
        # Configuration
        "SaveConfig", "LoadConfig", "SetParameter", "GetParameter",
        "StoreSettings", "RecallSettings", "GetDeviceParams", "SetDeviceParams",
        "SaveSettings", "SaveCalibration", "LoadCalibration",
        
        # Shutter control
        "OpenShutter", "CloseShutter", "SetShutter", "GetShutterStatus",
        
        # Additional spectral operations
        "NormalizeSpectrum", "CalculateAbsorbance", "CalculateTransmission",
        "InvertSpectrum", "GetSpectrumRange", "SetWavelengthRange",
        
        # PL-specific functions
        "MeasurePL", "SetExcitationWavelength", "GetPLParameters",
        "SetEmissionFilter", "SetExcitationFilter", "CalcQuantumYield"
    ]
    
    # Try all combinations
    found_functions = []
    
    for prefix in prefixes:
        for base in base_names:
            for suffix in ["", "USB"]:
                if base.endswith("USB") and suffix == "USB":
                    continue  # Avoid duplicates
                
                func_name = f"{prefix}{base}{suffix}"
                try:
                    func = getattr(lib, func_name)
                    found_functions.append(func_name)
                    print(f"✓ Found function: {func_name}")
                except AttributeError:
                    pass
    
    return found_functions

# Load the DLL
dll_path = r"C:\Users\mozer\Documents\MESH\Projects_windows\BWTek-automatization\Controller\bwtekusb.dll"
if not os.path.exists(dll_path):
    print(f"Error: DLL not found at {dll_path}")
    exit(1)

try:
    lib = ctypes.cdll.LoadLibrary(dll_path)
    print(f"Successfully loaded DLL from {dll_path}")
except Exception as e:
    print(f"Error loading DLL: {e}")
    exit(1)

print("Scanning for BWTek functions...")
found_functions = try_functions(lib)

if not found_functions:
    print("No BWTek functions found.")
else:
    print(f"\nFound {len(found_functions)} functions in the BWTek DLL:")
    
    # Group functions by category for better readability
    categories = {
        "Init": [], "Close": [], "Test": [], "Read": [],
        "Set": [], "Get": [], "Enable": [], "Disable": [],
        "Other": []
    }
    
    for func in found_functions:
        categorized = False
        for prefix in categories.keys():
            if prefix.lower() in func.lower():
                categories[prefix].append(func)
                categorized = True
                break
        if not categorized:
            categories["Other"].append(func)
    
    # Print functions by category
    for category, funcs in categories.items():
        if funcs:
            print(f"\n{category} functions ({len(funcs)}):")
            for func in sorted(funcs):
                print(f"  - {func}")