import time
from datetime import datetime
import numpy as np
from ctypes import CDLL, c_int, c_double, POINTER

# Load the LabVIEW DLL from VER1.3
bwtek_dll = CDLL(r"c:\Users\User\Documents\Programming\BWTek-automatization\BWTek\VER1.3\BWTEKUSB.dll")

def log_message(message, log_file="function_test_log.txt"):
    """Log messages to both a file and the terminal."""
    timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    formatted_message = f"[{timestamp}] {message}"
    
    # Log to the terminal
    print(formatted_message)
    
    # Log to the file
    with open(log_file, "a") as f:
        f.write(formatted_message + "\n")

def test_dll_functions():
    """Test the functions in the DLL to verify they work."""
    try:
        log_message("Starting DLL function tests...")

        # Test bwtekSetTimeUSB_2
        integration_time = 100
        mode = 1
        channel = 0
        log_message(f"Testing bwtekSetTimeUSB_2 with integration_time={integration_time}, mode={mode}, channel={channel}")
        result = bwtek_dll.bwtekSetTimeUSB_2(c_int(integration_time), c_int(mode), c_int(channel))
        log_message(f"bwtekSetTimeUSB_2 returned: {result}")

        # Test bwtekReadValue (wavelengths)
        wavelengths = np.zeros(2048, dtype=np.float64)
        wavelength_ptr = wavelengths.ctypes.data_as(POINTER(c_double))
        log_message("Testing bwtekReadValue for wavelengths...")
        result = bwtek_dll.bwtekReadValue(c_int(0), wavelength_ptr, c_int(channel))
        log_message(f"bwtekReadValue (wavelengths) returned: {result}")
        log_message(f"Sample wavelengths: {wavelengths[:5]}")

        # Test bwtekReadValue (intensities)
        intensities = np.zeros(2048, dtype=np.float64)
        intensity_ptr = intensities.ctypes.data_as(POINTER(c_double))
        log_message("Testing bwtekReadValue for intensities...")
        result = bwtek_dll.bwtekReadValue(c_int(1), intensity_ptr, c_int(channel))
        log_message(f"bwtekReadValue (intensities) returned: {result}")
        log_message(f"Sample intensities: {intensities[:5]}")

        # Test CloseDevices
        log_message("Testing CloseDevices...")
        result = bwtek_dll.CloseDevices()
        log_message(f"CloseDevices returned: {result}")

        log_message("DLL function tests completed.")
    except Exception as e:
        log_message(f"An error occurred during testing: {e}")

if __name__ == "__main__":
    test_dll_functions()